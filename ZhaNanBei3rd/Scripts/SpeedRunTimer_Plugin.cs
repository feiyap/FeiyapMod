using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
using ChronoArkMod.ModData;
using HarmonyLib;
using Mono.Cecil;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine.EventSystems;

namespace ZhaNanBei3rd
{
    [HarmonyPatch(typeof(Door),nameof(Door.Trigger))]
    public static class DoORTriggerPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            PlayData.TSavedata.TimeTick = 0L;
            PlayData.RunPlayTime.Reset();
            PlayData.RunPlayTime.Start();
            TimerCV.instance.Started = true;
        }
    }
    [HarmonyPatch(typeof(BattleEnemy), nameof(BattleEnemy.ChangeSprite),new Type[] {typeof(GameObject)})]
    public static class BattleEnemyChangeSpritePatch
    {
        [HarmonyPostfix]
        public static void Postfix(BattleEnemy __instance)
        {
            if(__instance.Info.KeyData==GDEItemKeys.Enemy_LBossFirst)
            TimerCV.instance.SetLastBattleEnd();
        }
    }
    [HarmonyPatch(typeof(FieldSystem), nameof(FieldSystem.NextStage))]
    public static class FieldSystemNextStagePatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            TimerCV.instance.BattleCount = 0;

        }
    }
    [HarmonyPatch(typeof(P_ProgramMaster), nameof(P_ProgramMaster.Dead))]
    public static class P_ProgramMasterDeadPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            TimerCV.instance.MainEnd = true;

        }
    }
    [HarmonyPatch ]
    public static class LoseBattlePatch
    {
        [HarmonyPatch(typeof(MasterSDMap2), "LoseBattle")]
        [HarmonyPatch(typeof(MasterSDMap3), "LoseBattle")]
        [HarmonyPrefix]
        public static void Prefix()
        {
            TimerCV.instance.MainEnd = true;

        }
    }
    public class TimerCV : CustomValue
    {
        public static TimerCV instance {
            get
            {
                if (PlayData.TSavedata == null)
                {
                    return new TimerCV();
                }
                var cv = PlayData.TSavedata.GetCustomValue<TimerCV>();
                if (cv == null)
                {
                    cv = PlayData.TSavedata.AddCustomValue(new TimerCV()) as TimerCV;
                }
                return cv;
            }
        }
        public float InBattle;
        public bool Started;
        public float LastBattleEnd;
        public int BattleCount;
        public bool MainEnd;
        public void SetLastBattleEnd()
        {
            LastBattleEnd = InBattle;
            BattleCount++;
        }
    }
    public class SpeedRunTimer_PluginMonoBehavior : ChronoArkPluginMonoBehaviour
    {
        public static TimeSpan GetInBattle()
        {
            if (!TimerCV.instance.Started)
            {
                return new TimeSpan(0L);
            }
            if (TimerCV.instance.MainEnd)
            {
                return TimeSpan.FromSeconds((double)TimerCV.instance.InBattle);
            }
            if (BattleSystem.instance != null && BattleSystem.instance.Particles.Count == 0 && !PauseWindow.IsOn && !BattleSystem.instance.BattleEndBool && (!BattleSystem.instance.EnemyCheck || UIManager.NowActiveUI != null))
            {
                if (!BattleSystem.instance.ActWindow.CanAnyMove|| !BattleSystem.instance.ActWindow.On)
                {
                    
                   if(UIManager.NowActiveUI !=null&& (UIManager.NowActiveUI is SelectSkillList)&&UIManager.NowActiveUI.gameObject!=null)
                    {
                        TimerCV.instance.InBattle += Time.deltaTime;
                    }
                   
                }
                else
                {
                    TimerCV.instance.InBattle += Time.deltaTime;
                }
               

            }
            return TimeSpan.FromSeconds((double)TimerCV.instance.InBattle);
        }
        public static TimeSpan GetWhole()
        {
            if (!TimerCV.instance.Started)
            {
                return new TimeSpan(0L);
            }
            long timeTick = PlayData.TSavedata.TimeTick + PlayData.RunPlayTime.ElapsedTicks;
            return new TimeSpan(timeTick);
        }
        public static TimeSpan GetLastBattleEnd()
        {
            if (!TimerCV.instance.Started)
            {
                return new TimeSpan(0L);
            }
            return TimeSpan.FromSeconds((double)TimerCV.instance.LastBattleEnd);
        }
        public void Update()
        {
            if (UI != null)
            {
                Text[] texts = UI.GetComponentsInChildren<Text>(true);
                if (texts.Length > 0)
                {
                    TimeSpan timeSpan = GetInBattle();
                    if (timeSpan.Ticks > 0 || TimerCV.instance.Started)
                    {
                        texts[0].color = Color.green;

                        texts[0].text = string.Format(" {0:0}:{1:00}:{2:00}:{3:0}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 100);
                    }
                }

                if (texts.Length > 1)
                {
                    TimeSpan timeSpan = GetWhole();
                    if ((timeSpan.Ticks > 0 || TimerCV.instance.Started)&&!TimerCV.instance.MainEnd)
                    {
                        texts[1].color = Color.gray;
                        texts[1].text = string.Format(" {0:0}:{1:00}:{2:00}:{3:0}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 100);

                    }
                    
                }
                if (texts.Length > 2)
                {
                    TimeSpan timeSpan = GetLastBattleEnd();
                    

                    if (timeSpan.Ticks>0|| TimerCV.instance.Started)
                    {
                        texts[2].color = Color.white;
                        texts[2].text = string.Format("{0:0}  {1:00}:{2:00}:{3:0}", TimerCV.instance.BattleCount, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 100);
                    }
                    
                }



            }
        }
        public static Transform _UI;
        public static Transform UI
        {
            get
            {
                if (_UI==null&&PartyInventory.InvenM != null)
                {
                    Transform UI_ = PartyInventory.InvenM?.transform.parent.Find("SpeedRunTimerUI");
                    if (UI_ == null)
                    {
                        UI_ = Instantiate(Resources.Load<GameObject>("Prefebs/TrialOfTime").transform.Find("BG"), PartyInventory.InvenM?.transform.parent);
                        UI_.name = "SpeedRunTimerUI";
                        UI_.localPosition = new Vector3(0, 300, 0);
                        UI_.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 105);
                        UI_.GetChild(0).localPosition = new Vector3(0, 35, 0);
                        Instantiate(UI_.GetChild(0), UI_).localPosition = new Vector3(0, 5, 0);
                        Instantiate(UI_.GetChild(0), UI_).localPosition = new Vector3(0, -25, 0);
                        UI.gameObject.AddComponent<DraggableUI>();


                    }
                    _UI = UI_;
                }
                return _UI;
            }
        }
        
       
    }
    public class DraggableUI : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        private RectTransform rectTransform;
        private Vector2 offset;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (rectTransform != null)
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out pos);
                rectTransform.anchoredPosition = pos - offset;
            }
        }
    }
}
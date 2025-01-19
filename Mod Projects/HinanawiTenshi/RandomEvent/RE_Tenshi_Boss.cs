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
namespace HinanawiTenshi
{
	/// <summary>
	/// 博丽神社
	/// Button
	/// ButtonToolTip
	/// </summary>
    public class RE_Tenshi_Boss:RandomEventBaseScript
    {
        public override void EventInit()
        {
            base.EventInit();
            this.m = UnityEngine.Object.FindObjectOfType<MiniBossObject>();
            this.s = UnityEngine.Object.FindObjectOfType<Stage1Events>();
        }
        
        public override void EventOpen()
        {
            base.EventOpen();
            if (this.m == null)
            {
                this.m = UnityEngine.Object.FindObjectOfType<MiniBossObject>();
            }
            if (this.s == null)
            {
                this.s = UnityEngine.Object.FindObjectOfType<Stage1Events>();
            }
            if (this.m.BossClear)
            {
                base.ChangeDesc(this.MyUI.MainEventData.OrderStrings[0], true);
                return;
            }
            base.ChangeDesc(this.MyUI.MainEventData.EventDetails, false);
        }
        
        public override void UseButton1()
        {
            UIManager.inst.StartCoroutine(this.Co_OnlyEvent());
        }

        private IEnumerator Co_OnlyEvent()
        {
            yield return new WaitForSeconds(1f);
            this.BattleStart();
            yield break;
        }

        private void BattleStart()
        {
            base.ChangeDesc(this.MyUI.MainEventData.OrderStrings[0], true);
            FieldSystem.instance.BattleAfterDelegate = new FieldSystem.BattleAfterDel(this.AfterBattle);
            FieldSystem.instance.BattleStart(new GDEEnemyQueueData("Queue_Boss_Tenshi"), GDEItemKeys.BattleMaps_BattleMap_Beach, true, false, "", "", false);
            UIManager.inst.StartCoroutine(UIManager.inst.FadeBlack_In(0.5f));
        }

        private void AfterBattle()
        {
            base.EventDisable();
            FieldSystem.DelayInput(this.Co_AfterBattle());
        }

        private IEnumerator Co_AfterBattle()
        {
            this.MyUI.Delete();
            while (GameObject.FindGameObjectWithTag("BattleStop"))
            {
                yield return null;
            }
            bool flag = this.m != null;
            if (flag)
            {
                this.m.BossClear = true;
            }
            else
            {
                bool flag2 = this.s != null;
                if (flag2)
                {
                    this.s.BossClear = true;
                }
            }
            yield return new WaitForSeconds(1f);
            yield break;
        }

        private MiniBossObject m;
        private Stage1Events s;
    }
}
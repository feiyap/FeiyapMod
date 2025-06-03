using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using HarmonyLib;
using GameDataEditor;
using System.Collections;

namespace VillageAlice
{
    [HarmonyPatch(typeof(BattleSystem))]
    [HarmonyPatch("MyTurn")]
    public static class MyTurn_Plugin
    {
        [HarmonyPrefix]
        public static bool MyTurn_Prefix(ref IEnumerator __result, BattleSystem __instance)
        {
            foreach (BattleChar bc in __instance.AllyList)
            {
                if (bc.BuffFind("B_FVAlice_Rare_2"))
                {
                    bc.BuffReturn("B_FVAlice_Rare_2").SelfStackDestroy();
                    __result = ExtraTurn(__instance);
                    //__instance.gameObject.AddComponent<RuntimePinkFilter>();
                    UIManager.inst.UIcamera.gameObject.AddComponent<RuntimePinkFilter>();

                    return false;
                }
            }

            return true;
        }

        private static IEnumerator ExtraTurn(BattleSystem __instance)
        {
            yield return new WaitForSeconds(0.25f);
            if (__instance.BattleEndBool)
            {
                for (; ; )
                {
                    yield return null;
                }
            }
            else
            {
                __instance.AllyTeam.HandTurnCheck();
                while (__instance.ListWait || __instance.DelayWait)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                __instance.AllyTeam.MyTurn();
                while (__instance.ListWait || __instance.DelayWait)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(0.15f);
                __instance.EffectDelays.Enqueue(__instance.TurnUpdate());
                while (__instance.ListWait || __instance.DelayWait)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                Camera.main.GetComponent<SmoothMove>().Rotate(__instance.CamInit);
                __instance.AllyTeam.OneUpdate();
                __instance.AllyTeam.NewTurn();
                __instance.TurnSpacialCharacterParticleUseList.Clear();
                while (__instance.ListWait || __instance.DelayWait)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                __instance.ActWindow.Draw(__instance.AllyTeam, true);
                while (__instance.ListWait || __instance.DelayWait)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                foreach (IP_PlayerTurn ip_PlayerTurn in __instance.IReturn<IP_PlayerTurn>())
                {
                    if (ip_PlayerTurn != null)
                    {
                        ip_PlayerTurn.Turn();
                    }
                }
                while (__instance.ListWait || __instance.DelayWait)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                using (List<IP_PlayerTurn_1>.Enumerator enumerator2 = __instance.IReturn<IP_PlayerTurn_1>().GetEnumerator())
                {
                    while (enumerator2.MoveNext())
                    {
                        IP_PlayerTurn_1 ip_PlayerTurn_ = enumerator2.Current;
                        if (ip_PlayerTurn_ != null)
                        {
                            ip_PlayerTurn_.Turn1();
                        }
                    }
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    [RequireComponent(typeof(Camera))]
    public class RuntimePinkFilter : MonoBehaviour
    {
        private Material _pinkMaterial;

        public void OnEnable()
        {
            // 使用Unity内置的UI/Default Shader作为基础
            var shader = Shader.Find("UI/Default");
            _pinkMaterial = new Material(shader);
            _pinkMaterial.hideFlags = HideFlags.HideAndDontSave;
        }

        public void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            // 设置粉色颜色并应用
            _pinkMaterial.SetColor("_Color", new Color(1f, 0.7f, 0.9f, 1.0f)); // 粉色，50%透明度
            Graphics.Blit(src, dest, _pinkMaterial);
        }

        public void OnDisable()
        {
            if (_pinkMaterial != null)
                DestroyImmediate(_pinkMaterial);
        }
    }
}

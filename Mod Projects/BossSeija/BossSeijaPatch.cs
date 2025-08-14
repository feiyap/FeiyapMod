using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ChronoArkMod;
using ChronoArkMod.ModData.Settings;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using HarmonyLib;

namespace BossSeija
{
    class BossSeijaPatch
    {
        [HarmonyPatch(typeof(ToolTipWindow))]
        [HarmonyPatch("SkillToolTip")]
        public static class SkillToolTip_Plugin
        {
            [HarmonyPostfix]
            public static void SkillToolTip_Postfix(ref GameObject __result)
            {
                if (__result.GetComponent<SkillToolTip>().Values.SkillData.Master.Info.KeyData != "Boss_Seija")
                {
                    __result.GetComponent<RectTransform>().pivot = new Vector2((float)0.5, (float)0.5);
                    __result.transform.Rotate(180, 180, 0, Space.Self);
                    __result.GetComponent<RectTransform>().pivot = new Vector2((float)0, (float)0);
                }
            }
        }

        [HarmonyPatch(typeof(BattleCamera))]
        [HarmonyPatch("Update")]
        public static class BattleCameraFlipPatch
        {
            static bool initialized = false;
            static Matrix4x4 flipMatrix;

            static void Postfix(BattleCamera __instance)
            {
                if (!initialized)
                {
                    // 创建180度翻转矩阵
                    flipMatrix = Matrix4x4.identity;
                    flipMatrix.m00 = -1; // 水平翻转
                    flipMatrix.m11 = -1; // 垂直翻转
                    initialized = true;

                    ApplyFlipToCamera(__instance.mainCam);
                    ApplyFlipToCamera(__instance.ObjectCam);
                    ApplyFlipToCamera(__instance.UI3DCam); // 这是关键，处理UI摄像机
                    ApplyFlipToCamera(__instance.ParticleCam);
                    ApplyFlipToCamera(__instance.ParticleCam3D);
                    ApplyFlipToCamera(__instance.ParticleAlpha2D);
                }
            }

            static void ApplyFlipToCamera(Camera cam)
            {
                if (cam != null)
                {
                    cam.projectionMatrix = flipMatrix * cam.projectionMatrix;
                }
            }
        }

        [HarmonyPatch(typeof(BattleSystem))]
        [HarmonyPatch("Update")]
        public static class DynamicUIFlipPatch
        {
            static void Postfix(BattleSystem __instance)
            { 
                Vector3 targetScale = new Vector3(-1, -1, 1);

                __instance.ActWindow.transform.localScale = targetScale;
                __instance.BuffView.transform.localScale = targetScale;
                __instance.lucyM.transform.localScale = targetScale;
                __instance.LucyFaceTextPosition.transform.localScale = targetScale;
                GameObject.Find("AlignAlly").transform.localScale = targetScale;
                UIManager.
            }
        }
    }
}

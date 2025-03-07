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
using System.Reflection;
using System.Reflection.Emit;

namespace HiHouClab
{
    [HarmonyPatch(typeof(BattleTeam))]
    public static class BattleTeamPatch
    {
        private static FieldInfo _planckAPField;
        private static PropertyInfo _planckAPProperty;

        // 在 Harmony 初始化时动态插入字段、属性和方法
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPostfix]
        static void AddPlanckAPFieldAndMethods(BattleTeam __instance)
        {
            // 动态添加 _PlanckAP 字段
            _planckAPField = typeof(BattleTeam).GetField("_PlanckAP", BindingFlags.NonPublic | BindingFlags.Instance);
            if (_planckAPField == null)
            {
                _planckAPField = typeof(BattleTeam)
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .FirstOrDefault(f => f.Name == "_PlanckAP");
                if (_planckAPField == null)
                {
                    _planckAPField = typeof(BattleTeam)
                        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                        .FirstOrDefault();
                    if (_planckAPField == null)
                    {
                        throw new Exception("Failed to add _PlanckAP field.");
                    }
                }
            }

            // 初始化 _PlanckAP 字段
            _planckAPField.SetValue(__instance, 0); // 默认值为 0

            // 动态添加 PlanckAP 属性
            typeof(BattleTeam).GetProperty("PlanckAP", BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
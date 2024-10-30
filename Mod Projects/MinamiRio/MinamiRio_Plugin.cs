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
namespace MinamiRio
{
    public class MinamiRio_Plugin : ChronoArkPlugin
    {
        public override void Dispose()
        {
            Harmony harmony = this.harmony;
            if (harmony != null)
            {
                harmony.UnpatchSelf();
            }
        }

        public override void Initialize()
        {
            this.harmony = new Harmony(base.GetGuid());
            this.harmony.PatchAll();
        }

        private Harmony harmony;
    }

    //可以指向不能被指定（vanish）的敌人
    [HarmonyPatch(typeof(BattleSystem), nameof(BattleSystem.SkillTargetReturn))]
    public static class SkillTargetReturnPrefix
    {
        [HarmonyPrefix]
        public static bool Prefix(ref List<BattleChar> __result, BattleSystem __instance, Skill sk, BattleChar Target, BattleChar PlusTarget = null)
        {
            List<BattleChar> list = new List<BattleChar>();
            if (sk.MySkill.Target.Key == GDEItemKeys.s_targettype_all_enemy)
            {
                if (sk.Master.Info.Ally)
                {
                    using (List<BattleEnemy>.Enumerator enumerator = __instance.EnemyList.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            BattleEnemy item = enumerator.Current;
                            list.Add(item);
                        }
                    }
                }
                else
                {
                    using (List<BattleAlly>.Enumerator enumerator2 = __instance.AllyList.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            BattleAlly item2 = enumerator2.Current;
                            list.Add(item2);
                        }
                    }
                }
            }
            else if (sk.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
            {
                if (!sk.Master.Info.Ally)
                {
                    using (List<BattleEnemy>.Enumerator enumerator = __instance.EnemyList.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            BattleEnemy item3 = enumerator.Current;
                            list.Add(item3);
                        }
                    }
                }
                else
                {
                    using (List<BattleAlly>.Enumerator enumerator2 = __instance.AllyList.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            BattleAlly item4 = enumerator2.Current;
                            list.Add(item4);
                        }
                    }
                }

            }
            else if (sk.MySkill.Target.Key == GDEItemKeys.s_targettype_all)
            {
                foreach (BattleAlly item5 in __instance.AllyList)
                {
                    list.Add(item5);
                }
                using (List<BattleEnemy>.Enumerator enumerator = __instance.EnemyList.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        BattleEnemy item6 = enumerator.Current;
                        list.Add(item6);
                    }
                }
            }
            else if (sk.MySkill.Target.Key == GDEItemKeys.s_targettype_random_enemy)
            {
                if (sk.Master.Info.Ally)
                {
                    list.Add(__instance.EnemyList.Random(sk.Master.GetRandomClass().Target));
                }
                else
                {
                    list.Add(__instance.AllyList.Random(sk.Master.GetRandomClass().Target));
                }
            }
            else if (!Target.IsDead)
            {
                list.Add(Target);
            }

            if (sk.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy_PlusRandom)
            {
                if (PlusTarget != null && !PlusTarget.IsDead)
                {
                    list.Add(PlusTarget);
                }
                else
                {
                    List<BattleChar> list2 = new List<BattleChar>();
                    if (sk.Master.Info.Ally)
                    {
                        foreach (BattleEnemy item7 in __instance.EnemyList)
                        {
                            list2.Add(item7);
                        }
                        list2.Remove(list[0]);
                        if (list2.Count != 0)
                        {
                            list.Add(list2.Random(sk.Master.GetRandomClass().Target));
                        }
                    }
                    else
                    {
                        foreach (BattleAlly item8 in __instance.AllyList)
                        {
                            list2.Add(item8);
                        }
                        list2.Remove(list[0]);
                        if (list2.Count != 0)
                        {
                            list.Add(list2.Random(sk.Master.GetRandomClass().Target));
                        }
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetStat.Vanish && sk.MySkill.KeyID != "S_MinamiRio_6" && !list[i].BuffFind("B_MinamiRio_6"))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            __result = list;
            return false;
        }
    }

    //vanish时可以被指定
    [HarmonyPatch(typeof(BattleSystem), nameof(BattleSystem.IsSelect))]
    public static class IsSelectPrefix
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result, BattleSystem __instance, BattleChar Target, Skill skill)
        {
            string targetTypeKey = skill.TargetTypeKey;
            bool ally = skill.Master.Info.Ally;
            if (Target.GetStat.Vanish && skill.MySkill.KeyID != "S_MinamiRio_6" && !Target.BuffFind("B_MinamiRio_6"))
            {
                return false;
            }
            bool flag = false;
            if (targetTypeKey == GDEItemKeys.s_targettype_all_enemy && ally != Target.Info.Ally)
            {
                flag = true;
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_all_ally && ally == Target.Info.Ally)
            {
                flag = true;
            }
            if ((targetTypeKey == GDEItemKeys.s_targettype_enemy || targetTypeKey == GDEItemKeys.s_targettype_enemy_PlusRandom) && ally != Target.Info.Ally)
            {
                //flag = BattleSystem.TargetSelectCheck(Target, skill, flag);
                //flag = Traverse.Create(__instance)
                //               .Method("TargetSelectCheck", new object[] { Target, skill, flag })
                //               .GetValue<bool>();
                if (skill.ForceAction)
                {
                    flag = true;
                }
                else if (Target is BattleEnemy)
                {
                    bool flag2 = false;
                    foreach (IP_ForceEnemyTargetSelect ip_ForceEnemyTargetSelect in skill.IReturn<IP_ForceEnemyTargetSelect>())
                    {
                        if (ip_ForceEnemyTargetSelect != null)
                        {
                            flag2 = true;
                            if (ip_ForceEnemyTargetSelect.ForceEnemyTargetSelect(skill, Target as BattleEnemy))
                            {
                                flag = true;
                                break;
                            }
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        foreach (IP_SpecialEnemyTargetSelect ip_SpecialEnemyTargetSelect in skill.Master.IReturn<IP_SpecialEnemyTargetSelect>(skill))
                        {
                            if (ip_SpecialEnemyTargetSelect != null && ip_SpecialEnemyTargetSelect.SpecialEnemyTargetSelect(skill, Target as BattleEnemy))
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            bool flag3 = false;
                            using (List<Skill_Extended>.Enumerator enumerator3 = skill.AllExtendeds.GetEnumerator())
                            {
                                while (enumerator3.MoveNext())
                                {
                                    if (enumerator3.Current.CanIgnoreTauntTarget(Target))
                                    {
                                        flag3 = true;
                                        break;
                                    }
                                }
                            }
                            if (flag3 || skill.IgnoreTaunt || !(Target as BattleEnemy).TauntNoTarget || Target.GetStat.IgnoreTaunt_EnemySelf)
                            {
                                flag = true;
                            }
                        }
                    }
                }
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_ally && ally == Target.Info.Ally)
            {
                flag = true;
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_self && Target.Info == skill.Master.Info)
            {
                flag = true;
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_random_enemy && ally != Target.Info.Ally)
            {
                flag = true;
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_otherally && Target != skill.Master && ally == Target.Info.Ally)
            {
                flag = true;
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_all_onetarget)
            {
                //flag = (ally == Target.Info.Ally || BattleSystem.TargetSelectCheck(Target, skill, flag));
                //flag = (ally == Target.Info.Ally || Traverse.Create(__instance).Method("TargetSelectCheck", Target, skill, flag).GetValue<bool>());
                if (skill.ForceAction)
                {
                    flag = true;
                }
                else if (Target is BattleEnemy)
                {
                    bool flag2 = false;
                    foreach (IP_ForceEnemyTargetSelect ip_ForceEnemyTargetSelect in skill.IReturn<IP_ForceEnemyTargetSelect>())
                    {
                        if (ip_ForceEnemyTargetSelect != null)
                        {
                            flag2 = true;
                            if (ip_ForceEnemyTargetSelect.ForceEnemyTargetSelect(skill, Target as BattleEnemy))
                            {
                                flag = true;
                                break;
                            }
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        foreach (IP_SpecialEnemyTargetSelect ip_SpecialEnemyTargetSelect in skill.Master.IReturn<IP_SpecialEnemyTargetSelect>(skill))
                        {
                            if (ip_SpecialEnemyTargetSelect != null && ip_SpecialEnemyTargetSelect.SpecialEnemyTargetSelect(skill, Target as BattleEnemy))
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            bool flag3 = false;
                            using (List<Skill_Extended>.Enumerator enumerator3 = skill.AllExtendeds.GetEnumerator())
                            {
                                while (enumerator3.MoveNext())
                                {
                                    if (enumerator3.Current.CanIgnoreTauntTarget(Target))
                                    {
                                        flag3 = true;
                                        break;
                                    }
                                }
                            }
                            if (flag3 || skill.IgnoreTaunt || !(Target as BattleEnemy).TauntNoTarget || Target.GetStat.IgnoreTaunt_EnemySelf)
                            {
                                flag = true;
                            }
                        }
                    }
                }
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_all)
            {
                flag = true;
            }
            if (targetTypeKey == GDEItemKeys.s_targettype_deathally && Target != skill.Master && Target.Info.Incapacitated)
            {
                flag = true;
            }
            else if (Target.IsDead)
            {
                flag = false;
            }
            if (flag)
            {
                using (List<Skill_Extended>.Enumerator enumerator = skill.AllExtendeds.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.TargetSelectExcept(Target))
                        {
                            flag = false;
                        }
                    }
                }
            }
            __result = flag;
            return false;
        }
    }
}
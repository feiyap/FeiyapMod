using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
using BasicMethods;

namespace YakumoYukari
{
    /// <summary>
    /// 八云紫
    /// 幻想的境界：牌组转化为动作；迅捷/移动/标准槽；境界力。
    /// </summary>
    public class P_YakumoYukari : Passive_Char, IP_BattleStart_Ones, IP_PlayerTurn, IP_BattleEnd, IP_DealDamage, IP_StageStart
    {
        public static readonly string[] InitialKeys = new string[]
        {
            "S_YakumoYukari_0",
            "S_YakumoYukari_1",
            "S_YakumoYukari_2",
            "S_YakumoYukari_3"
        };

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.EnsureInitialSkills();
        }

        public void StageStart()
        {
            this.EnsureInitialSkills();
        }

        /// <summary>
        /// 把四张初始卡写入角色技能栏。
        /// </summary>
        public void EnsureInitialSkills()
        {
            if (this.BChar == null || this.BChar.Info == null)
            {
                return;
            }
            foreach (string key in InitialKeys)
            {
                if (this.BChar.Info.SkillDatas == null)
                {
                    continue;
                }
                bool exists = false;
                foreach (CharInfoSkillData data in this.BChar.Info.SkillDatas)
                {
                    if (data == null)
                    {
                        continue;
                    }
                    string id = null;
                    if (data.SkillInfo != null)
                    {
                        id = data.SkillInfo.KeyID;
                    }
                    if (id == key)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    continue;
                }
                try
                {
                    Skill skill = Skill.TempSkill(key, this.BChar, this.BChar.MyTeam);
                    this.BChar.Info.UseSoulStone(skill);
                }
                catch (Exception)
                {
                }
            }
        }

        public void BattleStart(BattleSystem Ins)
        {
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            bv.ActionLevels.Clear();
            bv.ClearBoundary();
            bv.GrantTurnSlots();

            this.ConvertDeckToActions(bv);
            foreach (string key in InitialKeys)
            {
                if (!bv.ActionLevels.ContainsKey(key))
                {
                    bv.AddAction(key, true);
                }
            }

            this.BChar.BuffAdd("B_YakumoYukari_P", this.BChar);
            this.RefreshBasicSlot();
        }

        public void Turn()
        {
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            bv.GrantTurnSlots();
            bv.GainBoundary(1, this.BChar);
            if (this.BChar != null && this.BChar.MyTeam != null)
            {
                this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
            }
            this.RefreshBasicSlot();
        }

        public void BattleEnd()
        {
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            if (bv != null)
            {
                bv.ClearBoundary();
            }
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage < 1 || IsDot || Take == null || Take.Info == null || Take.Info.Ally)
            {
                return;
            }
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            if (bv != null)
            {
                bv.GainBoundary(1, this.BChar);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.KeepBasicReady();
        }

        private void ConvertDeckToActions(BV_YakumoYukari_P bv)
        {
            if (BattleSystem.instance == null || BattleSystem.instance.AllyTeam == null)
            {
                return;
            }
            this.ConvertList(BattleSystem.instance.AllyTeam.Skills_Deck, bv, true);
            this.ConvertList(BattleSystem.instance.AllyTeam.Skills, bv, true);
        }

        private void ConvertList(List<Skill> list, BV_YakumoYukari_P bv, bool remove)
        {
            if (list == null)
            {
                return;
            }
            List<Skill> mine = list.Where(sk => sk != null && sk.Master == this.BChar && sk.MySkill != null).ToList();
            foreach (Skill sk in mine)
            {
                if (this.IsDefaultOrButton(sk))
                {
                    if (remove)
                    {
                        list.Remove(sk);
                    }
                    continue;
                }
                bool cannotLevel = InitialKeys.Contains(sk.MySkill.KeyID);
                bv.AddAction(sk.MySkill.KeyID, cannotLevel);
                if (remove)
                {
                    list.Remove(sk);
                    BV_ExceptDeck.AddSkill(sk);
                }
            }
        }

        private bool IsDefaultOrButton(Skill sk)
        {
            if (sk.MySkill.Basic)
            {
                return true;
            }
            if (sk.MySkill.Category != null && sk.MySkill.Category.Key == GDEItemKeys.SkillCategory_DefultSkill)
            {
                return true;
            }
            if (sk.MySkill.Category != null && sk.MySkill.Category.Key == GDEItemKeys.SkillCategory_LucySkill)
            {
                return true;
            }
            string id = sk.MySkill.KeyID;
            return id == "S_YakumoYukari_Act"
                || id == "S_YakumoYukari_Act_Swift"
                || id == "S_YakumoYukari_Act_Move"
                || id == "S_YakumoYukari_Act_Standard";
        }

        private void RefreshBasicSlot()
        {
            BattleAlly ally = this.BChar as BattleAlly;
            if (ally == null || ally.MyBasicSkill == null)
            {
                return;
            }
            this.ResetBasicSlot(ally.MyBasicSkill, "S_YakumoYukari_Act");
            this.KeepBasicReady();
        }

        /// <summary>
        /// 执行动作无冷却、每回合可无限使用。选目标或技能选择期间不打断。
        /// </summary>
        private void KeepBasicReady()
        {
            BattleAlly ally = this.BChar as BattleAlly;
            if (ally == null || ally.MyBasicSkill == null)
            {
                return;
            }
            if (BattleSystem.instance != null)
            {
                if (BattleSystem.instance.TargetSelecting || BattleSystem.instance.ItemSelect)
                {
                    return;
                }
            }
            if (S_YakumoYukari_Act.SelectingAction || UIManager.NowActiveUI is SelectSkillList)
            {
                return;
            }
            this.KeepSlotReady(ally.MyBasicSkill);
        }

        private void ResetBasicSlot(object slot, string skillKey)
        {
            if (slot == null || this.BChar == null)
            {
                return;
            }
            Type t = slot.GetType();
            Skill skill = Skill.TempSkill(skillKey, this.BChar, this.BChar.MyTeam);
            MethodInfo input = t.GetMethod("SkillInput", BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(Skill) }, null);
            if (input == null)
            {
                foreach (MethodInfo method in t.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (method.Name != "SkillInput")
                    {
                        continue;
                    }
                    ParameterInfo[] pars = method.GetParameters();
                    if (pars.Length == 1 && typeof(Skill).IsAssignableFrom(pars[0].ParameterType))
                    {
                        input = method;
                        break;
                    }
                }
            }
            if (input != null)
            {
                input.Invoke(slot, new object[] { skill });
            }
            this.KeepSlotReady(slot);
        }

        private void KeepSlotReady(object slot)
        {
            if (slot == null)
            {
                return;
            }
            Type t = slot.GetType();
            FieldInfo cd = t.GetField("CoolDownNum");
            if (cd != null)
            {
                cd.SetValue(slot, 0);
            }
            FieldInfo used = t.GetField("ThisSkillUse");
            if (used != null && used.GetValue(slot) is bool && (bool)used.GetValue(slot))
            {
                used.SetValue(slot, false);
            }
            FieldInfo inactive = t.GetField("InActive");
            if (inactive != null)
            {
                inactive.SetValue(slot, false);
            }
        }
    }
}

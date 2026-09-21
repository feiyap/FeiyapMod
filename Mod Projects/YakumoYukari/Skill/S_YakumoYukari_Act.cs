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

namespace YakumoYukari
{
    /// <summary>
    /// 执行动作：先选迅捷/移动/标准，再选具体动作并直接进入指向。
    /// </summary>
    public class S_YakumoYukari_Act : Skill_Extended
    {
        private static readonly string[] TypeKeys = new string[]
        {
            "S_YakumoYukari_Act_Swift",
            "S_YakumoYukari_Act_Move",
            "S_YakumoYukari_Act_Standard"
        };

        public static bool SelectingAction;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.EffectDelays.Enqueue(this.CoSelect());
        }

        /// <summary>
        /// 两级选择。返回按钮关闭当前层：类型层直接取消，动作层回到类型层。
        /// </summary>
        private IEnumerator CoSelect()
        {
            SelectingAction = true;
            while (true)
            {
                bool pickedType = false;
                YukariActionType declared = YukariActionType.Swift;
                List<Skill> types = this.BuildTypeSkills();
                yield return BattleSystem.I_OtherSkillSelect(
                    types,
                    delegate (SkillButton btn)
                    {
                        pickedType = true;
                        declared = ReadDeclaredType(btn);
                    },
                    ModLocalization.selectActionType,
                    true,
                    false,
                    true,
                    false,
                    true);

                if (!pickedType)
                {
                    SelectingAction = false;
                    yield break;
                }

                BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
                if (bv == null)
                {
                    SelectingAction = false;
                    yield break;
                }
                bv.DeclaredType = declared;
                List<Skill> actions = this.BuildSelectableActions(bv);
                if (actions.Count <= 0)
                {
                    continue;
                }

                bool pickedAction = false;
                yield return BattleSystem.I_OtherSkillSelect(
                    actions,
                    delegate (SkillButton btn)
                    {
                        pickedAction = true;
                        this.OnActionChosen(btn);
                    },
                    ModLocalization.selectAction,
                    true,
                    false,
                    true,
                    false,
                    true);

                if (pickedAction)
                {
                    SelectingAction = false;
                    yield break;
                }
            }
        }

        private List<Skill> BuildTypeSkills()
        {
            List<Skill> skills = new List<Skill>();
            foreach (string key in TypeKeys)
            {
                skills.Add(Skill.TempSkill(key, this.BChar, this.BChar.MyTeam));
            }
            return skills;
        }

        private static YukariActionType ReadDeclaredType(SkillButton btn)
        {
            string id = "";
            if (btn != null && btn.Myskill != null && btn.Myskill.MySkill != null)
            {
                id = btn.Myskill.MySkill.KeyID;
            }
            if (id == "S_YakumoYukari_Act_Move")
            {
                return YukariActionType.Move;
            }
            if (id == "S_YakumoYukari_Act_Standard")
            {
                return YukariActionType.Standard;
            }
            return YukariActionType.Swift;
        }

        private List<Skill> BuildSelectableActions(BV_YakumoYukari_P bv)
        {
            List<Skill> skills = new List<Skill>();
            foreach (KeyValuePair<string, int> pair in bv.ActionLevels)
            {
                if (pair.Value <= 0)
                {
                    continue;
                }
                Skill tmp = Skill.TempSkill(pair.Key, this.BChar, this.BChar.MyTeam);
                SE_YakumoYukari_Action se = FindActionExt(tmp);
                YukariActionType at = se != null ? se.ActionType : YukariActionType.Standard;
                if (!BV_YakumoYukari_P.MatchesButton(at, bv.DeclaredType))
                {
                    continue;
                }
                YukariActionCost cost = YukariActionCost.From(at, bv.DeclaredType);
                if (!bv.CanPay(cost))
                {
                    continue;
                }
                if (se != null && se.BoundaryCost > 0 && bv.Boundary < se.BoundaryCost)
                {
                    continue;
                }
                skills.Add(tmp);
            }
            return skills;
        }

        public void OnActionChosen(SkillButton Mybutton)
        {
            if (Mybutton == null || Mybutton.Myskill == null)
            {
                return;
            }
            Skill source = Mybutton.Myskill;
            BattleSystem.DelayInputAfter(this.CoTargetSelect(source));
        }

        /// <summary>
        /// 不入手牌，直接进入选择目标并准备释放。
        /// </summary>
        private IEnumerator CoTargetSelect(Skill source)
        {
            if (source == null || this.BChar == null || BattleSystem.instance == null)
            {
                yield break;
            }
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            if (bv == null)
            {
                yield break;
            }

            Skill skill = source.CloneSkill(true, null, null, true);
            skill.FreeUse = true;
            skill.isExcept = true;
            SE_YakumoYukari_Action se = FindActionExt(skill);
            YukariActionType at = se != null ? se.ActionType : YukariActionType.Standard;
            YukariActionCost cost = YukariActionCost.From(at, bv.DeclaredType);
            bool forceTick = se != null && se.ForceTick;
            if (se != null)
            {
                se.PendingCost = cost;
                se.HasPendingCost = true;
            }
            skill.NotCount = !bv.WouldTick(cost, forceTick);

            if (BattleSystem.instance.ActWindow != null && BattleSystem.instance.ActWindow.ItemSkillView != null)
            {
                ChildClear.Clear(BattleSystem.instance.ActWindow.ItemSkillView);
                GameObject tip = ToolTipWindow.SkillToolTip(BattleSystem.instance.ActWindow.ItemSkillView, skill, skill.Master, 0, 1, true, false, false);
                if (tip != null)
                {
                    tip.transform.SetParent(BattleSystem.instance.ActWindow.ItemSkillView);
                    Transform plus = tip.transform.Find("PlusTooltip");
                    if (plus != null)
                    {
                        plus.gameObject.SetActive(false);
                    }
                    SkillToolTip st = tip.GetComponent<SkillToolTip>();
                    if (st != null)
                    {
                        st.LayerDown();
                    }
                }
            }

            skill.OriginalSelectSkill = BattleSystem.instance.SelectedSkill;
            BattleSystem.instance.ActionAlly = this.BChar as BattleAlly;
            BattleSystem.instance.TargetSelecting = true;
            BattleSystem.instance.SelectedSkill = skill;
            BattleSystem.instance.ItemSelect = true;
            ToolTipWindow.ToolTip = null;
            BattleSystem.instance.TargetSelect(skill, skill.Master);
            yield break;
        }

        private static SE_YakumoYukari_Action FindActionExt(Skill skill)
        {
            if (skill == null || skill.AllExtendeds == null)
            {
                return null;
            }
            foreach (Skill_Extended ext in skill.AllExtendeds)
            {
                SE_YakumoYukari_Action se = ext as SE_YakumoYukari_Action;
                if (se != null)
                {
                    return se;
                }
            }
            return null;
        }
    }
}

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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 蛙符「涂有鲜血的赤蛙塚」
	/// 这个技能释放后拿回手中。
	/// 将目标技能放回牌库最下方。那之后，选择 - 重复释放1次，然后抽取1个技能，并使这个技能获得1层[苏醒]；或是什么都不做。
	/// 当这个技能获得5层[苏醒]时，放逐这个技能，将1个[祟神「赤口大人」]加入手中。
	/// </summary>
    public class S_Suwako_Rare_3:Skill_Extended, IP_SkillSelfLeaveHand
    {
        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = false;
            if (ExceptSkill == this.MySkill)
            {
                isLucyD = true;
            }
            return isLucyD;
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;

                if (BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Suwako_Rare3());
                    return;
                }
            }
        }

        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);
            
            BattleSystem.DelayInputAfter(CustomMethods.I_SkillBackToDeck(Targets[0], -1, true));

            BattleSystem.instance.TargetSelecting = true;
            BattleSystem.instance.SelectedSkill = this.MySkill;
            BattleSystem.instance.ActionAlly = (this.MySkill.Master as BattleAlly);
            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Suwako_Rare_3_1", this.MySkill.Master, this.MySkill.Master.MyTeam));
            list.Add(Skill.TempSkill("S_Suwako_Rare_3_2", this.MySkill.Master, this.MySkill.Master.MyTeam));
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, true, false, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Skill skill = new Skill();
            skill = Mybutton.Myskill.CloneSkill(true, null, null, true);
            ChildClear.Clear(BattleSystem.instance.ActWindow.ItemSkillView);
            GameObject gameObject = ToolTipWindow.SkillToolTip(BattleSystem.instance.ActWindow.ItemSkillView, skill, skill.Master, 0, 1, true, false, false);
            gameObject.transform.SetParent(BattleSystem.instance.ActWindow.ItemSkillView);
            gameObject.transform.Find("PlusTooltip").gameObject.SetActive(false);
            gameObject.GetComponent<SkillToolTip>().LayerDown();
            skill.OriginalSelectSkill = BattleSystem.instance.SelectedSkill;
            BattleSystem.instance.ActionAlly = (Mybutton.Myskill.Master as BattleAlly);
            ToolTipWindow.ToolTip = null;
            BattleSystem.instance.ItemSelect = true;
            BattleSystem.instance.TargetSelect(skill, skill.Master);
        }

        public bool SelfLeaveHand(bool isUsed)
        {
            if (isUsed)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum == 5)
                {
                    this.MySkill.isExcept = true;

                    Skill tmpSkill = Skill.TempSkill("S_Suwako_Rare_3_0", this.BChar, this.BChar.MyTeam);
                    Skill_Extended se = new Skill_Extended();
                    se.PlusSkillStat.Penetration = 100f;
                    se.IsDamage = true;
                    tmpSkill.ExtendedAdd(se);
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

                    return true;
                }
                else
                {
                    //BattleSystem.instance.AllyTeam.Skills.Add(this.MySkill);
                    return false;
                }
            }
            
            return true;
        }

        public override string DescExtended(string desc)
        {
            int num = 0;
            if (BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>() != null)
            {
                num = BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum;
            }
            string str = "";
            str = ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text" + num);

            if (!BattleSystem.instance)
            {
                return base.DescExtended(desc).Replace("&a", num.ToString()).Replace("&b", str);
            }
            
            return base.DescExtended(desc).Replace("&a", BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum.ToString()).Replace("&b", str);
        }
    }
}
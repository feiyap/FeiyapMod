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
namespace Kirito
{
	/// <summary>
	/// 桐谷和人
	/// Passive:
	/// 我还能更快：每次使用自己的技能，手中自己的技能费用-1。
	/// 后宫团：战斗开始时，从下列效果中选择1个触发：
	/// -亚丝娜：获得+10%命中率。每使用3次技能后优先抽1张自己的技能，恢复1点法力值。回合结束时，获得1层[准备开饭]：回合开始时，消耗1层恢复5点体力。
	/// -诗乃：获得+10%暴击率+10%暴击伤害。每使用3次技能后触发1次[狙击支援]，并获得1层[刀劈子弹]：闪避1次攻击。
	/// -尤吉欧：获得+40%无法战斗抵抗。战斗开始时，获得[蓝蔷薇之剑]：对敌人造成伤害时附加1层[冻伤]。回合结束时，根据场上[冻伤]层数恢复2x层数体力。7层时清空所有冻伤，将1张[绽放吧！蓝蔷薇]加入手中。；如果桐人进入濒死状态，[蓝蔷薇之剑]转变为[血色蔷薇之剑]：攻击力+40%。每次攻击恢复100%攻击力体力。
	/// </summary>
    public class P_Kirito:Passive_Char, IP_BattleStart_Ones, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Asuna_P", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Shino_P", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Eugeo_P", this.BChar, this.BChar.MyTeam));
            foreach (Skill skill in list)
            {
                skill.DelObj = this.BChar;
            }
            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Asuna_P")
            {
                Skill skill = Skill.TempSkill("S_Asuna_P", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
                return;
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Shino_P")
            {
                Skill skill2 = Skill.TempSkill("S_Shino_P", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
                return;
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Eugeo_P")
            {
                Skill skill3 = Skill.TempSkill("S_Eugeo_P", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill3, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
                return;
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && skill.Master == this.BChar)
            {
                if (skill.MySkill.KeyID == "S_Kirito_7" || skill.MySkill.KeyID == "S_Public_29" || skill.MySkill.KeyID == "S_Sizz_0")
                {
                    return;
                }
                foreach (Skill skill2 in BattleSystem.instance.AllyTeam.Skills)
                {
                    if (skill2.Master == this.BChar && skill2 != skill)
                    {
                        Extended_Lucy_3_1 extended = new Extended_Lucy_3_1();
                        skill2.ExtendedAdd(extended);
                    }
                }
            }
        }
    }
}
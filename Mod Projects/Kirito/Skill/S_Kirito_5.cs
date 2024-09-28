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
	/// 绝命重击
	/// 每使用1张自己的技能，倒计时-1。依据选择的后宫团成员获得额外效果：
	/// -亚丝娜：降低1点费用。打出时选择1张手中的技能，生成一张附带放逐的复制，放入牌堆最上方。
	/// -诗乃：触发1次100%暴击的[狙击支援]，并且依据溢出的暴击率，额外造成%a伤害。
	/// -尤吉欧：生成1张[绽放吧！蓝蔷薇]加入手中，恢复1点法力值。
	/// </summary>
    public class S_Kirito_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                List<Skill> list = new List<Skill>();
                list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
            }

            if (this.BChar.BuffFind("B_Shino_P", false))
            {
                BattleSystem.DelayInputAfter(this.Ienum());
            }

            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                Skill tmpSkill = Skill.TempSkill("S_Eugeo_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }
        }

        public void Del(SkillButton Mybutton)
        {
            Skill skill2 = Mybutton.Myskill.CloneSkill(true, null, null, true);
            skill2.isExcept = true;
            this.BChar.MyTeam.Skills_Deck.Insert(0, skill2);
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Shino_0", this.BChar, this.BChar.MyTeam);
            skill.ExtendedAdd("SE_Shino_5");
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }
    }
}
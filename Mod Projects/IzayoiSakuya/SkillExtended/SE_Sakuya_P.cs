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
namespace IzayoiSakuya
{
	/// <summary>
	/// 月魔术
	/// </summary>
    public class SE_Sakuya_P:Skill_Extended
    {
        public bool flag;
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            flag = false;
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || this.MySkill == BattleSystem.instance.AllyTeam.Skills[0]
                    || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null
                    || this.BChar.BuffFind("B_Sakuya_12Rare"))
                {
                    flag = true;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.flag)
            {
                checkLunaMagicEffect();
            }
        }

        public void checkLunaMagicEffect()
        {
            //回费
            if (this.BChar.BuffFind("B_Sakuya_12Rare"))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            //抽卡
            if (this.BChar.BuffFind("B_Sakuya_5_new"))
            {
                BattleSystem.instance.AllyTeam.Draw();
            }

            //伤害
            if (this.BChar.BuffFind("B_Sakuya_4_new"))
            {
                Skill skill2 = Skill.TempSkill("S_Sakuya_4_new", this.BChar, this.BChar.MyTeam);
                skill2.isExcept = true;
                skill2.FreeUse = true;
                skill2.PlusHit = true;
                BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
            }
        }
    }
}
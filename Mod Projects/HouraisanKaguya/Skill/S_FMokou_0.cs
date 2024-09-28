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
namespace HouraisanKaguya
{
	/// <summary>
	/// 不死「火鸟　-凤翼天翔-」
	/// 倒计时3后，再次释放不死「火鸟　-凤翼天翔-」。
	/// </summary>
    public class S_FMokou_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (!this.MySkill.FreeUse)
            {
                List<BattleChar> list = new List<BattleChar>();
                Skill skill = Skill.TempSkill("S_FMokou_0", this.BChar, this.BChar.MyTeam);
                skill.FreeUse = true;
                //skill.Counting = 3;
                list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);
            }

            if (this.BChar.BuffFind("B_Mokou_T_1"))
            {
                this.BChar.BuffReturn("B_Mokou_T_1").SelfDestroy();
            }
        }
    }
        
}
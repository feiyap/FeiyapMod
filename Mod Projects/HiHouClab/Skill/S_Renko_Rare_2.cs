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
namespace HiHouClab
{
	/// <summary>
	/// G Free
	/// 生成1个目标的复制体。复制体不会进行等待以外的行为。
	/// 对目标和复制体施加“量子纠缠”。
	/// </summary>
    public class S_Renko_Rare_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.DelayInput(BattleSystem.instance.NewEnemyAutoPos(Targets[0].Info.KeyData, Del));

            Targets[0].BuffAdd("B_Renko_5", this.BChar);
        }

        private void Del(BattleChar Input)
        {
            Input.BuffAdd("B_Renko_5", this.BChar);
            Input.BuffAdd("B_Renko_Rare_2_0", this.BChar);

            Skill tmpSkill = Skill.TempSkill("S_Idle", Input, Input.MyTeam);
            Input.Skills.Clear();
            Input.Skills.Add(tmpSkill);
        }
    }
}
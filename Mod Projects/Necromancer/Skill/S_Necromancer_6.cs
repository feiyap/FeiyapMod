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
namespace Necromancer
{
	/// <summary>
	/// 求死不得
	/// 将固定能力替换为灵魂尖啸。
	/// </summary>
    public class S_Necromancer_6:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (BChar.BuffFind("B_Necromancer_1") == true)
            {
                Skill skill = Skill.TempSkill("S_P_Necromancer_0", BChar, BChar.MyTeam);

                (BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
            } 
        }
    }
}
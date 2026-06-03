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
namespace FeiyapTank
{
	/// <summary>
	/// 嬉笑魔女
	/// </summary>
    public class Boss_FeiyapMage:AI
    {
        public override Skill SkillSelect(int ActionCount)
        {
            if (ActionCount == 0)
            {
                return this.BChar.Skills[0];
            }
            else if (ActionCount == 1)
            {
                return this.BChar.Skills[1];
            }
            else if (ActionCount == 2)
            {
                return this.BChar.Skills[2];
            }
            return this.BChar.Skills[0];
        }

        public override List<BattleChar> TargetSelect(Skill SelectedSkill)
        {
            return base.TargetSelect(SelectedSkill);
        }
    }
}
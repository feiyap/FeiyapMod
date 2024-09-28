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
namespace Rumia
{
	/// <summary>
	/// 露米娅
	/// </summary>
    public class Rumia_Feiyap:AI
    {
        public override int SpeedChange(Skill skill, int ActionCount, int OriginSpeed)
        {
            if (ActionCount == 0)
            {
                return 1;
            }
            return base.SpeedChange(skill, ActionCount, OriginSpeed);
        }

        public override Skill SkillSelect(int ActionCount)
        {
            if (ActionCount == 1)
            {
                return this.BChar.Skills[1];
            }
            return this.BChar.Skills[RandomManager.RandomInt(this.BChar.GetRandomClass().SkillSelect, 0, 2)];
        }
    }
}
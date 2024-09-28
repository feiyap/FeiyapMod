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
namespace Reisen
{
	/// <summary>
	/// 爆炸！
	/// </summary>
    public class S_Reisen_12Rare_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0;i<Targets.Count;i++)
            {
                int dmg = (int)(Targets[i].GetStat.maxhp * 1.0f);
                if (dmg > 900)
                {
                    dmg = 900;
                }
                Targets[i].Damage(this.BChar, dmg, false, true, false, 0, false, false, false);
            }
            this.BChar.Damage(this.BChar, (int)(this.BChar.GetStat.maxhp * 1.0f), false, true, false, 0, false, false, false);
        }
    }
}
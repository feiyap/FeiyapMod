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
namespace FeiyapBoss
{
	/// <summary>
	/// 烤全鸭
	/// </summary>
    public class S_BurnFullDuck:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            MasterAudio.PlaySound("Food Eat 02", 1f, null, 0f, null, null, false, false);
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar.Info.Incapacitated)
                {
                    battleChar.Info.Incapacitated = false;
                    battleChar.HP = 0;
                }

                battleChar.Heal(BattleSystem.instance.DummyChar, (float)((int)Misc.PerToNum((float)battleChar.Info.get_stat.maxhp, 100f)), false, true, null);
            }
        }
    }
}
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
namespace SatsukiRin
{
	/// <summary>
	/// 打出时立刻受到冴月麟50%治疗量的恢复。
	/// </summary>
    public class SE_Satsuki_2:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.AP >= 1;
        }
        
        public override void SkillUseHand(BattleChar Target)
        {
            BattleChar battleChar = null;
            BattleChar battleChar2 = null;
            foreach (BattleChar battleChar3 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar3.Info.KeyData == "SatsukiRin")
                {
                    battleChar2 = battleChar3;
                    break;
                }
            }
            if (battleChar2.IsDead)
            {
                return;
            }
            foreach (BattleChar battleChar4 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar == null)
                {
                    battleChar = battleChar4;
                }
                else if (battleChar != null && battleChar.HP > battleChar4.HP)
                {
                    battleChar = battleChar4;
                }
            }

            battleChar.Heal(this.BChar, (int)Misc.PerToNum(battleChar2.GetStat.reg, 50f), false, false, null);
        }
    }
}
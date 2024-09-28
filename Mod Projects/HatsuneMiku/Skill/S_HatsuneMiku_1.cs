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
namespace HatsuneMiku
{
	/// <summary>
	/// ロミオトシンデレラ
	/// 为己方HP最低的角色治疗%a，施加1层[未来之音]。
	/// 音律3：超额治疗自己%b，为自己施加1层[未来之音]。
	/// 音律9：对随机敌人再次释放一次。
	/// </summary>
    public class S_HatsuneMiku_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.TargetBuff = null;

            BattleChar battleChar = null;
            foreach (BattleChar battleChar2 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar == null)
                {
                    battleChar = battleChar2;
                }
                else if (battleChar != null && battleChar.HP > battleChar2.HP)
                {
                    battleChar = battleChar2;
                }
            }
            if (battleChar != null)
            {
                battleChar.Heal(this.BChar, (int)(this.BChar.GetStat.reg * 1.0f), false, false, null);
                battleChar.BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 3)
            {
                this.BChar.Heal(this.BChar, (int)(this.BChar.GetStat.reg * 1.0f), false, true, null);
                    this.BChar.BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 9 && SkillD.isExcept != true)
            {
                Skill skill2 = SkillD.CloneSkill(true, SkillD.Master, null, false);
                skill2.isExcept = true;
                BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 1.0f)).ToString()).Replace("&b", ((int)(this.BChar.GetStat.reg * 1.0f)).ToString());
        }
    }
}
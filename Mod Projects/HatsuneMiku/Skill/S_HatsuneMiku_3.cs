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
	/// 千本桜
	/// 每命中1个敌人，为自己施加2层[未来之音]。
	/// 音律3：额外造成%a伤害。
	/// 音律9：再次释放一次。
	/// </summary>
    public class S_HatsuneMiku_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.TargetBuff = null;
            this.SelfBuff = null;

            for (int i = 0; i < Targets.Count; i++)
            {
                this.BChar.BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 3)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.35f);
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 9)
            {
                if (!this.MySkill.isExcept)
                {
                    Skill skill2 = SkillD.CloneSkill(true, SkillD.Master, null, false);
                    skill2.isExcept = true;
                    BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.55f)).ToString());
        }
    }
}
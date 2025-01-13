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
namespace IzayoiSakuya
{
	/// <summary>
	/// 伤符「铭刻于红魂」
	/// 以倒计时3重复释放1次。
    /// <color=#4169E1>月魔术</color> - 以倒计时5重复释放1次。
	/// </summary>
    public class S_Sakuya_2: SkillExtended_Sakuya
    {
        public override void SkillUseHand(BattleChar Target)
        {
            base.SkillUseHand(Target);
            Skill skill = Skill.TempSkill("S_Sakuya_2_0", this.BChar, this.BChar.MyTeam);
            skill.Counting = 3;
            BattleTeam.SkillRandomUse(this.BChar, skill, false, true, false);

            if (CheckLunaMagic())
            {
                Skill skill2 = Skill.TempSkill("S_Sakuya_2_0", this.BChar, this.BChar.MyTeam);
                skill2.Counting = 5;
                BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
            }
        }

    }
}
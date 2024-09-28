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
	/// 幻红符「永恒红昼狂想曲」
	/// 恢复所有体力至上限。生成1张[时符「调换魔法」]加入手中。
	/// </summary>
    public class S_Sakuya_14Rare:Skill_Extended
    {
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.BChar.Heal(this.BChar, (float)((int)((float)DMG * 0.5f)), this.BChar.GetCri(), true, null);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Sakuya_0_0", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            this.BChar.BuffAdd("B_RemiliaScarlet_5", this.BChar);
        }
    }
}
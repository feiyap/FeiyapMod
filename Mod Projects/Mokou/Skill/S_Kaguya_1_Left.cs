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
namespace Mokou
{
	/// <summary>
	/// 神宝「耀眼的龙玉」
	/// 使用后，继续对目标左边的角色使用此技能，但是技能倍率减少25%，重复3次。
	/// </summary>
    public class S_Kaguya_1_Left:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.EnemyPreviewNoArrow = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.DelayInput(this.Damage1(Targets[0].MyLeftCharReturn()));
            BattleSystem.DelayInput(this.Damage2(Targets[0].MyLeftCharReturn().MyLeftCharReturn()));
            BattleSystem.DelayInput(this.Damage3(Targets[0].MyLeftCharReturn().MyLeftCharReturn().MyLeftCharReturn()));
            return;
        }
        public IEnumerator Damage1(BattleChar Target)
        {
            Skill skill = Skill.TempSkill("S_Kaguya_1_0", this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(skill, Target);
            yield return new WaitForSecondsRealtime(0.2f);
            yield break;
        }
        public IEnumerator Damage2(BattleChar Target)
        {
            Skill skill = Skill.TempSkill("S_Kaguya_1_1", this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(skill, Target);
            yield return new WaitForSecondsRealtime(0.2f);
            yield break;
        }
        public IEnumerator Damage3(BattleChar Target)
        {
            Skill skill = Skill.TempSkill("S_Kaguya_1_2", this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(skill, Target);
            yield return new WaitForSecondsRealtime(0.2f);
            yield break;
        }
    }
}
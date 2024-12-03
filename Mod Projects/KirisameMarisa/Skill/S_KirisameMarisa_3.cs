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
namespace KirisameMarisa
{
	/// <summary>
	/// 魔符「Milky Way」
	/// </summary>
    public class S_KirisameMarisa_3: SkillBase_KirisameMarisa
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int count = 3;
            BattleSystem.DelayInput(this.Effect(Targets[0], count));
        }

        public IEnumerator Effect(BattleChar Target, int Count)
        {
            yield return new WaitForSeconds(0.15f);
            int num;
            for (int i = 0; i < Count; i = num + 1)
            {
                if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
                {
                    Skill skill = Skill.TempSkill("S_KirisameMarisa_3", this.BChar, this.BChar.MyTeam);
                    skill.PlusHit = true;
                    this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
                }
                yield return new WaitForSeconds(0.1f);
                num = i;
            }
            yield break;
        }
    }
}
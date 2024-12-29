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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天符「天道是非之剑」
	/// 自身获得随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// <color=#97FFFF>天启8</color> - 使所有队友获得随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// </summary>
    public class S_Tenshi_0: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(8, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckKishi(8, false))
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    AddTenki(bc, 1);
                    BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi++;
                }
            }
            else
            {
                AddTenki(this.BChar, 1);
            }
        }
    }
}
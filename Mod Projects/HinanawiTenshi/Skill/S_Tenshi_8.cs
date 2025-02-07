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
	/// 剑技「气焰万丈之剑」
	/// <color=#97FFFF>天启2</color> - 将自己持有的所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>施加给其他队友。
	/// </summary>
    public class S_Tenshi_8: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(2, true))
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
            base.SkillUseSingle(SkillD, Targets);

            if (CheckKishi(2, false))
            {
                foreach (String str in tenkiList)
                {
                    if (this.BChar.BuffFind(str))
                    {
                        foreach (BattleChar bc in BattleSystem.instance.AllyList)
                        {
                            bc.BuffAdd(str, this.BChar);
                        }
                        BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi++;
                    }
                }
            }
        }
    }
}
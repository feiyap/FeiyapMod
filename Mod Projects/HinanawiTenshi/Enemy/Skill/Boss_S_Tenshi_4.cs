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
	/// 气符「无念无想的境界」
	/// 解除自己持有的痛苦、弱化减益。
	/// 依据解除的减益数量，获得等量的<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// </summary>
    public class Boss_S_Tenshi_4: SkillBase_Tenshi
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int count = 0;

            if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false).Count != 0)
            {
                List<Buff> list = new List<Buff>();
                foreach (Buff buff in this.BChar.Buffs)
                {
                    if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                    {
                        count++;
                        buff.SelfDestroy();
                    }
                }
            }

            if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count != 0)
            {
                List<Buff> list = new List<Buff>();
                foreach (Buff buff in this.BChar.Buffs)
                {
                    if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                    {
                        count++;
                        buff.SelfDestroy();
                    }
                }
            }

            AddTenki(this.BChar, count);
        }
    }
}
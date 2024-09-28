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
namespace Sunmeitian
{
	/// <summary>
	/// 猴子猴孙
	/// 敌人每次行动前，对其造成&a(100%)伤害。
	/// </summary>
    public class B_Sunmeitian_11Rare:Buff, IP_TargetedAlly
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 1.0)).ToString());
        }
        
        public override void Init()
        {
            base.Init();
        }

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            using (List<BattleChar>.Enumerator enumerator = SaveTargets.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Info.Ally)
                    {
                        Skill skill2 = Skill.TempSkill("S_Sunmeitian_11Rare_0", base.Usestate_L, base.Usestate_L.MyTeam);
                        skill2.PlusHit = true;
                        skill2.FreeUse = true;
                        this.BChar.ParticleOut(skill2, Attacker);
                        yield return new WaitForSeconds(0.2f);
                        break;
                    }
                }
            }
            List<BattleChar>.Enumerator enumerator2 = default(List<BattleChar>.Enumerator);
            yield break;
            yield break;
        }
    }
}
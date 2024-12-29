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
	/// 黑魔「Event Horizon」
	/// </summary>
    public class S_KirisameMarisa_2_4: SkillBase_KirisameMarisa, IP_DamageChange_sumoperation
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3f)).ToString());
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int count = 0;

            List<CastingSkill>.Enumerator enumerator2 = (Target as BattleEnemy).SkillQueue.GetEnumerator();

            while (enumerator2.MoveNext())
            {
                if (enumerator2.Current.CastSpeed != 0)
                {
                    count = enumerator2.Current.CastSpeed;
                    break;
                }
            }

            if (count > 9)
            {
                count = 9;
            }

            PlusDamage = (int)(this.BChar.GetStat.atk * 0.3f) * count;
        }
    }
}
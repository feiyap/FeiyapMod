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
namespace Kirito
{
	/// <summary>
	/// 绽放吧！蓝蔷薇
	/// </summary>
    public class S_Eugeo_0:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 3.0));
            }
        }

        public override void Init()
        {
            base.Init();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            //this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            Targets[0].Damage(this.BChar, this.PlusDmg, false, true, true, 0, false, false, false);
            BattleSystem.DelayInputAfter(this.Damage());
        }

        public IEnumerator Damage()
        {
            MasterAudio.PlaySound("SE_AcidEffect", 1f, null, 0f, null, null, false, false);
            Buff buff = this.BChar.BuffAdd(GDEItemKeys.Buff_B_Momori_P_NoDead, this.BChar);
            this.BChar.Damage(this.BChar, this.PlusDmg / 2, false, true, true, 0, false, false, false);
            buff.SelfDestroy();
            yield return new WaitForSecondsRealtime(0.3f);
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
    }
}
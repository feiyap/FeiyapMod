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
	/// 操控永远程度的能力
	/// </summary>
    public class SP_Kaguya_ChangePhase:Skill_Extended, IP_ParticleOut_After
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public IEnumerator ParticleOut_After(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.MainP.Phase != 0)
            {
                this.BChar.Heal(this.BChar, (float)this.BChar.GetStat.maxhp, false, true, null);
                if (this.BChar.HP != this.BChar.GetStat.maxhp)
                {
                    this.BChar.HP = this.BChar.GetStat.maxhp;
                }
                this.MainP.Phase += 1;
                this.MainP.PhaseEnd = false;
            }
            yield return null;
            yield break;
        }
        public B_Kaguya_P MainP
        {
            get
            {
                if (this._MainP == null)
                {
                    this._MainP = (this.BChar.BuffReturn("B_Kaguya_P", false) as B_Kaguya_P);
                }
                return this._MainP;
            }
        }
        private B_Kaguya_P _MainP;
    }
}
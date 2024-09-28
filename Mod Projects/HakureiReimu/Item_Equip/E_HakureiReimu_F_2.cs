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
namespace HakureiReimu
{
	/// <summary>
	/// 阴阳玉
	/// </summary>
    public class E_HakureiReimu_F_2:EquipBase, IP_PlayerTurn, IP_Kill
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 15;
            this.PlusStat.hit = 10;
        }

        public void Turn()
        {
            this.BChar.BuffAdd("B_HakureiReimu_F_E_2", this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd("B_HakureiReimu_F_E_2", this.BChar, false, 0, false, -1, false);
        }

        public void KillEffect(SkillParticle SP)
        {
            if (SP.UseStatus == this.BChar)
            {
                this.BChar.BuffAdd("B_HakureiReimu_F_E_2", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_HakureiReimu_F_E_2", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}
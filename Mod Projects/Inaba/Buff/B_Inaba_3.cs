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
namespace Inaba
{
	/// <summary>
	/// 因幡/花开
	/// 每次受到追加攻击/反击时，减益抵抗率-5%。
	/// </summary>
    public class B_Inaba_3:Buff, IP_Hit
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_CC = 0;
            this.PlusStat.RES_DEBUFF = 0;
            this.PlusStat.RES_DOT = 0;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (SP.SkillData.PlusHit)
            {
                count++;
                this.PlusStat.RES_CC = -5 * count;
                this.PlusStat.RES_DEBUFF = -5 * count;
                this.PlusStat.RES_DOT = -5 * count;
            }
        }
    }
}
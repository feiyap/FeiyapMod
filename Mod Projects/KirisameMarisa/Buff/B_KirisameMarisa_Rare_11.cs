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
	/// 危险升空！
	/// 无敌。
	/// </summary>
    public class B_KirisameMarisa_Rare_11:Buff, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.MySkill.KeyID == "S_KirisameMarisa_Rare_11")
            {
                base.SelfDestroy(false);
                this.BChar.BuffRemove("B_KirisameMarisa_Rare_11", false);
            }
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.invincibility = true;
            this.PlusStat.Stun = true;
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.Usestate_L.IsDead)
            {
                base.SelfDestroy(false);
            }
        }
    }
}
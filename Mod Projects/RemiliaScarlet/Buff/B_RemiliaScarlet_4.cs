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
namespace RemiliaScarlet
{
    /// <summary>
    /// 吸血鬼幻想
    /// </summary>
    public class B_RemiliaScarlet_4 : Buff, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.MySkill.KeyID == "S_RemiliaScarlet_5")
            {
                base.SelfDestroy(false);
                this.BChar.BuffRemove("B_RemiliaScarlet_4", false);
            }
        }

        public override void BuffStat()
        {
            base.BuffStat();
            this.PlusStat.DMGTaken = -50f;
            this.PlusStat.RES_DOT = 100f;
            this.PlusStat.RES_CC = 100f;
            this.PlusStat.RES_DEBUFF = 100f;
            this.PlusStat.DeadImmune = 50;
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
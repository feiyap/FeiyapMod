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
namespace IzayoiSakuya
{
	/// <summary>
	/// 幻在「钟表的残骸」
	/// </summary>
    public class B_Sakuya_3:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 15f;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.MySkill.KeyID == "S_Sakuya_3")
            {
                base.SelfDestroy(false);
                this.BChar.BuffRemove("B_Sakuya_3", false);
            }
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
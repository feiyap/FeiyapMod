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
namespace HouraisanKaguya
{
	/// <summary>
	/// 神宝「无限的生命之泉」
	/// 神宝 - 可以在无法行动时使用。解除所有干扰减益。
	/// </summary>
    public class S_FKaguya_7:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.CanUseStun = false;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                base.SkillParticleOn();
                this.CanUseStun = true;
            }
            else
            {
                base.SkillParticleOff();
                this.CanUseStun = false;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            this.BChar.BuffAdd("B_FKaguya_7", this.BChar, false, 0, false, -1, false);

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count != 0)
                {
                    List<Buff> list = new List<Buff>();
                    foreach (Buff buff in this.BChar.Buffs)
                    {
                        if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && buff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_CrowdControl && !buff.BuffData.Hide && !buff.DestroyBuff)
                        {
                            buff.SelfDestroy();
                        }
                    }
                }
            }

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                this.BChar.BuffReturn("B_FKaguya_Sinnpou").SelfDestroy();
                BattleSystem.instance.AllyTeam.AP += 2;
            }
        }
    }
}
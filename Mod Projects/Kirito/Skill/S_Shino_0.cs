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
	/// 狙击支援
	/// </summary>
    public class S_Shino_0:Skill_Extended, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.IsDamage && Cri)
            {
                this.BChar.BuffAdd("S_Shino_0_1", this.BChar, false, 0, false, -1, false);
            }
        }

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                int num = 0;
                if (this.BChar.BuffFind("B_Shino_0", false))
                {
                    num = this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * num * 0.17f));
            }
        }

        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }
    }
}
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
namespace Eirin
{
	/// <summary>
	/// 天呪「Apollo 13」
	/// 每次使用手中的技能时，或是自身或队友触发追加攻击/反击时，这个技能费用-1。
	/// </summary>
    public class S_Eirin_10Rare:Skill_Extended, IP_SkillUse_Team
    {
        public override void Init()
        {
            base.Init();
            this.UseNum = 0;
        }
        
        public override void FixedUpdate()
        {
            this.APChange = -this.UseNum;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.UseNum = 0;

            foreach (BattleChar bc in Targets)
            {
                bc.Heal(this.BChar, bc.GetStat.maxhp, false, true);
            }
        }
        
        public void SkillUseTeam(Skill skill)
        {
            this.UseNum++;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (!hit.Info.Ally && (SP.SkillData.PlusHit || SP.SkillData.ExtendedFind("Lian_Ex_Counter", true) != null))
            {
                this.UseNum++;
            }
        }

        public int UseNum;
    }
}
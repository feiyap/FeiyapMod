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
namespace HinanawiTenshi
{
	/// <summary>
	/// 云天
	/// </summary>
    public class SE_Tenki_3:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.NoClone = true;
            if (BattleSystem.instance.AllyTeam.Skills.Count != 0 && this.MySkill.MySkill.Effect_Target != null)
            {
                if (this.MySkill.TargetDamageOriginal != 0)
                {
                    this.SkillBaseFinal.Target_BaseDMG = 6;
                    return;
                }
                if (this.MySkill.TargetHealOriginal != 0)
                {
                    this.SkillBaseFinal.Target_BaseHeal = 6;
                }
            }
        }
        
        public override void FixedUpdate()
        {
            if (!this.Use && !this.MySkill.IsNowCasting)
            {
                base.FixedUpdate();
                if (BattleSystem.instance.AllyTeam.Skills.Count != 0 && BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1] != this.MySkill && BattleSystem.instance.AllyTeam.Skills[0] != this.MySkill)
                {
                    this.SelfDestroy();
                }
                if ((this.BChar.MyTeam.AliveChars.Find((BattleChar a) => a.BuffFind("B_Tenki_3", false)) == null))
                {
                    this.SelfDestroy();
                }
            }
        }
        
        public override void SkillUseHand(BattleChar Target)
        {
            this.Use = true;
        }
        
        private bool Use;
    }
}
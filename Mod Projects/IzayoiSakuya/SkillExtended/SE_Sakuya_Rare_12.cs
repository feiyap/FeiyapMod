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
	/// 完美女仆
	/// </summary>
    public class SE_Sakuya_Rare_12:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.NotCount = true;
            this.NoClone = true;
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
                if ((this.BChar.MyTeam.AliveChars.Find((BattleChar a) => a.BuffFind("B_Sakuya_12Rare", false)) == null))
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
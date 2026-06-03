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
namespace FeiyapTank
{
	/// <summary>
	/// 绯樱狱华落
	/// </summary>
    public class S_FeiyapTank_Rare_2:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                int count = 0;
                if (this.BChar.HP < 1)
                {
                    count = 1 - this.BChar.HP;
                }
                return (int)((this.BChar.GetStat.atk * (int)(Math.Pow(count, 2)) * 0.01));
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.HP < 1)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
            else
            {
                this.SkillBasePlus.Target_BaseDMG = 0;
            }
        }

        public override bool Terms()
        {
            return base.Terms() && this.BChar.HP < 1;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
    }
}
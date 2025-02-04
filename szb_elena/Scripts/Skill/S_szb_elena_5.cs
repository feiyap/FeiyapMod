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
namespace szb_elena
{
	/// <summary>
	/// 温情的兔耳治愈师
	/// 爆能强化3 - 额外治疗&a体力(治疗力的105%)。抽取2个技能。
	/// </summary>
    public class S_szb_elena_5:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 1.05)).ToString());
        }
        public override void FixedUpdate()
        {
            if (!this.useflag)
            {
                base.FixedUpdate();
                if (this.BChar.MyTeam.AP >= 3)
                {
                    this.isSpecies = true;
                    this.APChange = 2;
                }
                else
                {
                    this.isSpecies = false;
                    this.APChange = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.useflag = true;
            if (this.isSpecies)
            {
                this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg * 1.05);
                BattleSystem.instance.AllyTeam.Draw(2);
                //this.BChar.Heal(this.BChar, (float)(this.BChar.GetStat.reg * 0.6), false, false, null);
            }
        }
        private bool useflag;
        private bool isSpecies;
    }
}
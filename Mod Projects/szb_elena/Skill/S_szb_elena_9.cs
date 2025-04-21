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
	/// 仁爱光芒
	/// 恢复所有调查员&a体力(治疗力的60%)。抽取1个技能。
	/// 爆能强化4 - 造成额外&b伤害(攻击力的60%)，额外治疗&c体力(治疗力的60%)，额外抽取1个技能。
	/// </summary>
    public class S_szb_elena_9:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 0.6)).ToString()).Replace("&b", ((int)(this.BChar.GetStat.atk * 0.6)).ToString()).Replace("&c", ((int)(this.BChar.GetStat.reg * 0.6)).ToString());
        }
        public override void FixedUpdate()
        {
            if (!this.useflag)
            {
                base.FixedUpdate();
                if (this.BChar.MyTeam.AP >= 4)
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
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.6);
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    battleChar.Heal(this.BChar, (float)(this.BChar.GetStat.reg * 1.2), false, false, null);
                }
                BattleSystem.instance.AllyTeam.Draw(2);
            }
            else 
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    battleChar.Heal(this.BChar, (float)(this.BChar.GetStat.reg * 0.6), false, false, null);
                }
                BattleSystem.instance.AllyTeam.Draw();
            }
        }

        private bool useflag;
        private bool isSpecies;
    }
}
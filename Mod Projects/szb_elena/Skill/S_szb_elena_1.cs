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
	/// 漆黑法典
	/// 如果目标生命值低于&a(攻击力的70%)，立即死亡
	/// </summary>
    public class S_szb_elena_1:Skill_Extended,IP_ParticleOut_Before
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a",((int)(this.BChar.GetStat.atk * 0.7)).ToString());
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
           

        }

       public void ParticleOut_Before(Skill SkillD, List<BattleChar> Targets) 
        {

            if (Targets[0].HP < this.BChar.GetStat.atk * 0.7 && !Targets[0].Info.Ally)
            {
                Targets[0].HP = 0;
            }
        }
    }
}
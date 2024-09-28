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
namespace FlandreScarlet
{
	/// <summary>
	/// 红魔符「Bloody Catastrophe」
	/// 击杀敌人后，回复2点法力值，获得永久2点最大体力值和1%暴击率加成。
	/// </summary>
    public class S_FlandreScarlet_14Rare:Skill_Extended
    {
        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            if (!this.BChar.BuffFind("B_FlandreScarlet_12Rare", false))
            {
                this.BChar.Info.OriginStat.maxhp += 2;
                this.BChar.Info.OriginStat.cri += 1;
                this.BChar.Info.OriginStat.HEALTaken += 2;
                this.BChar.Info.OriginStat.PlusCriDmg += 3;
                this.BChar.BuffAdd("B_FlandreScarlet_12Rare", this.BChar);
            }
            this.BChar.MyTeam.AP += 2;
        }
    }
}
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
namespace HakureiReimu
{
    /// <summary>
    /// 红灵符「翱翔天际丶绯色夜空」
    /// *「梦想天生」+神枪「冈格尼尔之枪」
    /// 自身每有1层[吸血鬼之心]，额外造成20%伤害。这个技能击杀敌人时，获得永久3%暴击率，恢复2点法力值。
    /// </summary>
    public class S_Musoutensei_Remilia: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            
            if (this.BChar.BuffFind("B_RemiliaScarlet_5"))
            {
                this.SkillBasePlus.Target_BaseDMG = this.BChar.BuffReturn("B_RemiliaScarlet_5").StackNum * 20 * this.MySkill.MySkill.Effect_Target.DMG_Per / 100;
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            this.BChar.Info.OriginStat.cri += 2;
            this.BChar.MyTeam.AP += 2;
        }
    }
}
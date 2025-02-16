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
namespace Yuyuko
{
	/// <summary>
	/// 「待宵反射卫星斩」
	/// 受到下一次伤害时以等额伤害反击，触发时移除1层。
	/// </summary>
    public class B_YoumuF_2:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
        }
        
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (!SP.UseStatus.IsLucy && !SP.UseStatus.Dummy)
            {
                Skill skill = Skill.TempSkill(GDEItemKeys.Skill_S_Blade_1, this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                skill.MySkill.Effect_Target.DMG_Base = Dmg;
                this.BChar.ParticleOut(skill, SP.UseStatus);
            }
            else if (SP.UseStatus.IsLucyC)
            {
                Skill skill2 = Skill.TempSkill(GDEItemKeys.Skill_S_Blade_1, this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                skill2.MySkill.Effect_Target.DMG_Base = Dmg;
                this.BChar.ParticleOut(skill2, SP.UseStatus);
            }
            SelfStackDestroy();
        }
    }
}
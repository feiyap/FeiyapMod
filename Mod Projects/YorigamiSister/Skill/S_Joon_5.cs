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
namespace YorigamiSister
{
	/// <summary>
	/// 朱莉安娜羽扇回旋镖
	/// 倒计时期间，自身对这个技能指向的目标始终暴击。
	/// 这个技能暴击时，以倒计时2重复释放 1 次，不会再次重复释放。
	/// </summary>
    public class S_Joon_5:Skill_Extended, IP_DamageChange, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public BattleChar targetBC;

        public override void Init()
        {
            base.Init();
            targetBC = null;
            this.OnePassive = true;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            ThisSkill.Target.BuffAdd("B_Joon_5", this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            ThisSkill.Target.BuffReturn("B_Joon_5")?.SelfDestroy();
            targetBC = null;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (View)
            {
                return Damage;
            }
            if (Cri)
            {
                Skill skill = Skill.TempSkill("S_Joon_5_0", this.BChar, this.BChar.MyTeam);
                skill.Counting = 2;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, targetBC, false, false, false, null));
            }

            return Damage;
        }
    }
}
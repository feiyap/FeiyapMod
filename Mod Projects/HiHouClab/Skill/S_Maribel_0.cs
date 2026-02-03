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
using BasicMethods;
namespace HiHouClab
{
    /// <summary>
    /// 魔术师梅莉
    /// 倒计时期间，这个技能指向的目标获得“可被无视嘲讽选中，无法破坏体力极限，受到的量子伤害提升30%”。
    /// </summary>
    public class S_Maribel_0 : Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit, IP_HPChange
    {
        public BattleChar m_target = null;
        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
        }
        public int PlusDmg
        {
            get
            {
                return (int)(this.BChar.GetStat.atk * 1.3f);
            }
        }
        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char == m_target && Char.HP <= PlusDmg)
            {
                foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
                {
                    if (castingSkill.skill == this.MySkill)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(castingSkill);
                        BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyCastingSkillUse(castingSkill, false));
                        BattleSystem.instance.CastSkills.Remove(castingSkill);
                    }
                }
            }
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            CustomMethods.CountingSkillNotUseTurnEnd(ThisSkill);
            ThisSkill.Target?.BuffAdd("B_Maribel_0", ThisSkill.skill.Master);
            m_target = ThisSkill.Target;
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            ThisSkill.Target?.BuffReturn("B_Maribel_0")?.SelfDestroy();
            m_target = null;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", PlusDmg.ToString());
        }
    }
}
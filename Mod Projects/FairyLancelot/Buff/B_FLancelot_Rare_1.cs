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
namespace FairyLancelot
{
	/// <summary>
	/// 湖光骑士
	/// </summary>
    public class B_FLancelot_Rare_1:Buff, IP_Kill, IP_DamageTakeChange, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = 50;
            this.PlusPerStat.MaxHP = -20;
            this.OnePassive = true;
        }

        public void KillEffect(SkillParticle SP)
        {
            if (SP.SkillData.Master == this.BChar)
            {
                this.BChar.MyTeam.AP += 2;
                this.PlusStat.dod = 70;
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit == this.BChar && Dmg >= 20 && !Preview)
            {
                this.BChar.Damage(this.BChar, 15, false, true);
                return 0;
            }

            return Dmg;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.IsDamage && skill.Master == this.BChar)
            {
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(skill.Master, skill.CloneSkill(true, skill.Master, null, false), false, false, false));
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(skill.Master, skill.CloneSkill(true, skill.Master, null, false), false, false, false));
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(skill.Master, skill.CloneSkill(true, skill.Master, null, false), false, false, false));
            }
        }
    }
}
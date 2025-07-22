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
	/// 终焉
	/// </summary>
    public class B_FLancelot_9_0:Buff, IP_SkillUseHand_Team, IP_TurnEnd
    {
        public int count = 0;

        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.IsDamage && skill.Master == this.BChar)
            {
                count++;
            }
        }

        public void TurnEnd()
        {
            for (int i = 0; i < count; i++)
            {
                Skill skill = Skill.TempSkill("S_FLancelot_9_0", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;

                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }
            count = 0;
            this.SelfDestroy();
        }
    }
}
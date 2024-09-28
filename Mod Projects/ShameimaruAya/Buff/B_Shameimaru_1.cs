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
namespace ShameimaruAya
{
	/// <summary>
	/// 风来的山麓
	/// 暴击时生成1个[北风灵]。
	/// </summary>
    public class B_Shameimaru_1:Buff, IP_SomeDealCritical
    {
        public void SomeDealCritical(BattleChar Taker, SkillParticle SP, int DMG, int HEAL)
        {
            if (SP.SkillData.Master == this.BChar)
            {
                Skill tmpSkill2 = Skill.TempSkill("S_Shameimaru_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
                this.SelfStackDestroy();
            }
        }
    }
}
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
namespace Kirito
{
	/// <summary>
	/// 黑卡蒂II
	/// </summary>
    public class B_Shino_P_1:Buff, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.IsDamage && Cri)
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
                base.SelfStackDestroy();
            }
        }
    }
}
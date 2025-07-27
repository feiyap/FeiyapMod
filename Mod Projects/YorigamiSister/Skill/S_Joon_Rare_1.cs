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
	/// 「80年代的勒索者」
	/// 这个技能暴击时，造成伤害的100%转化为金币。
	/// </summary>
    public class S_Joon_Rare_1:Skill_Extended, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData != this.MySkill)
            {
                return;
            }
            if (BattleSystem.instance.TurnNum > BattleSystem.instance.FogTurn)
            {
                return;
            }

            if (Cri)
            {
                PlayData.Gold += DMG;
                MasterAudio.PlaySound("SilverStein_Coin", 1f, null, 0f, null, null, false, false);
            }
        }
    }
}
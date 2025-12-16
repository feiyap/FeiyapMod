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
namespace CirnoBlizzard
{
    /// <summary>
    /// 圣洁之心
    /// 回合结束时，体力值变为0，失去所有体力极限，并抽取 1 个自己的技能。
    /// 使用自己的技能时解除，并获得持续 1 回合的“治疗力+10%，防御力+10%”。
    /// </summary>
    public class B_Boss_Cirno_P3_0 : Buff, IP_TurnEnd, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void TurnEnd()
        {
            this.BChar.HP = 0;
            this.BChar.Recovery = 1;
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar);
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                this.SelfDestroy();
                this.BChar.BuffAdd("B_Boss_Cirno_P3_0_2", this.BChar);
            }
        }
    }
}
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
	/// 渐强的暴风雪
	/// 回合开始时，获得“攻击力+9%”。
	/// </summary>
    public class B_Boss_Cirno_P:Buff, IP_BattleStart_Ones, IP_PlayerTurn, IP_SkillUseHand_Team
    {
        public int Phase = 1; //阶段
        public int Count = 6; //NOVA计数

        public void BattleStart(BattleSystem Ins)
        {
            Ins.BattleExtended.Add(new BattleEvent_CirnoBlizzard());
            BattleEvent_CirnoBlizzard.Boss = (this.BChar as BattleEnemy);
            BattleEvent_CirnoBlizzard.MainP = this;
            Phase = 1;
        }

        public void Turn()
        {
            this.PlusPerStat.Damage += 9;
            if (Count <= 0)
            {
                Count = 6;
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.Master.IsLucy && !skill.IsCreatedInBattle && Count > 0)
            {
                if (Count == 1)
                {
                    BattleSystem.DelayInputAfter(this.Del());
                }
                Count -= 1;
            }
        }
        
        private IEnumerator Del()
        {
            List<BattleChar> list = new List<BattleChar>();
            Skill skill = Skill.TempSkill("S_Boss_Cirno_P1_2", this.BChar, this.BChar.MyTeam);
            list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
            BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);
            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (Count).ToString());
        }
    }
}
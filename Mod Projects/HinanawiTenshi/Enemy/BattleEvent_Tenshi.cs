using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using UnityEngine;

namespace HinanawiTenshi
{
    public class BattleEvent_Tenshi : PassiveBase, IP_BattleEnd, IP_PlayerTurn, IP_TurnEndButtonEnemy
    {
        public override void Init()
        {
            base.Init();
            BattleEvent_Tenshi.StopBattle = false;
        }

        public BattleEvent_Tenshi()
        {
            BattleEvent_Tenshi.occupiedPositions.Clear();
            BattleEvent_Tenshi.occupiedPositions1.Clear();
            BattleEvent_Tenshi.occupiedPositions2.Clear();
            BattleEvent_Tenshi.StopBattle = false;
        }

        public void BattleEnd()
        {
            BattleEvent_Tenshi.Boss = null;
            BattleEvent_Tenshi.MainP = null;
            BattleEvent_Tenshi.StopBattle = false;
        }

        public void Turn()
        {
            if (BattleSystem.instance.TurnNum == 1)
            {
                BattleEvent_Tenshi.StopBattle = false;
            }
        }

        public void TurnEndButtonEnemy()
        {
            if (BattleEvent_Tenshi.StopBattle)
            {
                Skill skill = BattleSystem.instance.AllyTeam.Skills.Find((Skill i) => i.MySkill.KeyID == GDEItemKeys.Skill_S_LBossFirst_Phase3_LastAttack);
                if (skill == null)
                {
                    skill = Skill.TempSkill(GDEItemKeys.Skill_S_LBossFirst_Phase3_LastAttack, BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam);
                }
                if (BattleEvent_Tenshi.Boss != null)
                {
                    BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.instance.ForceAction(skill, BattleEvent_Tenshi.Boss, true, false, false, null));
                }
            }
        }

        public static BattleChar Boss;

        public static Boss_B_Tenshi_P MainP;

        public static bool StopBattle;

        public static List<LbossFirst_Position> occupiedPositions = new List<LbossFirst_Position>();

        public static List<LbossFirst_Position> occupiedPositions1 = new List<LbossFirst_Position>();

        public static List<LbossFirst_Position> occupiedPositions2 = new List<LbossFirst_Position>();
    }
}
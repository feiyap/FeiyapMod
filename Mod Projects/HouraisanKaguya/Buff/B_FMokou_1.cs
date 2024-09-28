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
namespace HouraisanKaguya
{
	/// <summary>
	/// 激怒
	/// </summary>
    public class B_FMokou_1:Buff, IP_PlayerTurn_1, IP_SkillUse_User
    {
        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            using (List<BattleChar>.Enumerator enumerator = Targets.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current == base.Usestate_L)
                    {
                        base.SelfDestroy(false);
                        break;
                    }
                }
            }
        }
        
        public void Turn1()
        {
            if (base.Usestate_F.IsDead)
            {
                base.SelfDestroy(false);
                return;
            }
            List<Skill> list = new List<Skill>();
            AI ai = new AI();
            ai.Set(BattleSystem.instance.EnemyTeam.DummyCharEnemy);
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.Master == this.BChar)
                {
                    List<BattleChar> list2 = ai.TargetSelect(skill);
                    if (list2.Count != 0 && list2[0].Info.Ally)
                    {
                        list.Add(skill);
                    }
                }
            }
            if (list.Count != 0)
            {
                Skill skill2 = list.Random(this.BChar.GetRandomClass().Main);
                skill2.NotCount = true;
                BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.instance.ForceAction(skill2, base.Usestate_F, true, true, false, null));
            }
        }
    }
}
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
namespace MinamiRio
{
	/// <summary>
	/// 分离
	/// <color=#48D1CC>单弓</color> - 变为指向所有敌人。施加<color=#54FF9F>风伤</color>。
	/// <color=#FFD700>和弓</color> - 额外造成&a(35%)伤害。如果目标拥有嘲讽状态，则同时指定所有非嘲讽状态的敌人。
	/// </summary>
    public class S_MinamiRio_4:Skill_Extended
    {
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_MinamiRio_P1"))
                {
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
                    this.SkillBasePlus.Target_BaseDMG = 0;
                }
                else
                {
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
                    this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.35f);
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            if (this.BChar.BuffFind("B_MinamiRio_P1"))
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_MinamiRio_4", this.BChar);
                }
            }
            else if (this.BChar.BuffFind("B_MinamiRio_P2"))
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.35f);
                if (Targets[0] is BattleEnemy && (Targets[0] as BattleEnemy).istaunt)
                {
                    List<BattleChar> list = new List<BattleChar>();
                    list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars);
                    list.Remove(Targets[0]);
                    if (list.Count >= 1)
                    {
                        foreach (BattleEnemy be in list)
                        {
                            if (!(be as BattleEnemy).istaunt)
                            {
                                Targets.Add(be);
                            }
                        }
                    }
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.35f)).ToString());
        }
    }
}
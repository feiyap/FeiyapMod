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
namespace FeiyapTank
{
	/// <summary>
	/// 狂笑魔女的面具
	/// 每回合 1 次，使用攻击技能时，手中随机治疗技能费用降低 1 点。
	/// 每回合 1 次，使用治疗技能时，手中随机攻击技能费用降低 1 点。
	/// </summary>
    public class E_Boss_FeiyapMage_1:EquipBase, IP_SkillUseHand_Team, IP_PlayerTurn
    {
        public bool isAttack = false;
        public bool isHeal = false;
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 3;
            this.PlusStat.reg = 3;
            this.PlusStat.def = 3;
            this.PlusStat.maxhp = 3;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                if (skill.IsDamage && !isAttack)
                {
                    isAttack = true;
                    List<Skill> list = new List<Skill>();
                    list.AddRange(BattleSystem.instance.AllyTeam.Skills);
                    list.Remove(skill);
                    for (int i = 0 ; i < list.Count ; i++)
                    {
                        if (!list[i].IsHeal)
                        {
                            list.RemoveAt(i);
                            i--;
                        }
                    }
                    if (list.Count >= 1)
                    {
                        Skill_Extended new_se = new Skill_Extended();
                        new_se.APChange = -1;
                        list.Random(BattleRandom.PassiveItem).ExtendedAdd(new_se);
                    }
                }
                if (skill.IsHeal && !isHeal)
                {
                    isHeal = true;
                    List<Skill> list = new List<Skill>();
                    list.AddRange(BattleSystem.instance.AllyTeam.Skills);
                    list.Remove(skill);
                    for (int i = 0 ; i < list.Count ; i++)
                    {
                        if (!list[i].IsDamage)
                        {
                            list.RemoveAt(i);
                            i--;
                        }
                    }
                    if (list.Count >= 1)
                    {
                        Skill_Extended new_se = new Skill_Extended();
                        new_se.APChange = -1;
                        list.Random(BattleRandom.PassiveItem).ExtendedAdd(new_se);
                    }
                }
            }
        }

        public void Turn()
        {
            isAttack = false;
            isHeal = false;
        }
    }
}
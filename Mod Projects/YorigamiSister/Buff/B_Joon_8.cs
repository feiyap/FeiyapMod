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
	/// 即将破裂的泡沫
	/// 保护罩解除时，对所有敌人造成 &c 伤害（消耗金币的5%）。依据命中敌人的个数，使&user获得相同层数的“拜金主义”。
	/// </summary>
    public class B_Joon_8:Buff
    {
        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&c", ((int)(this.Usestate_F.GetStat.atk * 1f)).ToString())
                                            .Replace("&user", this.Usestate_F.Info.Name);
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();

            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                Skill skill = Skill.TempSkill("S_Joon_8_0", this.Usestate_F, this.Usestate_F.MyTeam);
                skill.PlusHit = true;
                skill.FreeUse = true;
                skill.isExcept = true;

                this.Usestate_F.ParticleOut(skill, bc);

                bc.Damage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 1f), false);

                this.Usestate_F.BuffAdd("B_Joon_4", this.Usestate_F);
            }
        }
    }
}
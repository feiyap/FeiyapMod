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
namespace FeiyapBoss
{
	/// <summary>
	/// 绯夜流·一式
	/// 若目标拥有保护体力极限，额外造成 &a 伤害(攻击力的50%)。
	/// 否则立即恢复「上个回合中，自己受到过的最高的单次伤害值」的体力。
	/// </summary>
    public class S_Feiyap_Boss_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.5f));
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (Targets[0].GetStat.Strength)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
            else
            {
                this.SkillBasePlus.Target_BaseDMG = 0;

                this.BChar.Heal(this.BChar, B_Feiyap_Boss_P_1.hprecordlast, false, false, null);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
    }
}
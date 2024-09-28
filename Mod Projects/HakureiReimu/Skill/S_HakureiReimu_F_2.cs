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
namespace HakureiReimu
{
	/// <summary>
	/// 珠符「明珠暗投」
	/// 同时指定1个血量最低的敌人。
	/// 使用这个技能击杀敌人时，回复1点法力值。
	/// </summary>
    public class S_HakureiReimu_F_2: SkillExtended_Reimu
    {
        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    buffCount_N = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    buffCount_N = 0;
                }

                if (buffCount_N != buffCount_L && BattleSystem.instance != null && !this.MySkill.IsNowCounting)
                {
                    this.SkillChange("S_HakureiReimu_F_2", buffCount_N);
                }

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    this.buffCount_L = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    this.buffCount_L = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<BattleChar> list = new List<BattleChar>();
            list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars);
            list.Remove(Targets[0]);
            if (list.Count >= 1)
            {
                list = (from x in list
                        orderby x.HP
                        select x).ToList<BattleChar>();
                Targets.Add(list[0]);
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            this.BChar.MyTeam.AP += 1;
        }
    }
}
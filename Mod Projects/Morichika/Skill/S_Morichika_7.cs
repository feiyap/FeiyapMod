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
namespace Morichika
{
	/// <summary>
	/// 开源节流
	/// 移除所有友军的“保修服务”增益。
	/// 每有 1 个“保修服务”被移除，超额治疗自身 &a (最大体力值的34%)，对所有敌人施加 1 层“发现弱点”，优先抽取 1 个自己的技能，恢复 1 点法力值。
	/// </summary>
    public class S_Morichika_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int count = 0;

            foreach (BattleChar bc in Targets)
            {
                if (bc.BuffFind("B_Morichika_P"))
                {
                    count++;
                    bc.BuffReturn("B_Morichika_P")?.SelfDestroy();
                }
            }

            for (int i = 0; i < count; i++)
            {
                this.BChar.Heal(base.BChar, this.BChar.GetStat.maxhp * 0.34f, true, true, null);
                this.BChar.MyTeam.CharacterDraw(this.BChar);
                this.BChar.MyTeam.AP++;

                foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                {
                    be.BuffAdd("B_Morichika_0", this.BChar);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.maxhp * 0.34f)).ToString());
        }
    }
}
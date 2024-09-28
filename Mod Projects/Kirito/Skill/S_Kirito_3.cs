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
namespace Kirito
{
	/// <summary>
	/// 音速冲击
	/// 当存在[嘲讽]敌人时，攻击非嘲讽敌人时暴击率+100%。依据选择的后宫团成员获得额外效果：
	/// -亚丝娜：攻击嘲讽敌人时抽取1个技能。
	/// -诗乃：攻击嘲讽敌人时暴击率+100%。
	/// -尤吉欧：获得1层[音速]：最大生命值+20%。
	/// </summary>
    public class S_Kirito_3:Skill_Extended
    {
        bool flag = false;
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            flag = false;
            foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
            {
                if (battleEnemy.istaunt)
                {
                    flag = true;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                this.BChar.BuffAdd("B_Eugeo_3", this.BChar, false, 0, false, -1, false);
            }

            if (!flag)
            {
                return;
            }
            for (int i = 0; i < Targets.Count; i++)
            {
                if (Targets[i] is BattleEnemy && (Targets[i] as BattleEnemy).istaunt)
                {
                    if (this.BChar.BuffFind("B_Asuna_P", false))
                    {
                        BattleSystem.instance.AllyTeam.Draw();
                    }
                    if (this.BChar.BuffFind("B_Shino_P", false))
                    {
                        this.PlusSkillStat.cri = 100f;
                    }
                }
                else
                {
                    this.PlusSkillStat.cri = 100f;
                }
            }
            base.SkillUseSingle(SkillD, Targets);
        }
    }
}
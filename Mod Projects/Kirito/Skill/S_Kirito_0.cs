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
	/// 斜斩
	/// 抽取1个技能。依据选择的后宫团成员获得额外效果：
	/// -亚丝娜：附加迅速。
	/// -诗乃：获得1层[子弹上膛]：下个[狙击支援]伤害提升10%。
	/// -尤吉欧：额外施加1层[冻伤]。
	/// </summary>
    public class S_Kirito_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();

            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                
            }

            if (this.BChar.BuffFind("B_Shino_P", false))
            {
                this.BChar.BuffAdd("B_Shino_0", this.BChar, false, 0, false, -1, false);
            }

            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                for (int i = 0; i < Targets.Count; i++)
                {
                    if (Targets[i] is BattleEnemy)
                    {
                        Targets[i].BuffAdd("B_Eugeo_P_0_0", this.BChar, false, 0, false, -1, false);
                    }
                }
            }
        }

        public override void HandInit()
        {
            base.HandInit();
            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                this.NotCount = true;
            }
        }
    }
}
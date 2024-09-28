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
	/// 藤原「灭罪寺院伤」
	/// <color=orange>过热：3 - 改为指向所有敌人。</color>
	/// </summary>
    public class S_FMokou_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.BuffFind("B_Mokou_T_1") && this.BChar.BuffReturn("B_Mokou_T_1", false).StackNum >= 3)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (battleChar != Targets[0])
                    {
                        Targets.Add(battleChar);
                    }
                }

                int num = 0;
                for (int i = 0; i < 3; i++)
                {
                    bool flag = this.BChar.BuffFind("B_Mokou_T_1", false);
                    if (flag)
                    {
                        int num2 = this.BChar.BuffReturn("B_Mokou_T_1", false).Tick();
                        int stackNum = this.BChar.BuffReturn("B_Mokou_T_1", false).StackNum;
                        int num3 = (int)this.BChar.BuffReturn("B_Mokou_T_1", false).BuffData.LifeTime;
                        num += num2 / stackNum * num3;
                        this.BChar.BuffReturn("B_Mokou_T_1", false).SelfStackDestroy();
                    }
                }
                this.BChar.Damage(this.BChar, num, false, true, true, 0, false, false, false);
            }
        }
    }
}
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
    /// 藤原妹红
    /// </summary>
    public class Boss_Mokou : AI
    {
        public override List<BattleChar> TargetSelect(Skill SelectedSkill)
        {
            if (SelectedSkill.MySkill.KeyID == "S_FMokou_5")
            {
                int max = 0;
                List<BattleChar> list = new List<BattleChar>();
                BattleChar target = new BattleChar();
                
                foreach (BattleChar battlechar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (battlechar.BuffFind("B_Mokou_T_1") && battlechar.BuffReturn("B_Mokou_T_1", false).StackNum > max)
                    {
                        max = battlechar.BuffReturn("B_Mokou_T_1", false).StackNum;
                        target = battlechar;
                    }
                }

                if (max != 0)
                {
                    list.Add(target);
                    return list;
                }
            }
            return base.TargetSelect(SelectedSkill);
        }

        public override Skill SkillSelect(int ActionCount)
        {
            if (BattleSystem.instance.TurnNum % 3 == 1)
            {
                if (ActionCount == 0)
                {
                    return this.BChar.Skills[3];
                }
                return this.BChar.Skills[5];
            }
            else if (BattleSystem.instance.TurnNum % 3 == 2)
            {
                if (ActionCount == 0)
                {
                    return this.BChar.Skills[3];
                }
                return this.BChar.Skills[1];
            }
            else if (BattleSystem.instance.TurnNum % 3 == 0)
            {
                if (ActionCount == 0)
                {
                    return this.BChar.Skills[2];
                }
                return this.BChar.Skills[4];
            }

            return this.BChar.Skills[3];
        }
    }
}
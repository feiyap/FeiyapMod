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
namespace CirnoBlizzard
{
	/// <summary>
	/// 琪露诺=暴风雪
	/// </summary>
    public class Boss_CirnoBlizzard:AI
    {
        public override Skill SkillSelect(int ActionCount)
        {
            if (BattleEvent_CirnoBlizzard.MainP.Phase == 1)
            {
                if (ActionCount == 0)
                {
                    return this.BChar.Skills[0];
                }
                else if (ActionCount == 1)
                {
                    return this.BChar.Skills[1];
                }
                return null;
            }
            else if (BattleEvent_CirnoBlizzard.MainP.Phase == 2)
            {
                if (BattleSystem.instance.TurnNum % 2 == 1)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[2];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[3];
                    }
                    else if (ActionCount == 2)
                    {
                        System.Random rand = new System.Random();
                        int randomIndex = rand.Next(4, 6);
                        return this.BChar.Skills[randomIndex];
                    }
                    else if (ActionCount == 3)
                    {
                        return this.BChar.Skills[6];
                    }
                    return null;
                }
                else if (BattleSystem.instance.TurnNum % 2 == 0)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[3];
                    }
                    else if (ActionCount == 1)
                    {
                        System.Random rand = new System.Random();
                        int randomIndex = rand.Next(7, 9);
                        return this.BChar.Skills[randomIndex];
                    }
                    else if (ActionCount == 2)
                    {
                        return this.BChar.Skills[9];
                    }
                    else if (ActionCount == 3)
                    {
                        return this.BChar.Skills[6];
                    }
                    return null;
                }
            }
            else if (BattleEvent_CirnoBlizzard.MainP.Phase == 3)
            {
                if (BattleSystem.instance.TurnNum % 2 == 1)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[10];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[11];
                    }
                    else if (ActionCount == 2)
                    {
                        return this.BChar.Skills[12];
                    }
                    else if (ActionCount == 3)
                    {
                        return this.BChar.Skills[13];
                    }
                    return null;
                }
                else if (BattleSystem.instance.TurnNum % 2 == 0)
                {
                    if (ActionCount == 0)
                    {
                        System.Random rand = new System.Random();
                        int randomIndex = rand.Next(14, 16);
                        return this.BChar.Skills[randomIndex];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[13];
                    }
                    else if (ActionCount == 2)
                    {
                        return this.BChar.Skills[12];
                    }
                    else if (ActionCount == 3)
                    {
                        return this.BChar.Skills[9];
                    }
                    return null;
                }
            }
            return null;
        }

        public override int SpeedChange(Skill skill, int ActionCount, int OriginSpeed)
        {
            if (ActionCount == 0)
            {
                return 1;
            }
            if (ActionCount == 1)
            {
                return 2;
            }
            if (ActionCount == 2)
            {
                return 3;
            }
            return base.SpeedChange(skill, ActionCount, OriginSpeed);
        }

        public override List<BattleChar> TargetSelect(Skill SelectedSkill)
        {
            if (SelectedSkill.MySkill.KeyID == "Boss_S_Tenshi_2")
            {
                List<BattleChar> list = new List<BattleChar>();
                int max = 0;
                BattleChar temp = new BattleChar();
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    if (max < bc.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false).Count)
                    {
                        max = bc.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false).Count;
                        temp = bc;
                    }
                }
                list.Add(temp);
                return list;
            }
            return base.TargetSelect(SelectedSkill);
        }
    }
}
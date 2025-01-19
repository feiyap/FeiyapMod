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
namespace HinanawiTenshi
{
	/// <summary>
	/// 比那名居天子
	/// </summary>
    public class Boss_Tenshih:AI
    {
        public override Skill SkillSelect(int ActionCount)
        {
            if (BattleEvent_Tenshi.MainP.Phase == 1)
            {
                if (BattleSystem.instance.TurnNum % 2 == 1)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[0];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[1];
                    }
                    return this.BChar.Skills[2];
                }
                else if (BattleSystem.instance.TurnNum % 2 == 0)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[3];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[4];
                    }
                    return this.BChar.Skills[2];
                }
            }
            else if (BattleEvent_Tenshi.MainP.Phase == 2)
            {
                if (BattleSystem.instance.TurnNum % 2 == 1)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[0];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[1];
                    }
                    else if (ActionCount == 2)
                    {
                        return this.BChar.Skills[5];
                    }
                    return this.BChar.Skills[2];
                }
                else if (BattleSystem.instance.TurnNum % 2 == 0)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[3];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[4];
                    }
                    else if (ActionCount == 2)
                    {
                        return this.BChar.Skills[5];
                    }
                    return this.BChar.Skills[2];
                }
            }
            return this.BChar.Skills[0];
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
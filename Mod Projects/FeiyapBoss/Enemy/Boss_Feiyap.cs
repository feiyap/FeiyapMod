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
    public class Boss_Feiyap:AI
    {
        public override Skill SkillSelect(int ActionCount)
        {
            {
                if (BattleSystem.instance.TurnNum % 2 == 1)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[0];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[2];
                    }
                    else if (ActionCount == 2)
                    {
                        return this.BChar.Skills[4];
                    }
                    return this.BChar.Skills[0];
                }
                else if (BattleSystem.instance.TurnNum % 2 == 0)
                {
                    if (ActionCount == 0)
                    {
                        return this.BChar.Skills[1];
                    }
                    else if (ActionCount == 1)
                    {
                        return this.BChar.Skills[3];
                    }
                    else if (ActionCount == 2)
                    {
                        return this.BChar.Skills[4];
                    }
                    return this.BChar.Skills[1];
                }
            }
            return this.BChar.Skills[0];
        }

        public override int SpeedChange(Skill skill, int ActionCount, int OriginSpeed)
        {
            if (ActionCount == 0)
            {
                return 1;
            }
            if (ActionCount == 1)
            {
                return 3;
            }
            if (ActionCount == 2)
            {
                return 5;
            }
            return base.SpeedChange(skill, ActionCount, OriginSpeed);
        }

        public override List<BattleChar> TargetSelect(Skill SelectedSkill)
        {
            return base.TargetSelect(SelectedSkill);
        }
    }
}
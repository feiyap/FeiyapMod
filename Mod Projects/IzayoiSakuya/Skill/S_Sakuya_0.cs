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
namespace IzayoiSakuya
{
    /// <summary>
    /// 女仆秘技「杀人玩偶」
    /// 打出时若在手牌顶或手牌底，将1张[时符「调换魔法」]加入手中。
    /// </summary>
    public class S_Sakuya_0: SkillExtended_Sakuya
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Sakuya_0_0", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            if (CheckLunaMagic())
            {
                P_IzayoiSakuya.getTimeKnife(this.BChar, BattleSystem.instance.AllyTeam.Skills.Count());
            }
        }
    }
}
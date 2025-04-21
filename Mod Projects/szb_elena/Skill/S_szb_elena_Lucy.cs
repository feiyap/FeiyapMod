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
namespace szb_elena
{
    /// <summary>
    /// 黄金之钟
    /// 打出时立即恢复所有目标5点生命值。
    /// 释放时抽取2个技能。
    /// </summary>
    public class S_szb_elena_Lucy : Skill_Extended,IP_SkillCastingStart
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);
        }
        public void SkillCasting(CastingSkill ThisSkill) 
        {
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars) 
            {
                battleChar.Heal(this.BChar,5f, false, false, null);
            }
        }
    }
}
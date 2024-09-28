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
	/// 幻在「钟表的残骸」
	/// 倒计时1后，再造成100%倍率。
	/// 月魔术 - 倒计时延长为3，倒计时期间，目标受到的伤害增加15%。
	/// </summary>
    public class S_Sakuya_3_0:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString()).Replace("%b", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}
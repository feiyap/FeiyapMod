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
namespace FairyLancelot
{
	/// <summary>
	/// 光之地平线
	/// 骑士 - 移除所有“舞者”增益。
	/// 恢复 4 点法力值，获得 1 次等待次数和交换次数，抽取 1 个技能。
	/// 邪龙 - 移除所有“龙之心”增益。
	/// 额外造成 &a 伤害(攻击力的300%)。自身受到<color=purple>20 点痛苦伤害</color>，获得“保护体力极限”，持续 1 回合。
	/// </summary>
    public class S_FLancelot_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FLancelot_C_2"))
            {
                int stacknum = this.BChar.BuffReturn("B_FLancelot_P_4")?.StackNum ?? 0;
                this.BChar.BuffReturn("B_FLancelot_P_4")?.SelfDestroy();
                this.BChar.MyTeam.AP += stacknum;
                this.BChar.MyTeam.WaitCount += stacknum;
                this.BChar.MyTeam.DiscardCount += stacknum;
                this.BChar.MyTeam.Draw(stacknum);
            }
            if (this.BChar.BuffFind("B_FLancelot_C_1"))
            {
                this.BChar.BuffReturn("B_FLancelot_P_3")?.SelfDestroy();
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 2);
                this.BChar.BuffAdd("B_FLancelot_7", this.BChar);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 2.0f)).ToString());
        }
    }
}
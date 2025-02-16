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
using BasicMethods;
namespace Yuyuko
{
	/// <summary>
	/// 灵蝶「蝶之羽风暂留此世」
	/// 仅能在无法行动时、或处于永眠状态时使用。
	/// 解除所有干扰减益和永眠状态，抽取1个技能，恢复1点法力值。
	/// 将返魂值设置为50，并进入华胥状态。
	/// 立即获得30点亡魂。回合结束时，移除30点亡魂。
	/// 葬送 - 降低100返魂值。
	/// 幽冥蝶 - 施加时，抽取1个技能。
	/// 人魂蝶 - 施加时，恢复1点法力值。
	/// </summary>
    public class S_YuyukoF_7:Skill_Extended, IP_SkillSelfExcept
    {
        public override bool Terms()
        {
            return this.BChar.GetStat.Stun || P_YuyukoF.Yuyu == P_YuyukoF.YuyuState.State_Yongmian;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.CC, false))
            {
                buff.SelfDestroy();
            }

            BattleSystem.instance.AllyTeam.AP += 2;
            BattleSystem.instance.AllyTeam.Draw(2);

            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(0, true);
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(50, true);

            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().ghost += 10;
        }

        public bool SelfExcept(SkillLocation skillLoaction)
        {
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(-100, false);
            return true;
        }
    }
}
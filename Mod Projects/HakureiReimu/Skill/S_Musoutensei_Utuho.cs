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
namespace HakureiReimu
{
	/// <summary>
	/// 核聚变「活殺自在·地獄暴走之心」
	/// <color=#FFD700>*「梦想天生」+地狱的人造太阳*</color>
	/// 立即结算3次目标身上的痛苦减益伤害。
	/// </summary>
    public class S_Musoutensei_Utuho: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("Musoutensei_Utuho", 1f, null, 0f, null, null, false, false);

            foreach (BattleChar bc in Targets)
            {
                if (bc.GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count != 0)
                {
                    int num = 0;
                    foreach (Buff buff in bc.Buffs)
                    {
                        num += buff.DotDMGView();
                    }
                    bc.Damage(BattleSystem.instance.DummyChar, num, false, true, false, 0, false, false, false);
                    bc.Damage(BattleSystem.instance.DummyChar, num, false, true, false, 0, false, false, false);
                    bc.Damage(BattleSystem.instance.DummyChar, num, false, true, false, 0, false, false, false);
                }
            }
        }
    }
}
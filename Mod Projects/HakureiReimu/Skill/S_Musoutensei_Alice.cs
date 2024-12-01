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
	/// 魔符「幻想乡异闻录」
	/// <color=#FFD700>*「梦想天生」+寿命论“星之梦”*</color>
	/// 解除目标所有减益效果。每解除1个减益，抽取1个技能，恢复1点法力值。最多抽取4个技能。
	/// </summary>
    public class S_Musoutensei_Alice: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("Musoutensei_Alice", 1f, null, 0f, null, null, false, false);

            int count = 0;
            foreach (BattleChar bc in Targets)
            {
                if (bc.GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count != 0)
                {
                    List<Buff> list = new List<Buff>();
                    foreach (Buff buff in bc.Buffs)
                    {
                        if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                        {
                            buff.SelfDestroy();
                            count++;
                        }
                    }
                }
            }

            BattleSystem.instance.AllyTeam.AP += count;
            if (count >= 4)
            {
                count = 4;
            }
            BattleSystem.instance.AllyTeam.Draw(count);
        }
    }
}
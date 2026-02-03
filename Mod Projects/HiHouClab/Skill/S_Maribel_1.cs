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
namespace HiHouClab
{
	/// <summary>
	/// 梦境与现实的境界
	/// 解除目标持有的所有减益效果。
	/// </summary>
    public class S_Maribel_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count != 0)
            {
                List<Buff> list = new List<Buff>();
                foreach (Buff buff in Targets[0].Buffs)
                {
                    if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                    {
                        buff.SelfDestroy();
                    }
                }
            }
        }
    }
}
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
	/// 结界「人至之处的青山」
	/// 可在无法行动时使用。
	/// 移除自己所有的减益效果。
	/// 依据解除的减益效果种类，抽取等量的技能（最多3个）。
	/// </summary>
    public class S_HakureiReimu_F_8_3: S_HakureiReimu_F_8
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int count = 0;
            if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count != 0)
            {
                List<Buff> list = new List<Buff>();
                foreach (Buff buff in this.BChar.Buffs)
                {
                    if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                    {
                        buff.SelfDestroy();
                        if (count <= 3)
                        {
                            BattleSystem.instance.AllyTeam.Draw();
                        }
                        count++;
                    }
                }
            }
        }
    }
}
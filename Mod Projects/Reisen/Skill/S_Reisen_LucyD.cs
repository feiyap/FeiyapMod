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
namespace Reisen
{
	/// <summary>
	/// 波符「幻之月(Invisible Half Moon)」
	/// 抽取2个技能。使目标身上所有可堆叠的增益效果增加1层。使目标身上所有可堆叠的减益效果减少1层。
	/// </summary>
    public class S_Reisen_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            List<Buff> list = new List<Buff>();
            foreach (Buff buff in Targets[0].Buffs)
            {
                if (buff.BuffData.MaxStack > 1 && !buff.BuffData.Hide && !buff.DestroyBuff)
                {
                    if (!buff.BuffData.Debuff)
                    {
                        Targets[0].BuffAdd(buff.BuffData.Key, buff.Usestate_L, false, 0, false, -1, false);
                    }
                    else if (!buff.BuffData.Cantdisable)
                    {
                        Targets[0].BuffReturn(buff.BuffData.Key).SelfStackDestroy();
                    }
                }
            }
        }
    }
}
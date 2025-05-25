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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 土水符「诺亚的大洪水」
	/// 随机解除目标持有的 1 个减益效果。每解除 1 个减益效果，施加 &a 保护罩(治疗力的20%)。
	/// </summary>
    public class S_Pachi_Sk_2_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleChar bc in Targets)
            {
                for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4]; i++)
                {
                    List<Buff> list = new List<Buff>();
                    foreach (Buff buff in bc.Buffs)
                    {
                        if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                        {
                            list.Add(buff);
                        }
                    }
                    if (list.Count != 0)
                    {
                        bc.BuffRemove(list.Random(bc.GetRandomClass().Main).BuffData.Key, false);
                        int num = (int)(this.BChar.GetStat.reg * 0.2);
                        bc.BuffAdd("B_Pachi_Barrier", this.BChar).BarrierHP += num;
                    }
                }
            }

            this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg * (0.1 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2]));
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 0.1f)).ToString());
        }
    }
}
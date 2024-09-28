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
namespace Eirin
{
	/// <summary>
	/// 天丸「壶中的天地」
	/// </summary>
    public class S_Eirin_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();
            
            if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count != 0)
            {
                List<Buff> list = new List<Buff>();
                foreach (Buff buff in Targets[0].Buffs)
                {
                    if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                    {
                        list.Add(buff);
                    }
                }
                if (list.Count != 0)
                {
                    Buff removeBuff = list.Random(Targets[0].GetRandomClass().Main);
                    switch (removeBuff.BuffData.BuffTag.Key)
                    {
                        case string _ when removeBuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_DOT:
                            {
                                Targets[0].BuffAdd("B_Eirin_2", this.BChar, false, 0, false, 2, false);
                            }
                            break;
                        case string _ when removeBuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_Debuff:
                            {
                                Targets[0].BuffAdd("B_Eirin_1", this.BChar, false, 0, false, 2, false);
                            }
                            break;
                        case string _ when removeBuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_CrowdControl:
                            {
                                Targets[0].BuffAdd("B_Eirin_3", this.BChar, false, 0, false, 2, false);
                            }
                            break;
                    }
                    Targets[0].BuffRemove(removeBuff.BuffData.Key, false);
                }
                return;
            }
        }
    }
}
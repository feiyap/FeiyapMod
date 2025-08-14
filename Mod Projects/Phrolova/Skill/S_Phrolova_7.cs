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
namespace Phrolova
{
	/// <summary>
	/// 生命不灭的轻歌
	/// 在手中生成 1 个自己未学会的稀有技能。
	/// </summary>
    public class S_Phrolova_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            using (List<GDESkillData>.Enumerator enumerator = PlayData.ALLRARESKILLLIST.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    GDESkillData i = enumerator.Current;
                    if (!BattleSystem.instance.AllyTeam.Skills_Deck.Any((Skill v) => v.MySkill.KeyID == i.KeyID))
                    {
                        Skill item = Skill.TempSkill(i.KeyID, this.BChar, this.BChar.MyTeam);
                        if (!i.NoDrop && !i.Lock && i.User == this.MyChar.KeyData)
                        {
                            list.Add(item);
                        }
                    }
                }
            }
            if (list.Count > 0)
            {
                BattleSystem.instance.AllyTeam.Add(list.Random<Skill>(), true);
            }
        }
    }
}
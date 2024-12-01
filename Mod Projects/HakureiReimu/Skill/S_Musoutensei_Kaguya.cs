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
	/// 新难题「幻想乡的至宝」
	/// <color=#FFD700>*「梦想天生」+新难题「艾哲红石」*</color>
	/// 生成目标的所有稀有技能。
	/// </summary>
    public class S_Musoutensei_Kaguya: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("Musoutensei_Kaguya", 1f, null, 0f, null, null, false, false);

            List<Skill> list = new List<Skill>();
            using (List<GDESkillData>.Enumerator enumerator = PlayData.ALLRARESKILLLIST.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    GDESkillData i = enumerator.Current;
                    if (Targets[0].Info.KeyData == i.User && i.Category.Key != GDEItemKeys.SkillCategory_LucySkill && i.Category.Key != GDEItemKeys.SkillCategory_DefultSkill && !i.NoDrop && !i.Lock)
                    {
                        Skill item = Skill.TempSkill(i.KeyID, Targets[0], this.BChar.MyTeam);
                        item.isExcept = true;
                        this.BChar.MyTeam.Add(item, true);
                    }
                }
            }
        }
    }
}
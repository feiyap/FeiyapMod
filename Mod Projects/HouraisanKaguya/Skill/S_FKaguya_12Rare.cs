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
namespace HouraisanKaguya
{
	/// <summary>
	/// 新难题「艾哲红石」
	/// 从目标调查员所有的稀有技能中选择1张并生成，附加放逐、一次性。
	/// </summary>
    public class S_FKaguya_12Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
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
                        list.Add(item);
                    }
                }
            }
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.Add(Mybutton.Myskill, true);
        }
    }
}
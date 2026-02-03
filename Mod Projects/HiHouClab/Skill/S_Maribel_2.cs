using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TileTypes;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace HiHouClab
{
	/// <summary>
	/// 53分钟的蓝色大海
	/// 展示倒计时栏中所有调查员的非稀有技能。
	/// 选择其中 1 个，复制并立即释放。
	/// </summary>
    public class S_Maribel_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();

            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (!cs.skill.MySkill.Rare && cs.skill.MySkill.KeyID != "S_Maribel_2")
                {
                    Skill skill = cs.skill.CloneSkill(true, null, null, false);
                    skill.Counting = -99;
                    list.Add(skill);
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (!cs.skill.MySkill.Rare && cs.skill.MySkill.KeyID != "S_Maribel_2")
                {
                    Skill skill = cs.skill.CloneSkill(true, null, null, false);
                    skill.Counting = -99;
                    list.Add(skill);
                }
            }

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (cs.skill.CharinfoSkilldata.Seed == Mybutton.Myskill.CharinfoSkilldata.Seed)
                {
                    if (cs.Target != null)
                    {
                        BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Mybutton.Myskill, cs.Target, false, false, false, null));
                    }
                    else if (cs.SkillTarget != null)
                    {
                        BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Mybutton.Myskill, null, false, false, false, cs.SkillTarget));
                    }
                    else
                    {
                        BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Mybutton.Myskill, null, false, false, false, null));
                    }
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (cs.skill.CharinfoSkilldata.Seed == Mybutton.Myskill.CharinfoSkilldata.Seed)
                {
                    if (cs.Target != null)
                    {
                        BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Mybutton.Myskill, cs.Target, false, false, false, null));
                    }
                    else if (cs.SkillTarget != null)
                    {
                        BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Mybutton.Myskill, null, false, false, false, cs.SkillTarget));
                    }
                    else
                    {
                        BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Mybutton.Myskill, null, false, false, false, null));
                    }
                }
            }
        }
    }
}
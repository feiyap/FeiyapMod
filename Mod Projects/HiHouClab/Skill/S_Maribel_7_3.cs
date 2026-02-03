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
	/// 倒计时-2
	/// 选择 1 个倒计时中的技能，使其倒计时-2。
	/// </summary>
    public class S_Maribel_7_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();

            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (!cs.skill.MySkill.Rare)
                {
                    Skill skill = cs.skill.CloneSkill(true, null, null, false);
                    list.Add(skill);
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (!cs.skill.MySkill.Rare)
                {
                    Skill skill = cs.skill.CloneSkill(true, null, null, false);
                    list.Add(skill);
                }
            }

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            List<CastingSkill> removeList = new List<CastingSkill>();
            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (cs.skill.CharinfoSkilldata.Seed == Mybutton.Myskill.CharinfoSkilldata.Seed)
                {
                    cs.CastButton.CountingLeft -= 2;

                    if (cs.CastSpeed <= 0)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(cs);
                        removeList.Add(cs);

                        Skill skill2 = cs.skill.CloneSkill(true, null, null, false);
                        skill2.Counting = -99;

                        if (cs.Target != null)
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, cs.Target, false, false, false, null));
                        }
                        else if (cs.SkillTarget != null)
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, cs.SkillTarget));
                        }
                        else
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, null));
                        }
                    }
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (cs.skill.CharinfoSkilldata.Seed == Mybutton.Myskill.CharinfoSkilldata.Seed)
                {
                    cs.CastButton.CountingLeft -= 2;

                    if (cs.CastSpeed <= 0)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(cs);
                        removeList.Add(cs);

                        Skill skill2 = cs.skill.CloneSkill(true, null, null, false);
                        skill2.Counting = -99;

                        if (cs.Target != null)
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, cs.Target, false, false, false, null));
                        }
                        else if (cs.SkillTarget != null)
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, cs.SkillTarget));
                        }
                        else
                        {
                            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, null));
                        }
                    }
                }
            }
            foreach (CastingSkill castingSkill3 in removeList)
            {
                BattleSystem.instance.CastSkills.Remove(castingSkill3);
                BattleSystem.instance.SaveSkill.Remove(castingSkill3);
            }
        }
    }
}
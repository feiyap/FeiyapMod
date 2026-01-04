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
namespace HinanawiTenshi
{
	/// <summary>
	/// 地震「先忧后乐之剑」
	/// (150%干扰)眩晕目标。
	/// <color=#97FFFF>天启9</color> - 触发时，改为眩晕所有敌人。
	/// </summary>
    public class S_Tenshi_Rare_2: SkillBase_Tenshi
    {
        public BattleChar saveTarget;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(9, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            List<GDESkillData> list2 = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.User == this.BChar.Info.KeyData)
                {
                    list2.Add(gdeskillData);
                }
            }
            foreach (GDESkillData gdeskillData2 in list2)
            {
                if (gdeskillData2 != null && !gdeskillData2.KeyID.IsNullOrEmpty())
                {
                    Skill skill = Skill.TempSkill(gdeskillData2.KeyID, this.BChar, BattleSystem.instance.AllyTeam).CloneSkill(false, null, null, false);
                    skill.isExcept = true;
                    list.Add(skill);
                }
            }
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
            
            if (CheckKishi(9, false))
            {
                foreach (Buff buff in this.BChar.Buffs)
                {
                    if (!buff.BuffData.Hide)
                    {
                        if (buff.BuffData.LifeTime != 0f)
                        {
                            foreach (StackBuff stackBuff in buff.StackInfo)
                            {
                                stackBuff.RemainTime += 9;
                            }
                        }
                    }
                }
            }
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.instance.AllyTeam.Add(Mybutton.Myskill, true);
        }
    }
}
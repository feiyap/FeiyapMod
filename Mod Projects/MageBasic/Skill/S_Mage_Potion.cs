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
namespace MageBasic
{
	/// <summary>
	/// 魔女的药水
	/// </summary>
    public class S_Mage_Potion:Skill_Extended
    {
        public override bool TargetSelectExcept(BattleChar ExceptTarget)
        {
            return !(ExceptTarget.Info.GetData.Role.Key == "Role_Mage");
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            List<GDESkillData> list2 = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.User == Targets[0].Info.KeyData)
                {
                    list2.Add(gdeskillData);
                }
            }
            foreach (GDESkillData gdeskillData2 in list2)
            {
                if (gdeskillData2 != null && !gdeskillData2.KeyID.IsNullOrEmpty())
                {
                    Skill skill = Skill.TempSkill(gdeskillData2.KeyID, Targets[0], BattleSystem.instance.AllyTeam).CloneSkill(false, null, null, false);
                    list.Add(skill);
                }
            }
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.instance.AllyTeam.Add(Mybutton.Myskill, true);
        }
    }
}
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
namespace Yuyuko
{
	/// <summary>
	/// 樱花「依恋未酌宴」
	/// </summary>
    public class S_YuyukoF_9:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_YuyukoF_9_0", this.MySkill.Master, this.MySkill.Master.MyTeam));
            list.Add(Skill.TempSkill("S_YuyukoF_9_1", this.MySkill.Master, this.MySkill.Master.MyTeam));
            BattleSystem.instance.StartCoroutine(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            if (Mybutton.Myskill.MySkill.KeyID == "S_YuyukoF_9_0")
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(40);
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_YuyukoF_9_1")
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(-40);
            }
        }
    }
}
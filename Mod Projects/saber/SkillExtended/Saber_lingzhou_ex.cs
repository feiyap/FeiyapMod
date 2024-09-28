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
namespace saber
{
    public class Saber_lingzhou_ex:Skill_Extended
    {
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.TargetTemp = hit;
            List<Skill> list = new List<Skill>
            {
                Skill.TempSkill(ModItemKeys.Skill_Saber_lingzhou_1, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(ModItemKeys.Skill_Saber_lingzhou_2, this.MySkill.Master, this.MySkill.Master.MyTeam),
                Skill.TempSkill(ModItemKeys.Skill_Saber_lingzhou_3, this.MySkill.Master, this.MySkill.Master.MyTeam)
            };
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.TargetEffectSelect, false, false, true, false, true));
        }
        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.FreeUse = true;
            Mybutton.CharData.UseSkill(Mybutton.Myskill, this.TargetTemp);
        }
        public override IEnumerator DrawAction()
        {
            BattleSystem.instance.AllyTeam.Draw();
            return base.DrawAction();
        }
        private BattleChar TargetTemp;
    }
}
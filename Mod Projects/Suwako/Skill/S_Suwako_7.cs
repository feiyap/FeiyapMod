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
using BasicMethods;
namespace Suwako
{
    /// <summary>
    /// 土著神「七石七木」
    /// 生成1个[风灵]和1个[南风灵]。
    /// <color=#008B45>旋回</color> - 选择手中1个技能放回牌库，抽取1个技能。
    /// </summary>
    public class S_Suwako_7:Skill_Extended, IP_SkillSelfToDeck
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_FSL_Common", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            Skill tmpSkill2 = Skill.TempSkill("S_Suwako_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
        }

        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleSystem.DelayInputAfter(Back());
        }

        public IEnumerator Back()
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));

            yield return BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true);

            yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));

            yield return BattleSystem.instance.AllyTeam._Draw();

            yield break;
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.DelayInputAfter(CustomMethods.I_SkillBackToDeck(Mybutton.Myskill, -1, false));
        }
    }
}
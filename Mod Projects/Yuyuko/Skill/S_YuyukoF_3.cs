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
namespace Yuyuko
{
    /// <summary>
    /// 亡舞「生者必灭之理」
    /// 华胥 - 展示牌库中的技能。选择其中1个放逐。
    /// 葬送 - 展示弃牌库中的技能。选择其中1个放逐。
    /// 幽冥蝶 - 施加时，选择手牌中的1个技能放逐。
    /// 人魂蝶 - 施加时，选择倒计时栏中的1个技能放逐。
    /// </summary>
    public class S_YuyukoF_3:Skill_Extended, IP_SkillSelfExcept
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));

            BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true);
        }

        public bool SelfExcept(SkillLocation skillLoaction)
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck);

            BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del2), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true);
            return true;
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Except();
        }

        public void Del2(SkillButton Mybutton)
        {
            Mybutton.Myskill.Except();
        }
    }
}
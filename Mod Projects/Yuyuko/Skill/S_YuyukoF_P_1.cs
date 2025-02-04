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
	/// <color=#FF1493>亡乡「亡我乡 -彷徨的灵魂-」</color>
	/// 仅能选择拥有幽冥蝶和人魂蝶关键词的技能。
	/// 放逐目标技能，将其转化为1个技能对应的减益效果施加在任意敌人身上。
	/// </summary>
    public class S_YuyukoF_P_1:Skill_Extended
    {
        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = true;
            if (ExceptSkill.MySkill.PlusKeyWords.Exists(t => t.Key == "Keyword_ButterflyM" ||  t.Key == "Keyword_ButterflyR"))
            {
                isLucyD = false;
            }
            return isLucyD;
        }

        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_YuyukoF_P_1_1");
            this.ChoiceSkillList.Add("S_YuyukoF_P_1_2");
        }

        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            //BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(-50 * Targets[0].AP);

            //Targets[0].Except();
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_S = Targets[0];

            BattleSystem.instance.TargetSelecting = true;
            BattleSystem.instance.SelectedSkill = this.MySkill;
            BattleSystem.instance.ActionAlly = (this.MySkill.Master as BattleAlly);
            List<Skill> choiceSkillList = new List<Skill>();

            foreach (string key in this.ChoiceSkillList)
            {
                Skill skill = Skill.TempSkill(key, this.BChar, this.BChar.MyTeam);
                choiceSkillList.Add(skill);
            }

            Debug.Log(choiceSkillList.Count);
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(choiceSkillList, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, true));

            this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
        }

        public void Del(SkillButton Mybutton)
        {
            Skill skill = new Skill();
            skill = Mybutton.Myskill.CloneSkill(true, null, null, true);
            ChildClear.Clear(BattleSystem.instance.ActWindow.ItemSkillView);
            GameObject gameObject = ToolTipWindow.SkillToolTip(BattleSystem.instance.ActWindow.ItemSkillView, skill, skill.Master, 0, 1, true, false, false);
            gameObject.transform.SetParent(BattleSystem.instance.ActWindow.ItemSkillView);
            gameObject.transform.Find("PlusTooltip").gameObject.SetActive(false);
            gameObject.GetComponent<SkillToolTip>().LayerDown();
            skill.OriginalSelectSkill = BattleSystem.instance.SelectedSkill;
            BattleSystem.instance.ActionAlly = (Mybutton.Myskill.Master as BattleAlly);
            ToolTipWindow.ToolTip = null;
            BattleSystem.instance.ItemSelect = true;
            BattleSystem.instance.TargetSelect(skill, skill.Master);
        }
    }
}
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
namespace KirisameMarisa
{
	/// <summary>
	/// 魔开「Open Universe」
	/// 本技能在弃牌库中时，费用增加4点。
	/// 查看弃牌库最上面的3个技能，并选择其中1个技能。所选技能费用增加2点，并获得“无视防御，造成的伤害翻倍”的效果。
	/// </summary>
    public class S_KirisameMarisa_7: SkillBase_KirisameMarisa
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            int num = 0;
            int num2 = 0;
            while (num2 < BattleSystem.instance.AllyTeam.Skills_UsedDeck.Count && num < 3)
            {
                list.Add(BattleSystem.instance.AllyTeam.Skills_UsedDeck[num2]);
                num++;
                num2++;
            }
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ModManager.getModInfo("KirisameMarisa").localizationInfo.SystemLocalizationUpdate("S_KirisameMarisa_7"), false, true, true, false, true));
        }
        
        private void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.ExtendedAdd_Battle("SE_KirisameMarisa_7");
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar != null && this.BChar is BattleAlly)
            {
                BattleAlly battleAlly = this.BChar as BattleAlly;
                if (BattleSystem.instance.AllyTeam.Skills.Find((Skill a) => a == this.MySkill) != null || (battleAlly.MyBasicSkill != null && battleAlly.MyBasicSkill.buttonData != null && battleAlly.MyBasicSkill.buttonData.CharinfoSkilldata == this.MySkill.CharinfoSkilldata))
                {
                    this.APChange = 0;
                    return;
                }
                this.APChange = 4;
            }
        }
        
        public override void Init()
        {
            base.Init();
            if (BattleSystem.instance != null)
            {
                this.FixedUpdate();
            }
        }
    }
}
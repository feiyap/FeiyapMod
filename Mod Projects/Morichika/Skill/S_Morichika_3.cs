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
namespace Morichika
{
	/// <summary>
	/// 抵押
	/// 展示牌库中的所有技能。选择并放逐其中 1 个，并恢复 2 点法力值。
	/// 下个回合开始时，将那个技能拿回手中，但失去 1 点法力值。
	/// 使目标技能的持有者获得“保修服务”。
	/// </summary>
    public class S_Morichika_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(BattleSystem.instance.AllyTeam.Skills_Deck, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.instance.AllyTeam.Skills_Deck.Remove(Mybutton.Myskill);
            Mybutton.Myskill.Master.MyTeam.AP += 2;
            Mybutton.Myskill.Master.BuffAdd("B_Morichika_P", this.BChar);

            this.BChar.BuffAdd("B_Morichika_3", this.BChar);

            if (BattleSystem.instance.GetBattleValue<BV_Morichika>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Morichika());
            }

            BattleSystem.instance.GetBattleValue<BV_Morichika>().morichika_3_skill = Mybutton.Myskill;
        }
    }
}
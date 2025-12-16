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
	/// 奇货可居
	/// 战斗开始时，放在牌库最上方。
	/// 展示牌库中的所有技能。选择并抽取其中 1 个。
	/// 使目标技能的持有者获得“保修服务”。
	/// </summary>
    public class S_Morichika_1:Skill_Extended
    {
        public override void BattleStartDeck(List<Skill> Skills_Deck)
        {
            Skills_Deck.Remove(this.MySkill);
            Skills_Deck.Insert(0, this.MySkill);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(BattleSystem.instance.AllyTeam.Skills_Deck, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.Draw(Mybutton.Myskill, null);
            Mybutton.Myskill.Master.BuffAdd("B_Morichika_P", this.BChar);
        }
    }
}
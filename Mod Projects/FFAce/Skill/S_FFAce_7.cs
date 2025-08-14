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
namespace FFAce
{
	/// <summary>
	/// 凛冬之契
	/// 此技能被丢弃时，在手中生成一张[霜月轮转]。
	/// 翻开：选择牌库和手牌中的1张技能丢弃，抽1张卡。
	/// </summary>
    public class S_FFAce_7: SkillBase_Ace
    {
        public override void DiscardSingle(bool Click)
        {
            base.DiscardSingle(Click);

            BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main).BuffAdd("B_FFAce_7", this.BChar);
        }

        public override void AceDraw()
        {
            base.AceDraw();

            Skill tmpSkill = Skill.TempSkill("S_FFAce_5", this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            tmpSkill.AutoDelete = 1;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            //new List<Skill>();
            //List<Skill> list = new List<Skill>();
            //list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill y) => y != this.MySkill && y.Master == this.BChar && y.MySkill.User == this.BChar.Info.KeyData));
            //list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck.FindAll((Skill y) => y != this.MySkill && y.Master == this.BChar && y.MySkill.User == this.BChar.Info.KeyData));
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i].Master.IsLucyNoC || list[i].MySkill.Rare || list[i].Master != this.BChar || list[i] == this.MySkill)
            //    {
            //        list.RemoveAt(i);
            //        i--;
            //    }
            //}

            //BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete();
            this.BChar.MyTeam.Draw();
        }
    }
}
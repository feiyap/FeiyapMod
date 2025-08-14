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
	/// 命运轮抽
	/// 从手中选择丢弃2个技能，然后抽取2个技能：
	/// 若抽到的牌中有攻击牌，则使随机队友的攻击力和治疗力+15%；
	/// 若丢弃的技能中有艾斯的牌，则额外使艾斯获得持续2回合的“攻击力+15%”。
	/// 翻开：展示弃牌库和牌库中所有的自己的普通技能，选择1个技能拿到手中并获得相应的[翻开]效果，1个回合中最多触发1次该效果。
	/// </summary>
    public class S_FFAce_4: SkillBase_Ace
    {
        public int count;
        private List<Skill> list;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill y) => y != this.MySkill));
            for (int i = 0; i < 2; i++)
            {
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.Master == this.BChar)
            {
                this.BChar.BuffAdd("B_FFAce_4_1", this.BChar);
            }
            Mybutton.Myskill.Delete(false);
            list.Remove(Mybutton.Myskill);
            count++;
            if (count == 2)
            {
                count = 0;

                BattleSystem.instance.AllyTeam.Draw(2, new BattleTeam.DrawInput(this.DrawInput));
            }
        }

        public void DrawInput(Skill skill)
        {
            if (skill.IsDamage)
            {
                BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main).BuffAdd("B_FFAce_4", this.BChar);
            }
        }

        public override void AceDraw()
        {
            base.AceDraw();

            if ((this.BChar.BuffReturn("B_FFAce_4_Count")?.StackNum ?? 0) < 2)
            {
                new List<Skill>();
                List<Skill> list = new List<Skill>();
                list.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck);
                list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Master.IsLucyNoC || list[i].MySkill.Rare || list[i].Master != this.BChar)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }

                BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del2), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));

                this.BChar.BuffAdd("B_FFAce_4_Count", this.BChar);
            }
        }

        public void Del2(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill);

            foreach (Skill_Extended se in Mybutton.Myskill.AllExtendeds)
            {
                if (se.Name == Mybutton.Myskill.MySkill.KeyID)
                {
                    (se as SkillBase_Ace).AceDraw();
                }
            }
        }
    }
}
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
	/// 朱雀百式
	/// 抽到这张牌时，使用这张牌的[翻开]效果。
	/// 使用这张牌后，可以选择手中和牌库中最多3张自己的技能丢弃，并获得相应的[翻开]效果。
	/// 翻开：对所有敌人施加[燎原之契]，并从牌库和弃牌库中选择1张自己的技能复制，复制的技能带有放逐词条。
	/// </summary>
    public class S_FFAce_Rare_1: SkillBase_Ace
    {
        public int count;
        private List<Skill> list;

        //public override IEnumerator DrawAction()
        //{
        //    this.AceDraw();
        //    return base.DrawAction();
        //}

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill y) => y != this.MySkill && y.Master == this.BChar && y.MySkill.User == this.BChar.Info.KeyData && !y.MySkill.Rare));
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck.FindAll((Skill y) => y != this.MySkill && y.Master == this.BChar && y.MySkill.User == this.BChar.Info.KeyData && !y.MySkill.Rare));
            for (int i = 0; i < 3; i++)
            {
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, true, true, true, false, true));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete(false);
            foreach (Skill_Extended se in Mybutton.Myskill.AllExtendeds)
            {
                if (se.Name == Mybutton.Myskill.MySkill.KeyID)
                {
                    (se as SkillBase_Ace).AceDraw();
                }
            }
            list.Remove(Mybutton.Myskill);
            count++;
        }

        public override void AceDraw()
        {
            base.AceDraw();

            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                be.BuffAdd("B_FFAce_Rare_1", this.BChar);
            }

            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck);
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master.IsLucyNoC || list[i].Master != this.BChar)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del2), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }

        public void Del2(SkillButton Mybutton)
        {
            Skill tmpSkill = Mybutton.Myskill.CloneSkill(false,null,null,true);
            tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}
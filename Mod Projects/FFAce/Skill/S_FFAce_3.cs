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
	/// 零式预判
	/// 抽到这张牌时，使用这张牌的[翻开]效果。
	/// 翻开：从弃牌库中选择1张调查员的普通技能置入手中并减少1费。1个回合中最多触发2次该效果。
	/// </summary>
    public class S_FFAce_3: SkillBase_Ace
    {
        //public override IEnumerator DrawAction()
        //{
        //    this.AceDraw();
        //    return base.DrawAction();
        //}

        public override void AceDraw()
        {
            base.AceDraw();

            if ((this.BChar.BuffReturn("B_FFAce_3_Count")?.StackNum ?? 0) < 2)
            {
                new List<Skill>();
                List<Skill> list = new List<Skill>();
                list.AddRange(BattleSystem.instance.AllyTeam.Skills_UsedDeck);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Master.IsLucyNoC || list[i].MySkill.Rare || list[i].Master != this.BChar)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }

                BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));

                this.BChar.BuffAdd("B_FFAce_3_Count", this.BChar);
            }
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.APChange -= 1;
            Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill);
        }
    }
}
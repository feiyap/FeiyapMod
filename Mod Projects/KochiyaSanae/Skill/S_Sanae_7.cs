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
namespace KochiyaSanae
{
	/// <summary>
	/// 开海「海水分开之日」
	/// 从弃牌堆将1张1费或以下的技能拿回手中。
	/// </summary>
    public class S_Sanae_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();
            list.AddRange(this.BChar.MyTeam.Skills_UsedDeck);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AP > 1)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            if (list.Count != 0)
            {
                BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            BattleTeam.DrawInput input = null;
            Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill, input);
        }
    }
}
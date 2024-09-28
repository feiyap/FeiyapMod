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
namespace HatsuneMiku
{
	/// <summary>
	/// 深海少女
	/// 从弃牌堆将1个技能加入手卡。自己获得AP相同数字层数的[未来之音]。
	/// 音律3：使那个技能AP-1。
	/// 音律9：使那个技能AP-10。
	/// </summary>
    public class S_HatsuneMiku_8:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            //this.SelfBuff = null;

            List<Skill> list = new List<Skill>();
            list.AddRange(this.BChar.MyTeam.Skills_UsedDeck);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MySkill.KeyID == "S_HatsuneMiku_8")
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

            for (int i = 0; i < Mybutton.Myskill.AP; i++)
            {
                this.BChar.BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }

            Skill_Extended skill_Extended = new Skill_Extended();

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 3)
            {
                skill_Extended.APChange = -1;
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 9)
            {
                skill_Extended.APChange = -10;
            }

            Mybutton.Myskill.ExtendedAdd(skill_Extended);
        }
    }
}
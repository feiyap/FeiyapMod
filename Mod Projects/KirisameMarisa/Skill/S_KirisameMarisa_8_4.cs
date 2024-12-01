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
	/// 天仪「Orrery's Universe」
	/// <color=#00BFFF>危险等级4</color> - 获得2次等待次数。
	/// 确认弃牌库中自己的技能，选择 1 个加入手中。
	/// </summary>
    public class S_KirisameMarisa_8_4: S_KirisameMarisa_8_2
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<Skill> list = new List<Skill>();
            list.AddRange(this.BChar.MyTeam.Skills_UsedDeck);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master != this.BChar)
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
            Mybutton.Myskill.Master.MyTeam.ForceDrawF(Mybutton.Myskill);
        }
    }
}
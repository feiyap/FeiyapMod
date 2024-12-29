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
namespace HinanawiTenshi
{
	/// <summary>
	/// 气候操纵
	/// </summary>
    public class B_Tenshi_4:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            List<Skill> list = new List<Skill>();

            foreach (String str in tenkiSkillList)
            {
                list.Add(Skill.TempSkill(str, this.BChar, this.BChar.MyTeam));
            }

            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            this.BChar.ParticleOut(Mybutton.Myskill, this.BChar);
            this.SelfDestroy();
        }

        public List<String> tenkiSkillList = new List<string>
        {
            "S_Tenki_1",
            "S_Tenki_2",
            "S_Tenki_3",
            "S_Tenki_4",
            "S_Tenki_5",
            "S_Tenki_6",
            "S_Tenki_7",
            "S_Tenki_8",
            "S_Tenki_9",
            "S_Tenki_10",
            "S_Tenki_11",
            "S_Tenki_12",
            "S_Tenki_13",
            "S_Tenki_14",
            "S_Tenki_15",
            "S_Tenki_16",
            "S_Tenki_17",
            "S_Tenki_18",
            "S_Tenki_19",
            "S_Tenki_20"
        };
    }
}
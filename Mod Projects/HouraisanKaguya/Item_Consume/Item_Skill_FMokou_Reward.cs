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
namespace HouraisanKaguya
{
	/// <summary>
	/// 技能书：不朽的弹幕
	/// 可以学习技能[「不朽的弹幕」]<b></b>。
	/// </summary>
    public class Item_Skill_FMokou_Reward:UseitemBase
    {
        public override bool Use()
		{
			List<string> list = new List<string>();
			list.Add("S_FMokou_Reward");
			List<Skill> list2 = new List<Skill>();
			foreach (string key in list)
			{
				list2.Add(Skill.TempSkill(key, PlayData.BattleLucy, PlayData.TempBattleTeam));
			}
			PlayData.TSavedata.UseItemKeys.Add(GDEItemKeys.Item_Consume_SkillBookLucy);
			FieldSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list2, new SkillButton.SkillClickDel(this.SkillAdd), ScriptLocalization.System_Item.SkillAdd, false, true, true, true, false));
			MasterAudio.PlaySound("BookFlip", 1f, null, 0f, null, null, false, false);
			return base.Use();
		}
        
		public void SkillAdd(SkillButton Mybutton)
		{
			PlayData.TSavedata.LucySkills.Add(Mybutton.Myskill.MySkill.KeyID);
			UIManager.inst.CharstatUI.GetComponent<CharStatV4>().SkillUPdate();
		}
    }
}
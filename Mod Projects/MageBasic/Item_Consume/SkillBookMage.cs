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
namespace MageBasic
{
	/// <summary>
	/// 技能书 - 魔女定式
	/// 只能对魔女型角色使用。
	/// 从所选友军的 5 个专属技能中选择 1 个学习。
	/// 再重复 1 次。
	/// </summary>
    public class SkillBookMage:UseitemBase
    {
        public override bool CantTarget(Character CharInfo)
        {
            return !(CharInfo.GetData.Role.Key == "Role_Mage");
        }

        public override bool Use(Character CharInfo)
        {
            List<Skill> list = new List<Skill>();
            List<BattleAlly> battleallys = PlayData.Battleallys;
            BattleTeam tempBattleTeam = PlayData.TempBattleTeam;
            for (int i = 0 ; i < PlayData.TSavedata.Party.Count ; i++)
            {
                if (CharInfo == PlayData.TSavedata.Party[i])
                {
                    List<GDESkillData> list2 = new List<GDESkillData>();
                    list2.AddRange(PlayData.GetCharacterSkillNoOverLap(PlayData.TSavedata.Party[i], false, null));
                    list2 = list2.RandomSkill(PlayData.TSavedata.Party[i], 5);
                    for (int j = 0 ; j < list2.Count ; j++)
                    {
                        list.Add(Skill.TempSkill(list2[j].Key, PlayData.TSavedata.Party[i].GetBattleChar, PlayData.TempBattleTeam));
                    }
                }
            }
            foreach (Skill skill in list)
            {
                if (!SaveManager.IsUnlock(skill.MySkill.KeyID, SaveManager.NowData.unlockList.SkillPreView))
                {
                    SaveManager.NowData.unlockList.SkillPreView.Add(skill.MySkill.KeyID);
                }
            }
            FieldSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.SkillAdd), ScriptLocalization.System_Item.SkillAdd, false, true, true, true, false));
            FieldSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.SkillAdd), ScriptLocalization.System_Item.SkillAdd, false, true, true, true, false));
            MasterAudio.PlaySound("BookFlip", 1f, null, 0f, null, null, false, false);
            return true;
        }

        public void SkillAdd(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.Info.UseSoulStone(Mybutton.Myskill);
            UIManager.inst.CharstatUI.GetComponent<CharStatV4>().SkillUPdate();
        }
    }
}
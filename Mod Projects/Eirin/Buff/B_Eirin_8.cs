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
namespace Eirin
{
	/// <summary>
	/// 月人/永琳
	/// </summary>
    public class B_Eirin_8:Buff, IP_PlayerTurn_1
    {
        public void Turn1()
        {
            List<GDESkillData> list = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.User == this.BChar.Info.KeyData && !gdeskillData.NoDrop && gdeskillData.KeyID != "S_Eirin_8")
                {
                    list.Add(gdeskillData);
                }
            }
            Skill skill = Skill.TempSkill(list.Random(this.BChar.GetRandomClass().Main).Key, this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.IsWaste = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}
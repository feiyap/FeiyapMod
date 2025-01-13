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
namespace IzayoiSakuya
{
	/// <summary>
	/// 自动扫地机
	/// 装备时，移除所有露西诅咒技能。
	/// </summary>
    public class R_Sakuya_0:PassiveItemBase, PassiveItem_EnableItem
    {
        public void EnableItem()
        {
            new List<Skill>();
            for (int i = 0; i < PlayData.TSavedata.LucySkills.Count; i++)
            {
                if (new GDESkillData(PlayData.TSavedata.LucySkills[i]).User == "LucyCurse")
                {
                    PlayData.TSavedata.LucySkills.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
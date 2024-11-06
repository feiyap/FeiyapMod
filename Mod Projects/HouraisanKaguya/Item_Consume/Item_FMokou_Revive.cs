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
	/// 不死鸟狂想
	/// 复活所有队友。使所有队友体力恢复至最大生命值的一半。
	/// </summary>
    public class Item_FMokou_Revive:UseitemBase
    {
        public override bool Use()
        {
            foreach (Character character in PlayData.TSavedata.Party)
            {
                if (character.Incapacitated)
                {
                    character.Incapacitated = false;
                    character.Hp = 0;
                }
                character.HealHP((int)Misc.PerToNum((float)character.get_stat.maxhp, 50f), true);
            }
            return true;
        }
    }
}
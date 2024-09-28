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
	/// 「永夜归返  -寅时四刻-」
	/// 每次使用「永夜归返」后，「永夜归返」会获得永久增强。
	/// </summary>
    public class S_FKaguya_10Rare_15: SkillExtended_10Rare
    {
        public override bool Terms()
        {
            return true;
        }
    }
}
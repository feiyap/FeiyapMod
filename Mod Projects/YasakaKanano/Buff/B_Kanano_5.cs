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
namespace YasakaKanano
{
	/// <summary>
	/// 庆典之西风
	/// &target每次使用手中的技能时，防御力+10%。
	/// </summary>
    public class B_Kanano_5:Buff, IP_SkillUse_Team
    {
        public void SkillUseTeam(Skill skill)
        {
            this.PlusStat.def += 10;
            if (this.PlusStat.def >= 40)
            {
                this.PlusStat.def = 40;
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&target", this.BChar.Info.Name);
        }
    }
}
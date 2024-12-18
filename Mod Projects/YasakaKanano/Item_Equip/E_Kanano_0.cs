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
	/// 守矢护符
	/// 每次使用手中费用为0的技能时，本回合+5%防御力。
	/// </summary>
    public class E_Kanano_0:EquipBase, IP_SkillUse_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.MaxHP = 20;
            this.PlusStat.dod = 10;
            this.PlusStat.cri = -10;
        }

        public void SkillUseTeam(Skill skill)
        {
            this.BChar.BuffAdd("B_E_Kanano_0", this.BChar);
        }
    }
}
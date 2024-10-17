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
namespace ShameimaruAya
{
	/// <summary>
	/// 天狗团扇
	/// 所有队友每使用6个技能，生成1个[北风灵]。
	/// </summary>
    public class E_ShameimaruAya_0:EquipBase, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 1f;
            this.PlusStat.reg = 1f;
            this.PlusStat.dod = 5f;
        }
        
        public void SKillUseHand_Team(Skill skill)
        {
            this.BChar.BuffAdd("B_E_ShameimaruAya_0", this.BChar, false, 0, false, -1, false);
        }
    }
}
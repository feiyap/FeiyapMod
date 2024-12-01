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
namespace KirisameMarisa
{
	/// <summary>
	/// 无视防御，造成的伤害翻倍
	/// </summary>
    public class SE_KirisameMarisa_7: Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusSkillStat.Penetration = 100f;
            this.PlusSkillPerFinal.Damage = 100;
        }
    }
}
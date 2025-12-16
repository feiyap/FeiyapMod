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
namespace Morichika
{
	/// <summary>
	/// 费用提升 1 点、造成的伤害量/治疗量提升80%。
	/// </summary>
    public class SE_Morichika_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.APChange = 1;
            this.PlusSkillPerFinal.Damage = 80;
            this.PlusSkillPerFinal.Heal = 80;
        }
    }
}
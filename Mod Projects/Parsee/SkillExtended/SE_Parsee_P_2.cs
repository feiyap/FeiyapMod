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
namespace Parsee
{
	/// <summary>
	/// 伤害量、恢复量增加100％。
	/// </summary>
    public class SE_Parsee_P_2: BuffSkillExHand
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillPerFinal.Damage = 100;
            this.PlusSkillPerFinal.Heal = 100;
        }
    }
}
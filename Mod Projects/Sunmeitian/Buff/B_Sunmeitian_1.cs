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
namespace Sunmeitian
{
	/// <summary>
	/// 真假猴王
	/// </summary>
    public class B_Sunmeitian_1:Buff, IP_Dodge
    {
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                base.SelfDestroy(false);
            }
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.PerfectDodge = true;
        }
    }
}
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
namespace MinamiRio
{
	/// <summary>
	/// 百发百中
	/// </summary>
    public class B_MinamiRio_7:Buff
    {
        public void CriPerChange(Skill skill, BattleChar Target, ref float CriPer)
        {
            if (Target.NullCheck())
            {
                return;
            }
            int num = Target.HitPerNum(skill.Master, skill, false);
            int num2 = 0;
            if (num > 100)
            {
                num2 = num - 100;
            }
            if (num2 > 0)
            {
                CriPer += (float)num2;
            }
        }
        
        public override void Init()
        {
            base.Init();
            this.PlusStat.HitMaximum = true;
            this.PlusStat.hit = 50f;
        }
    }
}
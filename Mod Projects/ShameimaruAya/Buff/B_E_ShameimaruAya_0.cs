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
	/// 风来的山风
	/// 叠加至6层时，生成1个[北风灵]。
	/// </summary>
    public class B_E_ShameimaruAya_0:Buff
    {
        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (base.StackNum >= 6)
                {
                    base.SelfDestroy(false);
                }
            }
        }
        
        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            Skill skill = new Skill();
            skill.Init(new GDESkillData("S_Shameimaru_P"), this.BChar, this.BChar.MyTeam);
            this.BChar.MyTeam.Add(skill, true);
        }
    }
}
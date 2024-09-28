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
	/// 腾云驾雾
	/// 手中技能减少1点费用。
	/// </summary>
    public class B_Sunmeitian_2:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = new B_BrokenArrow_0();
        }
        
        public void SKillUseHand_Team(Skill skill)
        {
            base.SelfStackDestroy();
        }
    }
}
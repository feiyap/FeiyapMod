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
namespace HakureiReimu
{
	/// <summary>
	/// 赤色杀人魔！
	/// 伤害增加&a%。
	/// </summary>
    public class SE_Musoutensei_Daiyousei_0: BuffSkillExHand
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.MainBuff != null)
            {
                this.PlusSkillPerFinal.Damage = 10 * this.MainBuff.StackNum;
            }
        }
        
        public override string ExtendedDes()
        {
            return base.ExtendedDes().Replace("&a", (10 * this.MainBuff.StackNum).ToString());
        }
    }
}
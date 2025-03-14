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
	/// 危险冲动
	/// 速度大于0时，每多1点提供“+10%暴击率，+10%暴击伤害”。
	/// </summary>
    public class B_KirisameMarisa_9:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.spd = 2 * StackNum;
        }

        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                int count = PlayData.PartySpeed;
                if (count > 5)
                {
                    count = 5;
                }
                if (PlayData.PartySpeed > 0)
                {
                    this.PlusStat.cri = count * 10;
                    this.PlusStat.PlusCriDmg = count * 10;
                }
            }
        }
    }
}
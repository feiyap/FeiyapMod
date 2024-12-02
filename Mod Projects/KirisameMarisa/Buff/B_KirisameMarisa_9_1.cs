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
	/// 危险本能
	/// 速度小于0时，每次受到伤害时进行一次&a点伤害的反击<color=#FF7A33>(攻击力的25% * 速度的绝对值)</color>。
	/// </summary>
    public class B_KirisameMarisa_9_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.spd = -2 * StackNum;
        }

        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                int count = -PlayData.PartySpeed;
                if (count > 10)
                {
                    count = 10;
                }
                if (PlayData.PartySpeed < 0)
                {
                    this.PlusStat.cri = count * 5;
                }
            }
        }
    }
}
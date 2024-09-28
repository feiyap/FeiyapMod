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
namespace Mokou
{
	/// <summary>
	/// 火焰身躯
	/// 被击中时给双方施加2层烧伤。
	/// </summary>
    public class B_Mokou_S_2:Buff,IP_Hit
    {
        public override void Init()
        {
            base.Init();
        }
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (base.Usestate_F.GetStat.HIT_DOT + 100f).ToString());
        }
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1)
            {
                SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}
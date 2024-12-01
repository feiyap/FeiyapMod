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
	/// 危险信号
	/// 受到攻击后减少一层。
	/// </summary>
    public class B_KirisameMarisa_6:Buff, IP_Hit
    {
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (SP.UseStatus.Info.Ally != this.BChar.Info.Ally && Dmg > 0)
            {
                base.SelfStackDestroy();
            }
        }
        
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -base.Usestate_L.GetStat.atk * 2.5f;
            this.PlusStat.spd = -2;
            this.isStackDestroy = true;
        }
    }
}
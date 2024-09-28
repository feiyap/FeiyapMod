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
namespace saber
{
	/// <summary>
	/// 断钢
	/// 全部的护甲已被击碎！
	/// </summary>
    public class Saber_jisui:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -100f;
        }
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1)
            {
                base.SelfStackDestroy();
            }
        }
    }
}
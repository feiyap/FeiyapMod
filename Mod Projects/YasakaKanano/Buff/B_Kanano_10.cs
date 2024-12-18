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
namespace YasakaKanano
{
	/// <summary>
	/// 天龙之西风
	/// 受到攻击时减少1层，恢复1点法力值。
	/// </summary>
    public class B_Kanano_10:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
            this.PlusStat.crihit = -50;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1)
            {
                this.BChar.MyTeam.AP++;
                base.SelfStackDestroy();
            }
        }
    }
}
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
namespace RemiliaScarlet
{
    /// <summary>
    /// 摇篮曲
	/// 受击概率略微提升；防御力提升25%；受击时赋予1层「绯夜」。
    /// </summary>
    public class B_RemiliaScarlet_4 : Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.AggroPer = 10 * StackNum;
            this.PlusStat.def = 5f * StackNum;
        }

        public override void BuffStat()
        {
            base.BuffStat();
            this.PlusStat.AggroPer = 10 * StackNum;
            this.PlusStat.def = 5f * StackNum;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1 && !SP.UseStatus.Info.Ally)
            {
                SP.UseStatus.BuffAdd("B_RemiliaScarlet_0", this.BChar, false, 0, false, -1, false);
                base.SelfStackDestroy();
            }
        }
    }
}
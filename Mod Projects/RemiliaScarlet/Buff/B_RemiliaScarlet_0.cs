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
    /// 绯夜
    /// 每回合5点痛苦伤害。受到痛苦伤害时，会治疗施加者5点体力。1回合最多触发1次。
    /// </summary>
    public class B_RemiliaScarlet_0: Buff
    {
        public override void Init()
        {
            base.Init();
        }

        public override void TurnUpdate()
        {
            base.TurnUpdate();

            base.Usestate_L.Heal(base.Usestate_L, 5 * this.StackNum, false, false, null);
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&user", base.Usestate_L.Info.Name);
        }
    }
}
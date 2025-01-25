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
    /// 魇月癫乱
    /// 使持有的所有减益的每回合伤害量提升33%。
    /// </summary>
    public class B_RemiliaScarlet_2:Buff, IP_BuffUpdate
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.DMGTaken = 5;
        }

        public void BuffUpdate(Buff MyBuff)
        {
            if (!MyBuff.BChar.Info.Ally)
            {
                if (MyBuff.BuffExtended.Find((Buff_Ex a) => a.BuffExKey == "B_RemiliaScarlet_2_BuffEx") == null)
                {
                    MyBuff.AddBuffEx(new B_RemiliaScarlet_2_BuffEx());
                }
            }
        }
    }
}
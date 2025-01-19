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
namespace HinanawiTenshi
{
    public class R_Tenshi_0:PassiveItemBase, IP_BuffAddAfter
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            if (!addedbuff.BuffData.Debuff && stackBuff.RemainTime != 0 && stackBuff.RemainTime >= 2)
            {
                stackBuff.RemainTime++;
                base.ShinyEffect();
            }
            if (addedbuff.BuffData.Debuff && stackBuff.RemainTime != 0 && stackBuff.RemainTime >= 2)
            {
                stackBuff.RemainTime--;
                base.ShinyEffect();
            }
        }
    }
}
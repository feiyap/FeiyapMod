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
namespace Ralmia
{
	/// <summary>
	/// 创造物种类
	/// </summary>
    public class B_Ralmia_P: Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            int count = 0;
            if (this.BChar.BuffFind("B_Ralmia_3", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_4", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_5", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_6", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_7", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_8", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_9", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_10Rare", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare_0", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare_1", false))
            {
                count++;
            }
            if (this.BChar.BuffFind("B_Ralmia_13Rare_2", false))
            {
                count++;
            }
            if (count != 0 && count != this.StackNum)
            {
                this.SelfDestroy();
                for (int i = 0; i < count; i++)
                {
                    this.BChar.BuffAdd("B_Ralmia_P", this.BChar, false, 0, false, -1, false);
                }
            }
        }
    }
}
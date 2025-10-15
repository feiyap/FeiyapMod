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
using DG.Tweening;
namespace Necromancer
{
    /// <summary>
    /// 白骨增生
    /// 根据目标痛苦抵抗率，获得等量防御力减少。
    /// </summary>
    public class B_Necromancer_6 : Buff
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.RES_DOT = -(float)(20 * base.StackNum);
            this.PlusStat.DMGTaken = (float)(20 * base.StackNum);
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BChar.BuffFind("B_S_Necromancer_5"))
            {
                this.PlusStat.Strength = true;
            }
            else
            {
                this.PlusStat.Strength = false;
            }
        }
        public override string DescExtended()
        {
            if (BChar.BuffFind("B_S_Necromancer_5"))
            {
                return base.DescExtended().Replace("#", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_6_1"));
            }
            else
            {
                return base.DescExtended().Replace("#", "");
            }
        }
    }
}
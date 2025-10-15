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
namespace Necromancer
{
    /// <summary>
    /// 精神解放
    /// 无法行动。
    /// 受到的痛苦伤害暴击，此后解除自身。
    /// </summary>
    public class B_Necromancer_7 : Buff, IP_DamageCriCheck
    {
        public void DamageCriCheck(BattleChar Hit, BattleChar User, int Dmg, ref bool Cri, bool Pain, bool NOEFFECT = false)
        {
            if (Dmg <= 3)
            {
                return;
            }
            if (Hit == BChar && Pain == true)
            {
                Cri = true;
                if (this.StackInfo[0].RemainTime <= 1)
                {
                    this.SelfDestroy();
                    return;
                }
                this.StackInfo[0].RemainTime -= 1;
            }
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.Stun = true;
        }
        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            
        }
    }
}
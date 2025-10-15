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
    /// 血肉活化
    /// 受到痛苦伤害时，回复50%（攻击力）点生命值，然后持续回合-1。
    /// </summary>
    public class B_Necromancer_5 : Buff, IP_DamageTake, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            if (BChar.BuffFind("B_S_Necromancer_5") && this.BChar.HP <= 0)
            {
                this.BChar.HP = 1;
                BChar.BuffRemove("B_S_Necromancer_5");
            }
        }
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (NODEF == true)
            {
                BattleSystem.DelayInput(Action());
                if (this.StackInfo[0].RemainTime <= 1)
                {
                    this.SelfDestroy();
                    return;
                }
                this.StackInfo[0].RemainTime -= 1;
                //Debug.Log(this.StackInfo[0].RemainTime);
            }
        }
        public IEnumerator Action()
        {
            yield return new WaitForSeconds(.3f);
            BChar.Heal(this.Usestate_F, (this.Usestate_F.GetStat.atk * .5f + 3) * StackNum, false);
            yield break;
        }
        public override string DescExtended()
        {
            if (BChar.BuffFind("B_S_Necromancer_5"))
            {
                return base.DescExtended().Replace("#", ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_5_1")).Replace("&a", ((int)((Usestate_F.GetStat.atk * .5f + 3) * StackNum)).ToString());
            }
            else
            {
                return base.DescExtended().Replace("#", "").Replace("&a", ((int)((Usestate_F.GetStat.atk * .5f + 3) * StackNum)).ToString());
            }
        }
        public void HPChange(BattleChar Char, bool Healed)
        {
            if (BChar.BuffFind("B_S_Necromancer_5") && this.BChar.HP <= 0)
            {
                this.BChar.HP = 1;
                BChar.BuffRemove("B_S_Necromancer_5");
            }
        }
    }
}
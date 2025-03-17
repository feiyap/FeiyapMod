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
namespace FFAce
{
	/// <summary>
	/// 冰冻
	/// 无法行动。
	/// 当受到物理攻击时，受到&a点伤害(&user攻击力的170%)，并解除该减益。
	/// </summary>
    public class B_FFAce_5_Ex:Buff, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Stun = true;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (!NODEF)
            {
                this.BChar.Damage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 1.7), true, true);
                base.SelfDestroy(false);
            }
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

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name)
                                      .Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1.7f)).ToString());
        }
    }
}
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
	/// 朱雀之怒
	/// 叠加至3层时，&user攻击该目标后获得1层[赤红之炎]，并额外造成&a点伤害(&user攻击力的150%)，并施加100%成功率的1回合眩晕，然后解除该减益。
	/// </summary>
    public class B_FFAce_2_1:Buff, IP_Hit
    {
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (this.StackNum == 3 && SP.SkillData.Master == this.Usestate_F)
            {
                this.Usestate_F.BuffAdd("B_FFAce_0", this.Usestate_F);
                this.BChar.Damage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 1.5f), true);
                this.BChar.BuffAdd("B_Common_Rest", this.Usestate_F, false, 100);
                this.SelfDestroy();
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name)
                                      .Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1.5f)).ToString());
        }
    }
}
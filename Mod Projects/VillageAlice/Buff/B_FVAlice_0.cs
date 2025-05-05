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
namespace VillageAlice
{
	/// <summary>
	/// 噩梦
	/// 无法行动。
	/// 返回[现实]时，受到125%攻击力的混乱伤害，然后减少一层。
	/// </summary>
    public class B_FVAlice_0:Buff, IP_ChangeReality
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Stun = true;
        }

        public void ChangeReality(bool istrue)
        {
            if (!istrue)
            {
                this.BChar.ChaosDamage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 1.25f), false);
                this.SelfStackDestroy();
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1.25f)).ToString());
        }
    }
}
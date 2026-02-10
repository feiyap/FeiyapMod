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
namespace FeiyapTank
{
    /// <summary>
    /// 皮开肉绽
    /// 受到痛苦伤害提升40%。
    /// </summary>
    public class B_FeiyapTank_1:Buff, IP_DamageTakeChange
    {
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (!NODEF)
            {
                return Dmg;
            }
            else
            {
                return (int)(Dmg * 1.4f);
            }
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
    }
}
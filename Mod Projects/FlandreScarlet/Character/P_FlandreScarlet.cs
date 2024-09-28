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
namespace FlandreScarlet
{
	/// <summary>
	/// 芙兰朵露
	/// Passive:
	/// 芙兰朵露拥有将一切悉数破坏程度的能力。每1级额外增加自己10%暴击伤害。
	/// 禁忌欲望 - 芙兰朵露在体力值低于最大体力值的一半时，部分技能会获得额外效果。
	/// 禁忌狂乱 - 芙兰朵露受到来自自己或队友的伤害累计一定次数后，部分技能会获得额外效果。
	/// </summary>
    public class P_FlandreScarlet:Passive_Char, IP_BattleStart_Ones, IP_HPChange, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            this.BChar.BuffAdd("B_FlandreScarlet_P", this.BChar, true, 0, false, -1, false);
            if (!this.BChar.BuffFind("B_FlandreScarlet_P_V", false))
            {
                if (this.BChar.HP <= this.BChar.GetStat.maxhp * 0.5)
                {
                    this.BChar.BuffAdd("B_FlandreScarlet_P_V", this.BChar, false, 0, false, -1, false);
                }
            }
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char != this.BChar)
            {
                return;
            }
            if (Char.BuffFind("B_FlandreScarlet_P_V", false))
            {
                if (Char.HP > this.BChar.GetStat.maxhp * 0.5)
                {
                    Char.BuffRemove("B_FlandreScarlet_P_V", false);
                }
            }
            else
            {
                if (Char.HP <= this.BChar.GetStat.maxhp * 0.5)
                {
                    Char.BuffAdd("B_FlandreScarlet_P_V", Char, false, 0, false, -1, false);
                }
            }
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (User.Info.Ally)
            {
                this.BChar.BuffAdd("B_FlandreScarlet_P_K", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}
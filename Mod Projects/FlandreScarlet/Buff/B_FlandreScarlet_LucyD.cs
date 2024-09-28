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
	/// 禁忌果实
	/// 受到伤害时恢复25%伤害量的体力，每次受到伤害抽取1个技能（最多触发4次）。
	/// </summary>
    public class B_FlandreScarlet_LucyD:Buff, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 10f;
            count = 0;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg >= 1)
            {
                this.BChar.Heal(this.BChar, (float)((int)((float)Dmg * 0.25f)), false, false, null);
                if (count < 4)
                {
                    BattleSystem.instance.AllyTeam.Draw();
                    count++;
                }
            }
        }

        int count;
    }
}
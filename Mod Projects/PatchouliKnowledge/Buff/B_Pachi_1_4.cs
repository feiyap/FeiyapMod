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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 活体护甲
	/// 回合结束时恢复 &a 点体力值(&user防御力的50%)。
	/// 受到伤害时生成 &a 保护罩(&user防御力的50%)，并减少 1 层。
	/// </summary>
    public class B_Pachi_1_4:Buff, IP_TurnEnd, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 25 + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1] * 10;
            this.PlusStat.spd = -1;
        }

        public void TurnEnd()
        {
            int num = (int)this.Usestate_F.GetStat.def * (int)(0.5 + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4] * 0.1);
            this.BChar.Heal(this.Usestate_F, 0, num, 0);
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar && Dmg > 0)
            {
                int num = (int)this.Usestate_F.GetStat.def * (int)(0.5 + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4] * 0.1);
                this.BChar.BuffAdd("B_Pachi_Barrier", this.Usestate_F).BarrierHP += num;
                this.SelfStackDestroy();
            }
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&user", this.Usestate_F.Info.Name)
                                            .Replace("&a", ((int)this.Usestate_F.GetStat.def * 0.5).ToString());
        }
    }
}
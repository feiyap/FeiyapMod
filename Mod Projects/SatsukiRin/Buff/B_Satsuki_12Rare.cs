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
namespace SatsukiRin
{
	/// <summary>
	/// 风花艳月
	/// 持续时间内受到的所有伤害和治疗效果将在效果结束后结算，其中治疗效果加倍结算。
	/// </summary>
    public class B_Satsuki_12Rare:Buff, IP_DamageTakeChange, IP_HealChange
    {
        public int dmgCount;
        public int healCount;

        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_DOT = 300f;
            this.PlusStat.RES_CC = 300f;
            this.PlusStat.RES_DEBUFF = 300f;
            dmgCount = 0;
            healCount = 0;
        }

        public override void BuffStat()
        {
            base.BuffStat();
            //this.PlusStat.CantHeal = true;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            dmgCount += Dmg;
            Dmg = 0;
            return Dmg;
        }

        public void HealChange(BattleChar Healer, BattleChar HealedChar, ref int HealNum, bool Cri, ref bool Force)
        {
            healCount += HealNum;
            HealNum = 0;
        }

        public void SelfDestoryPlus()
        {
            BattleSystem.DelayInput(Promise());
        }

        public override void DestroyByTurn()
        {
            base.DestroyByTurn();
            BattleSystem.DelayInput(Promise());
        }

        public IEnumerator Promise()
        {
            yield return new WaitForSecondsRealtime(0.2f);

            if (healCount * 2 > dmgCount)
            {
                this.BChar.Heal(this.Usestate_F, healCount * 2 - dmgCount, false, true, null);
            }
            else
            {
                this.BChar.Damage(this.Usestate_F, dmgCount - healCount * 2, false, true, false, 0, false, false, false);
            }

            yield return new WaitForFixedUpdate();
            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("%a", (dmgCount).ToString()).Replace("%b", (healCount).ToString());
        }
    }
}
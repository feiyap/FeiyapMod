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
namespace HakureiReimu
{
	/// <summary>
	/// 发热巫女
	/// 自身拥有的每种增益使这个增益获得“+5%攻击力、+5%暴击率、+5%暴击伤害”。
	/// </summary>
    public class B_Musoutensei_Lilywhite_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                int count = CheckBuffNum();

                this.PlusPerStat.Damage = 5 * count;
                this.PlusStat.cri = 5 * count;
                this.PlusStat.PlusCriDmg = 5 * count;
            }
        }

        public int CheckBuffNum()
        {
            int count = 0;

            count = this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false).Count;

            return count;
        }
    }
}
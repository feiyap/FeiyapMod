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
namespace Parsee
{
	/// <summary>
	/// 爱
	/// 叠加到7层时，全体友军恢复帕露西33%治疗力的生命值，然后层数变化为1。
	/// </summary>
    public class B_Parsee_Rare_2_2:Buff
    {
        public override void Init()
        {
            int heal = (int)(this.BChar.GetStat.reg * 0.33);

            if (this.StackNum == 7)
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    bc.Heal(this.BChar, heal, false);
                }

                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();

                this.BChar.BuffAdd("B_Parsee_Rare_2_3", this.BChar);
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.reg * 0.33)).ToString());
        }
    }
}
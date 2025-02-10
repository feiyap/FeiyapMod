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
namespace Yuyuko
{
	/// <summary>
	/// 死亡的边界
	/// </summary>
    public class B_YuyukoF_Die:Buff, IP_DieListChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.maxhp = -BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().dieList[this.BChar];
            
            if (this.BChar.GetStat.maxhp <= 0)
            {
                this.BChar.Dead();
            }
        }

        public void DieListChange()
        {
            this.PlusStat.maxhp = -BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().dieList[this.BChar];

            if (this.BChar.GetStat.maxhp <= 0)
            {
                this.BChar.Dead();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (this.BChar.GetStat.maxhp <= 0)
            {
                this.BChar.Dead();
            }
        }
    }
}
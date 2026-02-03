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
namespace HiHouClab
{
	/// <summary>
	/// 结界发生器
	/// 持有保护罩时，防御力+30%。
	/// </summary>
    public class E_Maribel_0:EquipBase
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.reg = 2;
            this.PlusStat.RES_CC = 40f;
            this.PlusStat.RES_DEBUFF = 40f;
            this.PlusStat.RES_DOT = 40f;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BarrierHP >= 1)
            {
                this.PlusStat.def = 30;
            }
            else
            {
                this.PlusStat.def = 0;
            }
        }
    }
}
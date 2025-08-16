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
namespace FAlice
{
	/// <summary>
	/// 试验中「歌莉娅人形」
	/// </summary>
    public class B_FAlice_Rare_3_0 : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 5;
            this.PlusStat.reg = 5;
            this.PlusStat.maxhp = 10;
            this.PlusStat.cri = 40;
            this.PlusStat.dod = 40;
            this.PlusStat.DeadImmune = 80;
            this.NoShowTimeNum_Tooltip = true;
        }
    }
}
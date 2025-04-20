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
namespace FFAce
{
	/// <summary>
	/// 燎原之契
	/// </summary>
    public class B_FFAce_Rare_1:Buff
    {
        public override void Init()
        {
            base.Init();
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (!this.Usestate_F.BuffFind("B_FFAce_Rare_1_0", false))
            {
                (this.Usestate_F.BuffAdd("B_FFAce_Rare_1_0", this.BChar) as B_FFAce_Rare_1_0).Mainbuff = this;
            }
        }

        public override string DescExtended()
        {
            string user = "施法者";
            if (BattleSystem.instance != null)
            {
                user = this.Usestate_F.Info.Name;
            }

            return base.DescExtended().Replace("&user", user);
        }
    }
}
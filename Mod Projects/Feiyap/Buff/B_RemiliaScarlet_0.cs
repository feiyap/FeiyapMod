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
namespace Feiyap
{
	/// <summary>
	/// <sprite name="Feiyap_blood"><color=#FF3030>绯夜</color>
	/// </summary>
    public class B_RemiliaScarlet_0:Buff
    {
        public override void Init()
        {
            base.Init();
        }

        public override void TurnUpdate()
        {
            base.TurnUpdate();

            base.Usestate_L.Heal(base.Usestate_L, this.DotDMGView() * 0.25f, true, true, null);
        }

        public override string DescExtended()
        {
            string username = "绯夜氏";
            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&user", username);
        }
    }
}
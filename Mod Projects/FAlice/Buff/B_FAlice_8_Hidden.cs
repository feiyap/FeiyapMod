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
    public class B_FAlice_8_Hidden : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Stun = true;
        }

        public override void TurnUpdate()
        {
            base.TurnUpdate();
            this.SelfDestroy();
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_Rest, this.BChar, PlusTagPer: 500);
        }
    }
}
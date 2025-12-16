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
namespace Jhin
{
	/// <summary>
	/// 大幕渐起
	/// </summary>
    public class SE_Jhin_Rare_1: BuffSkillExHand, IP_PlayerTurn_1, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            this.SelfDestroy();
        }

        public override bool Terms()
        {
            return this.MySkill.FreeUse;
        }

        public void Turn1()
        {
            this.SelfDestroy();
        }
    }
}
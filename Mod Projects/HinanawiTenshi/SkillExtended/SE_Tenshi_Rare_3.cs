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
namespace HinanawiTenshi
{
	/// <summary>
	/// 绯想天
	/// </summary>
    public class SE_Tenshi_Rare_3:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.NotCount = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if ((this.BChar.MyTeam.AliveChars.Find((BattleChar a) => a.BuffFind("B_Tenshi_Rare_3", false)) == null))
            {
                this.SelfDestroy();
            }
        }
    }
}
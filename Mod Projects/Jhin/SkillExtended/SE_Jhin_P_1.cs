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
	/// 精彩
	/// </summary>
    public class SE_Jhin_P_1: BuffSkillExHand, IP_DamageChange
    {
        int shotnum
        {
            get
            {
                return BattleSystem.instance.GetBattleValue<BV_Jhin_P>().shotNum;
            }
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (shotnum != 1)
            {
                this.SelfDestroy();
                return;
            }
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Cri && !View)
            {
                this.BChar.BuffAdd("B_Jhin_P_1", this.BChar);
                this.BChar.MyTeam.AP += 0;
            }

            return Damage;
        }
    }
}
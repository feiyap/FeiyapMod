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
namespace MinamiRio
{
	/// <summary>
	/// 稳固射击
	/// <color=#48D1CC>单弓</color> - 附带迅速。
	/// <color=#FFD700>和弓</color> - 额外造成&a(35%)伤害。
	/// </summary>
    public class S_MinamiRio_2:Skill_Extended
    {
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_MinamiRio_P1"))
                {
                    this.SkillBasePlus.Target_BaseDMG = 0;
                    this.NotCount = true;
                }
                else if (this.BChar.BuffFind("B_MinamiRio_P2"))
                {
                    this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.35f);
                    this.NotCount = false;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_MinamiRio_P1"))
            {

            }
            else if (this.BChar.BuffFind("B_MinamiRio_P2"))
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.35f);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.35f)).ToString());
        }
    }
}
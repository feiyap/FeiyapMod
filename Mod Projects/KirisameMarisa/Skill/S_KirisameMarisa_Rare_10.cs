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
namespace KirisameMarisa
{
	/// <summary>
	/// 魔炮「Final Master Spark」
	/// </summary>
    public class S_KirisameMarisa_Rare_10: TurnEnhancement, IP_SkillUseHand_Team
    {
        public override bool Terms()
        {
            return this.Active;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill != this.MySkill)
            {
                this.APChange -= skill.AP;
            }
        }

        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                this.MySkill.MySkill.Effect_Target.DMG_Per = 10000;
                if (this.MySkill.AP < 9)
                {
                    for (int i = 9; i > this.MySkill.AP; i--)
                    {
                        this.MySkill.MySkill.Effect_Target.DMG_Per /= 2;
                    }
                }
            }
        }
    }
}
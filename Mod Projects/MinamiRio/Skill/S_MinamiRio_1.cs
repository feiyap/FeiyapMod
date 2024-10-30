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
	/// 快射
	/// <color=#48D1CC>单弓</color> - 本回合内可再次释放1次。
	/// <color=#FFD700>和弓</color> - 降低1点费用。
	/// </summary>
    public class S_MinamiRio_1:Skill_Extended
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
                    this.APChange = 0;
                }
                else if (this.BChar.BuffFind("B_MinamiRio_P2"))
                {
                    this.APChange = -1;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_MinamiRio_P1"))
            {
                Skill tmpSkill = Skill.TempSkill("S_MinamiRio_1", this.BChar, this.BChar.MyTeam);
                tmpSkill.isExcept = true;
                tmpSkill.AutoDelete = 1;
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
            else if (this.BChar.BuffFind("B_MinamiRio_P2"))
            {
                
            }
        }
    }
}
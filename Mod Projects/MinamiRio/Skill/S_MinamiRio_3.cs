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
    /// 瞄准射击
    /// 从[全神贯注]获得的提升翻倍。
    /// <color=#48D1CC>单弓</color> - 如果击杀敌人，消除自身的过载，返还1点法力值。
    /// <color=#FFD700>和弓</color> - 从<color=#FA8072>穿甲</color>获得的提升翻倍。
    /// </summary>
    public class S_MinamiRio_3:Skill_Extended
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
                    this.Counting = 0;
                }
                else if (this.BChar.BuffFind("B_MinamiRio_P2"))
                {
                    this.Counting = 1;
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
                //this.Counting = 1;
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            if (this.BChar.BuffFind("B_MinamiRio_P1"))
            {
                this.BChar.MyTeam.AP += 1;
                this.BChar.Overload = 0;
            }
            
        }
    }
}
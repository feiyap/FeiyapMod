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
namespace KochiyaSanae
{
	/// <summary>
	/// 神风的奇迹
	/// 暴击率+100%。
	/// </summary>
    public class SE_Sanae_Rare12:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillStat.cri = 100f;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (!this.Use && !this.MySkill.IsNowCasting)
                {
                    if (this.MySkill.AP == 0)
                    {
                        if (!(this.BChar.MyTeam.AliveChars.Find((BattleChar a) => a.BuffFind("B_Sanae_Rare12", false)) == null))
                        {
                            return;
                        }
                    }
                    this.SelfDestroy();
                }
            }
        }
        
        public override void SkillUseHand(BattleChar Target)
        {
            this.Use = true;
        }
        
        private bool Use;
    }
}
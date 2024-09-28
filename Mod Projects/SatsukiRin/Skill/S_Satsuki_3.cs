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
namespace SatsukiRin
{
	/// <summary>
	/// 凪息「等待风的日子」
	/// </summary>
    public class S_Satsuki_3:Skill_Extended
    {
        public bool Flag;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int count = 0;

            if (this.BChar.BuffFind("B_Satsuki_0", false))
            {
                this.BChar.BuffRemove("B_Satsuki_0", false);
                Targets[0].BuffAdd("B_Satsuki_0", this.BChar, false, 0, false, -1, false);
                count++;
            }
            if (this.BChar.BuffFind("B_Satsuki_1", false))
            {
                this.BChar.BuffRemove("B_Satsuki_1", false);
                Targets[0].BuffAdd("B_Satsuki_1", this.BChar, false, 0, false, -1, false);
                count++;
            }
            if (this.BChar.BuffFind("B_Satsuki_2", false))
            {
                this.BChar.BuffRemove("B_Satsuki_2", false);
                Targets[0].BuffAdd("B_Satsuki_2", this.BChar, false, 0, false, -1, false);
                count++;
            }
            if (this.BChar.BuffFind("B_Satsuki_5", false))
            {
                this.BChar.BuffRemove("B_Satsuki_5", false);
                Targets[0].BuffAdd("B_Satsuki_5", this.BChar, false, 0, false, -1, false);
                count++;
            }
            if (this.BChar.BuffFind("B_Satsuki_6", false))
            {
                this.BChar.BuffRemove("B_Satsuki_6", false);
                Targets[0].BuffAdd("B_Satsuki_6", this.BChar, false, 0, false, -1, false);
                count++;
            }

            for (int i = 0; i < count; i++)
            {
                this.BChar.BuffAdd("B_Satsuki_P", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Satsuki_P", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Satsuki_P", this.BChar, false, 0, false, -1, false);
            }
        }

        public override void FixedUpdate()
        {
            this.Flag = false;
            if (this.BChar.BuffFind("B_Satsuki_0", false) ||
                this.BChar.BuffFind("B_Satsuki_1", false) ||
                this.BChar.BuffFind("B_Satsuki_2", false) ||
                this.BChar.BuffFind("B_Satsuki_5", false) ||
                this.BChar.BuffFind("B_Satsuki_6", false))
            {
                this.Flag = true;
            }
        }

        public override bool Terms()
        {
            return this.Flag;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.reg * 0.3)).ToString());
        }
    }
}
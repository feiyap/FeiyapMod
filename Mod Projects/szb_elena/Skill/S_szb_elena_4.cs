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
namespace szb_elena
{
    /// <summary>
    /// 狐耳神父
    /// 激奏0 - 变为治疗自己&b体力(治疗力的60%)。
    /// </summary>
    public class S_szb_elena_4 : Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&b", ((int)(this.BChar.GetStat.reg * 0.6)).ToString());
        }
        public override void FixedUpdate()
        {
            if (!this.useflag)
            {
                base.FixedUpdate();
                if (this.BChar.MyTeam.AP < this.MySkill.AP)
                {
                    this.isSpecies = true;
                    this.ChangedTarget = GDEItemKeys.s_targettype_Misc;
                    this.APChange = -9;
                }
                else
                {
                    this.isSpecies = false;
                    this.ChangedTarget = GDEItemKeys.s_targettype_enemy;
                    this.APChange = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            this.useflag = true;
            if (this.isSpecies)
            {
                this.BChar.Heal(this.BChar, (float)(this.BChar.GetStat.reg * 0.6), false, false, null);
                return;
            }

            this.BChar.BuffAdd("B_szb_elena_4", this.BChar);
        }
        private bool useflag;
        private bool isSpecies;



    }
}
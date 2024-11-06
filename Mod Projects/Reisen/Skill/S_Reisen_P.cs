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
namespace Reisen
{
	/// <summary>
	/// 长视「赤月下(Infrared Moon)」
	/// </summary>
    public class S_Reisen_P:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.3f));
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if (this.BChar.BuffFind("B_Reisen_P", false) || this.BChar.BuffFind("B_Reisen_6", false) || !this.BChar.BuffFind("B_Reisen_P_Insane", false))
            {
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.IsHeal = true;
                this.IsDamage = false;
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_self);
            }
            else
            {
                this.SkillBasePlus.Target_BaseDMG = PlusDmg;
                this.IsHeal = false;
                this.IsDamage = true;
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            if (this.BChar.BuffFind("B_Reisen_P", false))
            {
                this.BChar.BuffRemove("B_Reisen_P", false);
                this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
                return;
            }
            if (this.BChar.BuffFind("B_Reisen_6", false))
            {
                this.BChar.BuffRemove("B_Reisen_6", false);
                this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
                return;
            }
            if (!this.BChar.BuffFind("B_Reisen_P_Insane", false))
            {
                this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
                return;
            }

            this.SkillBasePlus.Target_BaseDMG = PlusDmg;
            this.BChar.BuffAdd("B_Reisen_P", this.BChar, false, 0, false, -1, false);
            return;
        }
    }
}
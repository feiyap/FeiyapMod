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
namespace VillageAlice
{
	/// <summary>
	/// 现实
	/// 在[现实]中，自身所属技能将【童话】化。
	/// </summary>
    public class B_FVAlice_P:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            foreach (Skill skill in this.BChar.MyTeam.Skills)
            {
                if (skill.Master == this.BChar && skill.ExtendedFind_DataName("SkillExtended_Fairytale") == null && 
                    skill.MySkill.KeyID != "S_DefultSkill_0" && skill.MySkill.KeyID != "S_DefultSkill_1" && skill.MySkill.KeyID != "S_DefultSkill_2" &&
                    skill.MySkill.KeyID != "S_FVAlice_5_0")
                {
                    skill.ExtendedAdd(Skill_Extended.DataToExtended("SkillExtended_Fairytale"));
                }
            }
        }
    }
}
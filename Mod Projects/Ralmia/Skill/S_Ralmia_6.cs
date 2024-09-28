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
namespace Ralmia
{
	/// <summary>
	/// 生命量产
	/// 选择手中的一个创造物技能，使其费用减少1点，增加3张同名卡到牌堆中。
	/// </summary>
    public class S_Ralmia_6:Skill_Extended
    {
        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isArtifact = false;
            if (ExceptSkill.MySkill.KeyID == "S_Ralmia_0" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_1" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_2" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_3" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_10Rare" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_13Rare" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_13Rare_0" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_13Rare_1" ||
                ExceptSkill.MySkill.KeyID == "S_Ralmia_13Rare_2")
            {
                isArtifact = true;
            }
            return !isArtifact;
        }

        public override void SkillTargetSingle(List<Skill> Targets)
        {
            Skill skill2 = Targets[0].CloneSkill(true, null, null, true);
            skill2.isExcept = true;
            Skill skill3 = Targets[0].CloneSkill(true, null, null, true);
            skill3.isExcept = true;
            Skill skill4 = Targets[0].CloneSkill(true, null, null, true);
            skill4.isExcept = true;
            this.BChar.MyTeam.Skills_Deck.InsertRandom(skill2);
            this.BChar.MyTeam.Skills_Deck.InsertRandom(skill3);
            this.BChar.MyTeam.Skills_Deck.InsertRandom(skill4);

            SkillEn_Ralmia_1 extended = new SkillEn_Ralmia_1();
            Targets[0].ExtendedAdd_Battle(extended);
        }
    }
}
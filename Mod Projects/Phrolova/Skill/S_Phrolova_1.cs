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
namespace Phrolova
{
	/// <summary>
	/// 稍纵即逝的梦呓
	/// 从牌库或弃牌库中抽取 1 个“新世界狂想曲”。
	/// 持有“重世”增益时，还会额外优先抽取 1 个自己的技能。
	/// </summary>
    public class S_Phrolova_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Phrolova_2"))
            {
                BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar);
            }

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_UsedDeck)
            {
                if (skill.MySkill.KeyID == "S_Phrolova_2")
                {
                    BattleSystem.instance.AllyTeam.ForceDrawF(skill);
                    return;
                }
            }
            foreach (Skill skill2 in BattleSystem.instance.AllyTeam.Skills_Deck)
            {
                if (skill2.MySkill.KeyID == "S_Phrolova_2")
                {
                    BattleSystem.instance.AllyTeam.ForceDrawF(skill2);
                    return;
                }
            }
        }
    }
}
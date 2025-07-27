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
namespace YorigamiSister
{
	/// <summary>
	/// 散财上钩拳
	/// 这个技能暴击时，从牌库、弃牌库中将1个“疫病神的凭依”拿到手中（若不存在，则生成1个附带放逐的“疫病神的凭依”）。
	/// </summary>
    public class S_Joon_1:Skill_Extended, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (SkillD != this.MySkill)
            {
                return Damage;
            }
            if (Cri && !View)
            {
                bool isExist = false;
                foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_UsedDeck)
                {
                    if (skill.MySkill.KeyID == "S_Joon_0")
                    {
                        BattleSystem.instance.AllyTeam.ForceDrawF(skill);
                        isExist = true;
                        break;
                    }
                }
                foreach (Skill skill2 in BattleSystem.instance.AllyTeam.Skills_Deck)
                {
                    if (skill2.MySkill.KeyID == "S_Joon_0" && !isExist)
                    {
                        BattleSystem.instance.AllyTeam.ForceDrawF(skill2);
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    Skill tmpSkill = Skill.TempSkill("S_Joon_0", this.BChar, this.BChar.MyTeam);
                    tmpSkill.isExcept = true;
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                }
            }

            return Damage;
        }
    }
}
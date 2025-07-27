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
	/// 香奈儿的手包
	/// 随机生成 3 个自己的专属技能，使它们附带放逐。
	/// 这个技能暴击时，还会额外使生成的技能费用降低为 0。
	/// </summary>
    public class S_Joon_3:Skill_Extended, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (View)
            {
                return Damage;
            }
            for (int i = 0; i < 3; i++)
            {
                List<GDESkillData> list = new List<GDESkillData>();
                foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
                {
                    if (gdeskillData.User == this.BChar.Info.KeyData && !gdeskillData.NoDrop)
                    {
                        list.Add(gdeskillData);
                    }
                }
                Skill skill = Skill.TempSkill(list.Random(this.BChar.GetRandomClass().Main).Key, this.BChar, this.BChar.MyTeam);

                if (Cri)
                {
                    skill.APChange = -99;
                }

                skill.isExcept = true;

                BattleSystem.instance.AllyTeam.Add(skill, true);
            }

            return Damage;
        }
    }
}
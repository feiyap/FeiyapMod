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
namespace Parsee
{
	/// <summary>
	/// 「今宵亦在苦候我归的，宇治的桥姬」
	/// 每当队员受到伤害时，该技能的恢复量增加，增加量与所受伤害量相等，最多增加量为自身治疗力的300%。
	/// 倒计时结束后，生成1张“乙姬之恋”。
	/// </summary>
    public class S_Parsee_4:Skill_Extended, IP_DamageTakeChange, IP_SkillCastingQuit
    {
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseHeal = 0;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (User.Info.Ally && !Preview)
            {
                this.SkillBasePlus.Target_BaseHeal += Dmg;
            }

            if (this.SkillBasePlus.Target_BaseHeal >= (int)(3 * this.BChar.GetStat.reg))
            {
                this.SkillBasePlus.Target_BaseHeal = (int)(3 * this.BChar.GetStat.reg);
            }

            return Dmg;
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            Skill tmpSkill = Skill.TempSkill("S_Parsee_4_0", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}
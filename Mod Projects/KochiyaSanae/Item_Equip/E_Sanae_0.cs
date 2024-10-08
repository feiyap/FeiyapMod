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
	/// 奇迹于你
	/// 每个回合第1次使用0费的技能时，生成1个那个的复制，并附加暴击率+100%。
	/// </summary>
    public class E_Sanae_0:EquipBase, IP_PlayerTurn, IP_SkillUse_Team
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 20;
            this.PlusPerStat.Heal = 20;
            count = 0;
        }

        public void Turn()
        {
            count = 0;
        }

        public void SkillUseTeam(Skill skill)
        {
            if (count != 0 || skill.Master != this.BChar)
            {
                return;
            }
            if ((!skill.NotCount && skill.AP <= 1) || skill.AP <= 0)
            {
                this.count++;
                Skill tmpSkill = Skill.TempSkill(skill.MySkill.KeyID, this.BChar, this.BChar.MyTeam);
                tmpSkill.isExcept = true;
                skill.ExtendedAdd(Skill_Extended.DataToExtended("SE_Sanae_E_0"));
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}
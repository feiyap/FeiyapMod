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
	/// “此桥不可渡”
	/// 当手中的技能的数量为0或所有者为同一角色时，立即释放“绝对防御”。
	/// 此效果在战斗中仅限触发1次。
	/// <i><color=#BEBEBE>“宇治桥姬，形单影只。”</color></i>
	/// </summary>
    public class R_Parsee_0:PassiveItemBase, IP_BattleStart_Ones
    {
        public override void FixedUpdate()
        {
            if (!this.flag)
            {
                return;
            }
            this.flame++;
            if (this.flame >= 20 && this.flag)
            {
                base.FixedUpdate();
                this.flame = 0;
                if (!BattleSystem.instance.DelayWait && BattleSystem.instance.ActWindow.On && this.SkillListCheck())
                {
                    this.flag = false;
                    base.ShinyEffect();
                    base.Deactiveitem = true;

                    Skill tmpSkill = Skill.TempSkill("S_Prime_10", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam);
                    tmpSkill.isExcept = true;
                    tmpSkill.FreeUse = true;
                    BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(BattleSystem.instance.AllyTeam.LucyChar, tmpSkill, false, false, true));
                }
            }
        }
        
        public void BattleStart(BattleSystem Ins)
        {
            base.Deactiveitem = false;
            this.flag = true;
        }
        
        public bool SkillListCheck()
        {
            if (BattleSystem.instance.AllyTeam.Skills.Count == 0)
            {
                return true;
            }

            var skills = BattleSystem.instance.AllyTeam.Skills;
            if (skills == null || !skills.Any()) return true;

            var firstMaster = skills.First().Master;
            return skills.All(s =>
                (s.Master == null && firstMaster == null) ||
                (s.Master != null && s.Master.Equals(firstMaster)));
        }
        
        private int flame;
        
        public bool flag;
    }
}
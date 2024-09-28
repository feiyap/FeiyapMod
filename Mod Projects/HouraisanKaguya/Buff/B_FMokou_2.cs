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
namespace HouraisanKaguya
{
	/// <summary>
	/// 不死鸟附体
	/// 释放技能时，在倒计时栏添加[「不死鸟附体 -凤凰奥义-」]。
	/// </summary>
    public class B_FMokou_2:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        
        public IEnumerator Add()
        {
            List<BattleChar> list = new List<BattleChar>();
            Skill skill = Skill.TempSkill("S_FMokou_2_0", this.Usestate_F, this.Usestate_F.MyTeam);
            skill.FreeUse = true;
            list.AddRange((this.Usestate_F as BattleEnemy).Ai.TargetSelect(skill));
            BattleSystem.instance.EnemyCastEnqueue(this.Usestate_F as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);

            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }
        
        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && skill.Master == this.BChar)
            {
                BattleSystem.DelayInputAfter(this.Add());
            }
        }
    }
}
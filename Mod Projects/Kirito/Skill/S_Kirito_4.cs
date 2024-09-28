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
namespace Kirito
{
	/// <summary>
	/// 愤怒刺击
	/// 如果是本回合第1个使用的技能，费用-2。击杀敌人后抽取1张自己的技能。
	/// </summary>
    public class S_Kirito_4:Skill_Extended
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null)
            {
                if (BattleSystem.instance.BattleLogs.getLastSkill(true, true, (BattleLog log) => log.isUsedinHand, (Skill skill) => !skill.FreeUse && !skill.PlusHit) == null)
                {
                    this.APChange = -2;
                    return;
                }
                this.APChange = 0;
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
        }
    }
}
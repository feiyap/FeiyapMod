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
namespace Suwako
{
	/// <summary>
	/// 风雨御射
	/// 每个回合使用第4个技能时，将1个0费的[土著神「御射军神大人」]加入手中。
	/// </summary>
    public class B_Suwako_3:Buff, IP_PlayerTurn
    {
        public bool flag1;

        public override void Init()
        {
            base.Init();
            flag1 = false;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;

                if (CheckUsedSkills(4) && !flag1)
                {
                    flag1 = true;
                    Skill tmpSkill = Skill.TempSkill("S_Suwako_3", this.BChar, this.BChar.MyTeam);
                    tmpSkill.APChange = -3;
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                }
            }
        }

        public bool CheckUsedSkills(int count)
        {
            return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count == count;
        }

        public void Turn()
        {
            flag1 = false;
        }
    }
}
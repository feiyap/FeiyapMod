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
    /// 亚丝娜
    /// 获得+10%命中率。每使用3个技能后优先抽1个桐人的技能，恢复1点法力值。回合结束时，获得1层[准备开饭]：回合开始时，消耗1层恢复5点体力。
    /// </summary>
    public class B_Asuna_P:Buff, IP_TurnEnd, IP_SkillUse_User
    {
        int count;

        public override void Init()
        {
            base.Init();
            this.PlusStat.hit = 10f;
            count = 0;
        }

        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (!SkillD.BasicSkill)
            {
                count++;
                if (count >= 3)
                {
                    BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                    int ap = allyTeam.AP;
                    allyTeam.AP = ap + 1;
                    BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
                    count = 0;
                }
            }
        }

        public void TurnEnd()
        {
            this.BChar.BuffAdd("B_Asuna_P_0", this.BChar, false, 0, false, 1, false);
        }
    }
}
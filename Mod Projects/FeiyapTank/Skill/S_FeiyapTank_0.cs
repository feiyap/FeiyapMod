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
namespace FeiyapTank
{
    /// <summary>
    /// 胧影
    /// 居合 - 以倒计时2对随机敌人释放。
    /// </summary>
    public class S_FeiyapTank_0 : Skill_Extended, IP_Discard
    {
        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (!HandFullWaste && skill == this.MySkill)
            {
                Skill tempSkill = skill.CloneSkill(true, skill.Master, null, false);
                tempSkill.Counting = 2;
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(tempSkill.Master, tempSkill, false, false, false));
            }
        }
    }
}
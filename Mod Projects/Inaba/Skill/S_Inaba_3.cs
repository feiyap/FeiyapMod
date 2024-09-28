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
namespace Inaba
{
	/// <summary>
	/// 兔符「兔子大开花！」
	/// </summary>
    public class S_Inaba_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int num = Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count;
            if (num >= 2)
            {
                List<BattleChar> list = new List<BattleChar>();
                list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars);
                list.Remove(Targets[0]);
                if (list.Count >= 1)
                {
                    Targets.Add(list.Random(this.BChar.GetRandomClass().Main));
                }
            }
        }
    }
}
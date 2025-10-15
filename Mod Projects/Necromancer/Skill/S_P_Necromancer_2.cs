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
namespace Necromancer
{
	/// <summary>
	/// 死亡轻触
	/// 若目标生命值低于50%，额外施加一层生命崩解。
	/// </summary>
    public class S_P_Necromancer_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            //BattleSystem.instance.AllyTeam.AP += 1;
            foreach (BattleChar battleChar in Targets)
            {
                List<Buff> list = new List<Buff>();
                list.AddRange(battleChar.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false));
                list.AddRange(battleChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false));
                foreach (Buff buff in list)
                {
                    battleChar.BuffAdd(buff.BuffData.Key, buff.Usestate_L, false, 300, false, buff.StackInfo[buff.StackInfo.Count - 1].RemainTime, false);
                }
            }
        }
        /*
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach(BattleChar target in Targets)
            {
                if (target.HP <= target.GetStat.maxhp / 2)
                {
                    target.BuffAdd("B_Necromancer_8", BChar);
                }
            }
        }
        */
    }
}
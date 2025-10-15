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
	/// 朽木生花
	/// 若目标生命值未满，则立刻结算血肉活化。
	/// 若目标生命值已满，将固定能力替换为朽骨重肉。
	/// </summary>
    public class S_Necromancer_5:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            BuffTag bufftag = new BuffTag();
            bufftag.BuffData = new GDEBuffData("B_Necromancer_5");
            bufftag.User = this.BChar;
            TargetBuff.Add(bufftag);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
            TargetBuff.Clear();
            bool flag = true;
            foreach (BattleChar BattleChar in Targets)
            {
                if (BattleChar.HP < BattleChar.Recovery)
                {
                    flag = false;
                }
                BattleChar.BuffAdd("B_Necromancer_5", BChar, false, 100);
                if (BattleChar.HP < BattleChar.GetStat.maxhp)
                {
                    BattleChar.Damage(BattleChar, 3, false, true);
                }
            }
            if (flag)
            {
                Skill skill = Skill.TempSkill("S_P_Necromancer_4", BChar, BChar.MyTeam);

                (BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
            }
		}
    }
}
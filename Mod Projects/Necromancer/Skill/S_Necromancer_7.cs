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
	/// 与人间过期通讯二则
	/// 对自身造成（生命上限20%）点痛苦伤害两次。
	/// 将固定能力替换为彻心之痛。
	/// </summary>
    public class S_Necromancer_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
            if (BChar.BuffFind("B_Necromancer_1") == true)
            {
                Skill skill = Skill.TempSkill("S_P_Necromancer_3", BChar, BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Skills_Deck.InsertRandom(BChar.GetRandomClass().Main, skill);
                BChar.Damage(BChar, (int)(BChar.GetStat.maxhp * .5f), false, true);
                return;
            }
            BattleSystem.DelayInput(this.TickDamage());
            BattleSystem.DelayInput(this.TickDamage());
            Skill skill1 = Skill.TempSkill("S_P_Necromancer_3", BChar, BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Skills_Deck.InsertRandom(BChar.GetRandomClass().Main, skill1);
            Skill skill2 = Skill.TempSkill("S_P_Necromancer_3", BChar, BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Skills_Deck.InsertRandom(BChar.GetRandomClass().Main, skill2);

        }
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(BChar.GetStat.maxhp * .2f)).ToString()).Replace("&b", ((int)(BChar.GetStat.maxhp * .5f)).ToString());
        }
        public IEnumerator TickDamage()
        {
            yield return new WaitForSeconds(.3f);
            BChar.Damage(BChar, (int)(BChar.GetStat.maxhp * .2f), false, true);
            yield break;
        }
    }
}
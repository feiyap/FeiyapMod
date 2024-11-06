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
namespace IzayoiSakuya
{
	/// <summary>
	/// 奇术「误导」
	/// 将1个技能放回牌堆底，抽取1个技能。
	/// 月魔术 - 生成1张迅速、一次性、1回合后弃牌的[奇术「误导」]加入手中。这张[奇术「误导」]无法再触发月魔术。
	/// </summary>
    public class S_Sakuya_6: SkillExtended_Sakuya
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            int cost = Targets[0].AP;
            BattleSystem.DelayInputAfter(this.MoveUp(Targets[0]));

            if (CheckLunaMagic())
            {
                BattleSystem.instance.AllyTeam.Draw();
                for (int i = 0; i < cost; i++)
                {
                    BattleSystem.DelayInputAfter(this.Ienum());
                }
            }
        }

        public IEnumerator MoveUp(Skill Temp)
        {
            if (BattleSystem.instance.AllyTeam.Skills.Remove(Temp))
            {
                yield return BattleSystem.instance.ActAfter();
                int num = 0;
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._Add(Temp, true, num));
            }
            yield break;
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Sakuya_6_0", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 0.4f)).ToString());
        }
    }
}
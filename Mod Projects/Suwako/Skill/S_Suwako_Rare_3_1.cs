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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 蛙符「涂有鲜血的赤蛙塚」
	/// 重复释放1次，然后抽取1个技能，并使这个技能获得1层[苏醒]。
	/// </summary>
    public class S_Suwako_Rare_3_1:Skill_Extended
    {
        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = false;
            if (ExceptSkill == this.MySkill || ExceptSkill.MySkill.KeyID == "S_Suwako_Rare_3")
            {
                isLucyD = true;
            }
            return isLucyD;
        }

        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            BattleSystem.instance.StartCoroutine(this.EffectDelaysCo(Targets[0]));

            BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum++;
        }

        private IEnumerator EffectDelaysCo(Skill Target)
        {
            yield return CustomMethods.I_SkillBackToDeck(Target, 0, true);

            while (BattleSystem.instance.ListWait || BattleSystem.instance.Particles.Count != 0 || GameObject.FindGameObjectsWithTag("EffectView").Length != 0 || GameObject.FindGameObjectsWithTag("Tutorial").Length != 0 || BattleSystem.instance.DelayWait)
            {
                yield return new WaitForFixedUpdate();
            }

            yield return this.BChar.MyTeam._Draw();
        }
    }
}
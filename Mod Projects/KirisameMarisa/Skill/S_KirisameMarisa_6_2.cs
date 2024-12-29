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
namespace KirisameMarisa
{
	/// <summary>
	/// 星符「Eccentric Asteroid」
	/// <color=#00BFFF>危险等级2</color> - 额外施加一层[危险信号]。
	/// </summary>
    public class S_KirisameMarisa_6_2: SkillBase_KirisameMarisa
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (Targets[0] is BattleEnemy && (Targets[0] as BattleEnemy).istaunt)
            {
                Targets[0].BuffScriptReturn("Common_Buff_EnemyTaunt").SelfDestroy(false);

                BattleSystem.DelayInputAfter(this.Ienum(Targets[0]));

                return;
            }
        }

        public IEnumerator Ienum(BattleChar hit)
        {
            Skill skill = Skill.TempSkill("S_KirisameMarisa_6_0", this.BChar, this.BChar.MyTeam);

            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;

            yield return new WaitForSecondsRealtime(0.1f);


            foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
            {
                if (!battleEnemy.istaunt)
                {
                    this.BChar.ParticleOut(skill, battleEnemy);
                }
            }

            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.6f)).ToString());
        }
    }
}
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
namespace Yuyuko
{
	/// <summary>
	/// 黄泉蝶
	/// 每次有敌人死亡时，对所有敌人造成&a伤害(攻击力的50%)。
	/// </summary>
    public class B_YuyukoF_Rare_2:Buff, IP_SomeOneDead
    {
        public void SomeOneDead(BattleChar DeadChar)
        {
            if (!DeadChar.Info.Ally)
            {
                BattleSystem.DelayInput(this.Damage());
            }
        }

        public IEnumerator Damage()
        {
            if (this.BChar.BattleInfo.EnemyList.Count != 0)
            {
                yield return new WaitForSecondsRealtime(0.3f);
                Skill skill = Skill.TempSkill("S_YuyukoF_Rare_2_0", this.BChar, this.BChar.MyTeam);
                Skill_Extended skill_Extended = new Skill_Extended();
                skill.FreeUse = true;
                skill.PlusHit = true;
                skill.ExtendedAdd(skill_Extended);

                this.BChar.ParticleOut(skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));

            }
            yield break;
        }
    }
}
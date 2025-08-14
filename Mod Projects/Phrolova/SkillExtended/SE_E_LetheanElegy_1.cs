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
namespace Phrolova
{
	/// <summary>
	/// 安魂曲
	/// 下 1 个从手中释放的技能造成的伤害提升64%。
	/// </summary>
    public class SE_E_LetheanElegy_1: BuffSkillExHand
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillPerFinal.Damage = 64;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (SkillD.IsDamage)
            {
                BattleSystem.DelayInputAfter(this.Del());
            }
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();
            this.MainBuff.SelfDestroy(false);
            yield break;
        }
    }
}
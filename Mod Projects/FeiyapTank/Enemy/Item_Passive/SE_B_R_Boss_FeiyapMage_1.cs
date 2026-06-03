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
	/// 治疗量提升33%
	/// </summary>
    public class SE_B_R_Boss_FeiyapMage_1: BuffSkillExHand
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusSkillPerFinal.Damage = 30;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.DelayInputAfter(this.Del());
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();
            this.MainBuff.SelfDestroy(false);
            yield break;
        }
    }
}
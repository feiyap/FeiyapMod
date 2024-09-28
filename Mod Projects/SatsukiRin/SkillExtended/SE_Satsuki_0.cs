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
namespace SatsukiRin
{
	/// <summary>
	/// 薰风
	/// 下1次造成的治疗效果+50%。
	/// </summary>
    public class SE_Satsuki_0: BuffSkillExHand, IP_HealChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void HealChange(BattleChar Healer, BattleChar HealedChar, ref int HealNum, bool Cri, ref bool Force)
        {
            this.OnePassive = true;
            HealNum += (int)(HealNum * 0.5);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (SkillD.IsHeal)
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
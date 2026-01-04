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
namespace HiHouClab
{
	/// <summary>
	/// 造成的伤害提升&a。
	/// </summary>
    public class SE_Renko_P: BuffSkillExHand
    {
        public override string ExtendedDes()
        {
            return base.ExtendedDes().Replace("&a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString());
        }

        public override void Init()
        {
            base.Init();
            if (this.MySkill.IsDamage)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 1.0f);
            }
        }

        public override void SkillUseHand(BattleChar Target)
        {
            base.SkillUseHand(Target);
            BattleSystem.DelayInput(this.Del());
        }

        public IEnumerator Del()
        {
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.MainBuff.SelfDestroy(false);
            yield break;
        }
    }
}
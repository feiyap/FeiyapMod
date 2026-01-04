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
	/// 附带迅速
	/// </summary>
    public class SE_Renko_6: BuffSkillExHand
    {
        public override void Init()
        {
            base.Init();
            this.NotCount = true;
        }

        public override void FixedUpdate()
        {
            if (!this.flag && (this.MainBuff == null || this.MainBuff.DestroyBuff))
            {
                this.SelfDestroy();
            }
        }

        public override void SkillUseHand(BattleChar Target)
        {
            base.SkillUseHand(Target);
            this.flag = true;
            BattleSystem.DelayInput(this.Del());
        }

        public IEnumerator Del()
        {
            this.NotCount = false;
            this.MainBuff.SelfDestroy(false);
            yield break;
        }

        private bool flag;
    }
}
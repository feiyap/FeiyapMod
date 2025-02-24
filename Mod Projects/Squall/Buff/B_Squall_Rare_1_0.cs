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
namespace Squall
{
    public class B_Squall_Rare_1_0:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = -50;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            BattleSystem.DelayInputAfter(Del());
        }

        public IEnumerator Del()
        {
            this.SelfDestroy();

            yield break;
        }

    }
}
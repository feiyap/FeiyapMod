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
    /// 生与死的乐章
    /// </summary>
    public class S_Phrolova_0_1 : Skill_Extended, IP_ChangeDamageState
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void ChangeDamageState(SkillParticle SP, BattleChar Target, int DMG, bool Cri, ref bool ToHeal, ref bool ToPain)
        {
            ToPain = true;
        }
    }
}
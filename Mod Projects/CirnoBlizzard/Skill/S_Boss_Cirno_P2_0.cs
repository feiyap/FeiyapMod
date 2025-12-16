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
namespace CirnoBlizzard
{
    /// <summary>
    /// 绝对零度
    /// 这个技能造成痛苦伤害。
    /// </summary>
    public class S_Boss_Cirno_P2_0 : Skill_Extended, IP_ChangeDamageState
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
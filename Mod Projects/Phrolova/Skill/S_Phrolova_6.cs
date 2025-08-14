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
	/// 酣梦于彼岸深红
	/// 仅在<color=red>处于濒死状态</color>时才可释放。
	/// 造成<color=purple>痛苦伤害</color>。
	/// </summary>
    public class S_Phrolova_6:Skill_Extended, IP_ChangeDamageState
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

        public override bool Terms()
        {
            return this.BChar.HP <= 0;
        }
    }
}
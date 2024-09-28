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
namespace FlandreScarlet
{
	/// <summary>
	/// 秘弹「之后就一个人都没有了吗？」
	/// </summary>
    public class S_FlandreScarlet_10Rare_1:Skill_Extended, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.Info.Ally == this.BChar.Info.Ally)
            {
                hit.Damage(this.BChar, (int)(this.BChar.GetStat.atk * 0.1f), false, true, false, 0, false, false, false);
            }
        }
    }
}
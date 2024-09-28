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
namespace Sunmeitian
{
	/// <summary>
	/// 如意棒法
	/// 攻击造成伤害的80%转化为自身体力值。每次释放技能时减少1层。
	/// </summary>
    public class B_Sunmeitian_5:Buff, IP_SkillUse_Target, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 28;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG != 0 && Misc.PerToNum((float)DMG, 81f) >= 1f)
            {
                this.BChar.Heal(this.BChar, Misc.PerToNum((float)DMG, 81f), false, false, null);
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                base.SelfStackDestroy();
            }
        }
    }
}
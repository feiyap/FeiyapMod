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
namespace saber
{
	/// <summary>
	/// 招架
	/// <color=#808080>如此羸弱的攻击！</color>
	/// </summary>
    public class Saber_zhaojia_B:Buff,IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PerfectShield = true;
            this.PlusStat.DMGTaken = -30f;
        }
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.maxhp * 0.3f)).ToString());
        }

        // Token: 0x06000030 RID: 48 RVA: 0x00002A28 File Offset: 0x00000C28
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            bool flag = Dmg >= 1 && !SP.UseStatus.Info.Ally;
            if (flag)
            {
                Skill skill = Skill.TempSkill("Saber_zhaojia_fanji", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, SP.UseStatus, false, false, true, null));
            }
        }
    }
}
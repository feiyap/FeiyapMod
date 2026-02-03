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
namespace MageBasic
{
	/// <summary>
	/// 基础法术
	/// 指向敌人时，造成 &a 伤害<color=#FF7A33>(攻击力的90%)</color>；
	/// 指向友军时，治疗 &b 体力<color=#48D1CC>(治疗力的80%)</color>并给予 &c 保护罩<color=#48D1CC>(治疗力的80%)</color>。
	/// </summary>
    public class S_Mage_Default:Skill_Extended
    {
        public override void Init()
        {
            this.IsDamage = false;
            this.SkillBasePlus.Target_BaseHeal = 0;
            this.PlusSkillPerStat.Damage = 0;
        }

        public override void HandInit()
        {
            base.HandInit();
            this.IsDamage = true;
            this.SkillBasePlus.Target_BaseHeal = 0;
            this.PlusSkillPerStat.Damage = 0;
            this.SkillBasePlusPreview.Target_BaseHeal = (int)((float)this.BChar.GetStat.reg * 0.8f);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.IsDamage = true;
            this.SkillBasePlus.Target_BaseHeal = 0;
            this.PlusSkillPerStat.Damage = 0;

            if (Targets[0].Info.Ally)
            {
                this.IsDamage = false;
                this.IsHeal = true;
                this.SkillBasePlus.Target_BaseHeal = (int)((float)this.BChar.GetStat.reg * 0.8f);
                this.PlusSkillPerStat.Damage = -99999;
                Targets[0].BuffAdd("B_Mage_Barrier", this.BChar).BarrierHP += (int)((float)this.BChar.GetStat.reg * 0.8f);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)Misc.PerToNum((float)this.BChar.GetStat.atk, 90f)).ToString())
                                          .Replace("&b", ((int)Misc.PerToNum((float)this.BChar.GetStat.reg, 80f)).ToString());
        }
    }
}
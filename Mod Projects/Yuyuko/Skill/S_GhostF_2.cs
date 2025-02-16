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
namespace Yuyuko
{
	/// <summary>
	/// 空观剑「六根清净斩」
	/// 倒计时期间，如果指向的敌方使用的技能的目标包括“魂魄妖梦”或“魂魄妖梦·半灵”时，使该技能伤害变为0，并对其造成5次&a点伤害(攻击力的100%)和1次&b点伤害(攻击力的200%)的反击。
	/// 倒计时期间，“魂魄妖梦·半灵”不可行动。
	/// 如果成功格挡攻击，获得1层“符卡层数”。
	/// </summary>
    public class S_GhostF_2:Skill_Extended
    {
        public override void Init()
        {
            this.CountingExtedned = true;
        }
        
        public override void SkillUseHand(BattleChar Target)
        {
            this.BChar.BuffAdd("B_Youmu_Ex_R_2_S", this.BChar, true, 0, false, -1, false);
            this.BChar.BuffAdd("B_Youmu_R_2_T", this.BChar, true, 0, false, -1, false);
        }
        
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (this.BChar.BuffFind("B_Youmu_R_2_S", false))
            {
                this.BChar.BuffRemove("B_Youmu_R_2_S", false);
            }
        }
    }
}
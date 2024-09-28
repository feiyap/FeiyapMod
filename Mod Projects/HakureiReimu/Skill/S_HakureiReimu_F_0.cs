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
namespace HakureiReimu
{
	/// <summary>
	/// 灵符「梦想妙珠」
	/// 这个技能造成伤害的10%将会转化为自己的保护罩。
	/// 符卡等级1 - 提升伤害。
	/// 符卡等级2 - 提升伤害。这个技能造成伤害的15%将会转化为自己的保护罩。
	/// 符卡等级3 - 提升伤害。
	/// 符卡等级4 - 附加迅速。消耗最多3点法力值，每消耗1点法力值增加&a(50%)伤害。这个技能造成伤害的20%将会转化为自己的保护罩。
	/// 符卡等级5 - 附加迅速。消耗所有法力值，每消耗1点法力值增加&a(50%)伤害和5暴击率。这个技能造成伤害的20%将会转化为自己的保护罩。
	/// </summary>
    public class S_HakureiReimu_F_0: SkillExtended_Reimu
    {
        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    buffCount_N = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    buffCount_N = 0;
                }

                if (buffCount_N != buffCount_L && BattleSystem.instance != null && !this.MySkill.IsNowCounting)
                {
                    this.SkillChange("S_HakureiReimu_F_0", buffCount_N);
                }

                if (this.BChar.BuffFind("B_HakureiReimu_F_P", false))
                {
                    this.buffCount_L = this.BChar.BuffReturn("B_HakureiReimu_F_P", false).StackNum;
                }
                else
                {
                    this.buffCount_L = 0;
                }
            }
        }
    }
}
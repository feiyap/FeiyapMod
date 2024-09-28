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
	/// 结界「扩散结界」
	/// 可在无法行动时使用。
	/// 移除自己所有的减益效果。
	/// </summary>
    public class S_HakureiReimu_F_8: SkillExtended_Reimu
    {
        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.CanUseStun = true;
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
                    this.SkillChange("S_HakureiReimu_F_8", buffCount_N);
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

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count != 0)
            {
                List<Buff> list = new List<Buff>();
                foreach (Buff buff in this.BChar.Buffs)
                {
                    if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                    {
                        buff.SelfDestroy();
                    }
                }
            }
        }
    }
}
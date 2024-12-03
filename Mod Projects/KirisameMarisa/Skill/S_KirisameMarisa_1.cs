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
namespace KirisameMarisa
{
	/// <summary>
	/// 星符「Escape Velocity」
	/// 当前额外伤害：&a
	/// 握在手中时，每次按下等待按钮，此技能的伤害增加&a点(攻击力的70%)。
	/// </summary>
    public class S_KirisameMarisa_1: SkillBase_KirisameMarisa
    {
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

                int count = 0;
                foreach (Buff buffs in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false))
                {
                    count += buffs.StackNum;
                }
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.1f) * count;
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.1f)).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int count = 0;
            foreach (Buff buffs in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false))
            {
                count += buffs.StackNum;
            }
            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.1f) * count;
        }
    }
}
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
namespace HouraisanKaguya
{
	/// <summary>
	/// 灭罪「正直者之死」
	/// 倒计时期间，如果敌人使用攻击技能以外的技能，变为250%倍率。
	/// <color=orange>过热：5 - 施加3层<color=purple>烧伤</color>。</color>
	/// </summary>
    public class S_FMokou_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.BuffFind("B_Mokou_T_1") && this.BChar.BuffReturn("B_Mokou_T_1", false).StackNum >= 5)
            {
                Targets[0].BuffAdd("B_Mokou_T_1", this.BChar);
                Targets[0].BuffAdd("B_Mokou_T_1", this.BChar);
                Targets[0].BuffAdd("B_Mokou_T_1", this.BChar);

                int num = 0;
                for (int i = 0; i < 5; i++)
                {
                    bool flag = this.BChar.BuffFind("B_Mokou_T_1", false);
                    if (flag)
                    {
                        int num2 = this.BChar.BuffReturn("B_Mokou_T_1", false).Tick();
                        int stackNum = this.BChar.BuffReturn("B_Mokou_T_1", false).StackNum;
                        int num3 = (int)this.BChar.BuffReturn("B_Mokou_T_1", false).BuffData.LifeTime;
                        num += num2 / stackNum * num3;
                        this.BChar.BuffReturn("B_Mokou_T_1", false).SelfStackDestroy();
                    }
                }
                this.BChar.Damage(this.BChar, num, false, true, true, 0, false, false, false);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.plusDmg).ToString());
        }

        public int plusDmg
        {
            get
            {
                return (int)((float)(this.BChar.GetStat.atk * 2.5));
            }
        }
    }
}
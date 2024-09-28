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
	/// 禁忌「笼中鸟」
	/// 仅在触发[禁忌欲望]或[禁忌狂乱]时才能使用。
	/// 禁忌 - 抽取3个技能。直到回合结束前，只有自己能够使用技能。
	/// 狂乱2 - 恢复2点法力值。获得[笼中鸟]。
	/// </summary>
    public class S_FlandreScarlet_8:Skill_Extended
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            this.Flag = false;
            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                this.Flag = true;
            }
            if ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && this.BChar.BuffReturn("B_FlandreScarlet_P_K", false).StackNum >= 2)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                this.Flag = true;
            }
        }

        public override bool Terms()
        {
            return this.Flag;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SelfBuff = null;

            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                BattleSystem.instance.AllyTeam.Draw(2);
                this.BChar.BuffAdd("B_FlandreScarlet_8_0", this.BChar, true, 0, false, -1, false);
            }
            if ((this.BChar.BuffFind("B_FlandreScarlet_P_K", false) && this.BChar.BuffReturn("B_FlandreScarlet_P_K", false).StackNum >= 2)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                BattleSystem.instance.AllyTeam.AP += 2;
                this.BChar.BuffAdd("B_FlandreScarlet_8", this.BChar, false, 0, false, -1, false);
            }
            
            //BattleSystem.instance.AllyTeam.LucyAlly.BuffAdd(GDEItemKeys.Buff_B_LucyD_21_SwimDLC, this.BChar, false, 0, false, -1, false);
        }

        public bool Flag;
    }
}
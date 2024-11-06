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
namespace IzayoiSakuya
{
	/// <summary>
	/// 速符「闪光弹跳」
	/// 月魔术：降低1点费用。打出时使随机一个敌人的倒计时技能无效化。
	/// </summary>
    public class S_Sakuya_1: SkillExtended_Sakuya
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                this.APChange = 0;
                this.IgnoreTaunt = false;
                if (CheckLunaMagic())
                {
                    this.APChange = -1;
                    this.IgnoreTaunt = true;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckLunaMagic())
            {
                this.BChar.BuffAdd("B_Sakuya_P_0", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Sakuya_P_0", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}
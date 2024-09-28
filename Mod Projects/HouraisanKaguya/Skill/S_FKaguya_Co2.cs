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
	/// 编年史「千年幻想乡」
	/// 藤原妹红获得[＊这种世道赶紧烧个精光吧！＊]，蓬莱山辉夜获得[辉夜/蓬莱]。
	/// 那之后，双方获得[向宇宙尽头]。
	/// </summary>
    public class S_FKaguya_Co2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            this.BChar.BuffAdd("B_FKaguya_11Rare", this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd("B_FKaguya_Co2", this.BChar, false, 0, false, -1, false);

            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                if (BattleSystem.instance.AllyList[i].Info.KeyData == "Mokou")
                {
                    BattleSystem.instance.AllyList[i].BuffAdd("B_Mokou_S_R_1", this.BChar, false, 0, false, -1, false);
                    BattleSystem.instance.AllyList[i].BuffAdd("B_FKaguya_Co2", this.BChar, false, 0, false, -1, false);
                }
            }
        }
    }
}
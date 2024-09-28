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
namespace Kirito
{
	/// <summary>
	/// 切换
	/// 使用此技能不会发动[我还能更快]的被动效果。
    ///-亚丝娜：选择一名其他队友获得1回合BUFF[切换]：重复释放该队友释放的技能。但此回合自己无法行动。
    ///-诗乃：自身获得1回合BUFF[影光G4]：+50%无视防御。
    ///-尤吉欧：嘲讽所有敌人1回合。此回合自身受到攻击后随机使用手牌中的普通技能。
	/// </summary>
    public class S_Kirito_7:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_otherally);
            }
            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();

            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                Targets[0].BuffAdd("B_Asuna_7", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Asuna_7_0", this.BChar, false, 0, false, -1, false);
            }

            if (this.BChar.BuffFind("B_Shino_P", false))
            {
                this.BChar.BuffAdd("B_Shino_7", this.BChar, false, 0, false, -1, false);
            }

            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                for (int i = 0; i < Targets.Count; i++)
                {
                    if (Targets[i] is BattleEnemy)
                    {
                        Targets[i].BuffAdd("B_Eugeo_7", this.BChar, false, 0, false, -1, false);
                    }
                }
                this.BChar.BuffAdd("B_Eugeo_7_0", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}
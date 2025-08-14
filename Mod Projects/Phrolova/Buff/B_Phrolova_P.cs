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
namespace Phrolova
{
	/// <summary>
	/// “来生”
	/// 死亡时，对所有敌人造成&a痛苦伤害<color=#FF7A33>(&user攻击力的33%/每层)</color>。
	/// </summary>
    public class B_Phrolova_P:Buff
    {
        bool isTri = false;

        public override void Init()
        {
            base.Init();
            isTri = false;

            if (this.StackNum == 6)
            {
                (this.BChar as BattleAlly).MyBasicSkill.CoolDownNum = 0;
                if ((this.BChar as BattleAlly).MyBasicSkill.ThisSkillUse)
                {
                    (this.BChar as BattleAlly).MyBasicSkill.InActive = false;
                    (this.BChar as BattleAlly).MyBasicSkill.ThisSkillUse = false;
                }
                if ((this.BChar as BattleAlly).MyBasicSkill.InActive)
                {
                    (this.BChar as BattleAlly).MyBasicSkill.InActive = false;
                }

                if (this.BChar.BuffFind("B_Phrolova_Rare_1_1"))
                {
                    Skill skill = Skill.TempSkill("S_Phrolova_Rare_1_2", this.BChar, this.BChar.MyTeam);
                    (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
                }
                else
                {
                    Skill skill = Skill.TempSkill("S_Phrolova_P", this.BChar, this.BChar.MyTeam);
                    (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.StackNum == 6 && !isTri)
            {
                (this.BChar as BattleAlly).MyBasicSkill.CoolDownNum = 0;
                if ((this.BChar as BattleAlly).MyBasicSkill.ThisSkillUse)
                {
                    (this.BChar as BattleAlly).MyBasicSkill.InActive = false;
                    (this.BChar as BattleAlly).MyBasicSkill.ThisSkillUse = false;
                }
                if ((this.BChar as BattleAlly).MyBasicSkill.InActive)
                {
                    (this.BChar as BattleAlly).MyBasicSkill.InActive = false;
                }

                if (this.BChar.BuffFind("B_Phrolova_Rare_1_1"))
                {
                    Skill skill = Skill.TempSkill("S_Phrolova_Rare_1_2", this.BChar, this.BChar.MyTeam);
                    (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
                }
                else
                {
                    Skill skill = Skill.TempSkill("S_Phrolova_P", this.BChar, this.BChar.MyTeam);
                    (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
                }

                isTri = true;
            }
            else
            {
                isTri = false;
            }
        }
    }
}
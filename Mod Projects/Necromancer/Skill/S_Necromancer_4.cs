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
using NLog.Targets;
namespace Necromancer
{
	/// <summary>
	/// 精神链接
	/// 忘却之灵：不再施加精神解放，不再造成伤害。
	/// 转而立刻结算目标的灵压内爆与生命崩解，解除忘却之灵，并放逐该技能。
	/// </summary>
    public class S_Necromancer_4:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;

            BuffTag bufftag = new BuffTag();
            bufftag.BuffData = new GDEBuffData("B_Necromancer_7");
            bufftag.User = this.BChar;
            bufftag.PlusTagPer += 20;
            TargetBuff.Add(bufftag);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (BChar.BuffFind("B_Necromancer_4"))
            {
                (BChar.BuffReturn("B_Necromancer_4") as B_Necromancer_4).StackReduciton(2);
            }
            if (BChar.BuffFind("B_Necromancer_1") == true)
            {
                TargetBuff.Clear();
                foreach (BattleChar b in Targets)
                {
                    b.BuffAdd("B_Necromancer_7", BChar);
                    BattleSystem.DelayInput((b.BuffReturn("B_Necromancer_3") as B_Necromancer_3).Boom());

                    if (b.BuffFind("B_Necromancer_8"))
                    {
                        b.Damage(BChar, b.BuffReturn("B_Necromancer_8").DotDMGView(), false, true);
                    }
                }
                (BChar.BuffReturn("B_Necromancer_1") as B_Necromancer_1).SkillUseBasicSkill(SkillD);
            }

        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BChar.BuffFind("B_Necromancer_4") && BChar.BuffReturn("B_Necromancer_4").StackNum >= 2)
            {
                this.Flag = true;
            }
            else
            {
                this.Flag = false;
            }
        }
        public override bool Terms()
        {
            return this.Flag;
        }
        public bool Flag;
    }
}
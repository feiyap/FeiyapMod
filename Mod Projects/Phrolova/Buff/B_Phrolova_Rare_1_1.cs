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
    /// 与你亲密无间
    /// 其他队友释放技能时，自身也会获得 1 层“乐声”。
    /// “乐声”叠加至 6 层时，改为使固定能力变为“彼世与彼岸”。
    /// 进入濒死状态时，解除该增益。
    /// </summary>
    public class B_Phrolova_Rare_1_1 : Buff, IP_SkillUseHand_Team
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.HP <= 0)
            {
                base.SelfDestroy(true);
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master != this.BChar)
            {
                this.BChar.BuffAdd("B_Phrolova_P", this.BChar);
            }
        }
    }
}
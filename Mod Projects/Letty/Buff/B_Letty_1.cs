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
namespace Letty
{
    /// <summary>
    /// 冬夜
    /// 受到敌人攻击时，使攻击者获得 1 层“严寒”。
    /// </summary>
    public class B_Letty_1 : Buff, IP_Hit, IP_Dodge
    {
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (!SP.SkillData.Master.Info.Ally)
            {
                SP.SkillData.Master.BuffAdd("B_Letty_P", this.BChar);
            }
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (!SP.SkillData.Master.Info.Ally)
            {
                SP.SkillData.Master.BuffAdd("B_Letty_P", this.BChar);
            }
        }
    }
}
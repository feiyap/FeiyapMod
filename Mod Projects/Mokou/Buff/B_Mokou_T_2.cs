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
namespace Mokou
{
    /// <summary>
    /// 灭罪
    /// 无法攻击藤原妹红以外的目标
    /// 攻击目标时解除。
    /// </summary>
    public class B_Mokou_T_2 : B_Taunt, IP_SkillUse_User
    {
        public override void Init()
        {
            base.Init();
        }
        public override void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].Info.Ally != this.BChar.Info.Ally)
            {
                Targets.Clear();
                Targets.Add(base.Usestate_L);
            }
            base.SkillUse(SkillD, Targets);
        }
    }
}
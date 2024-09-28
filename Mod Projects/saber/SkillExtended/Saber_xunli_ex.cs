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
namespace saber
{
    public class Saber_xunli_ex : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            bool flag = Ex_Saber_jiefang.Checkzuocheng(1, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usezuocheng(5, this.BChar);
            }
        }
    }
}
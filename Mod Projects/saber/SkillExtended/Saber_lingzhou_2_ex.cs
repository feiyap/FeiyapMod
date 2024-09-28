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
    public class Saber_lingzhou_2_ex : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int num = (int)Misc.PerToNum((float)Targets[0].GetStat.maxhp, 50f);
            Targets[0].Heal(this.BChar, (float)num, false, false);
        }
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.TargetForceHeal = true;
        }
    }
}
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
namespace RemiliaScarlet
{
    /// <summary>
    /// 击杀时，获得2永久最大体力值
    /// </summary>
    public class SkillEn_Remilia_1:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            this.BChar.Info.OriginStat.maxhp += 2;
        }
    }
}
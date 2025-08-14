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
    /// 《终焉沉落》
    /// 这个技能被交换或丢弃时，受到<color=purple>6痛苦伤害</color>。
    /// </summary>
    public class S_Phrolova_8 : Skill_Extended
    {
        public override void DiscardSingle(bool Click)
        {
            base.DiscardSingle(Click);
            this.BChar.Damage(this.BChar, 6, false, true);
        }
    }
}
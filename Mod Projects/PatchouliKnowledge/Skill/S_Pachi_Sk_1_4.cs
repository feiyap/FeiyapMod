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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 土木符「活体护甲」
	/// 每个等级的“木”使“活体护甲”的防御力提升额外增加10%。
	/// 每个等级的“土”使“活体护甲”的治疗和保护罩提升 &a (防御力的10%)。
	/// </summary>
    public class S_Pachi_Sk_1_4:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.def * 0.1f)).ToString());
        }
    }
}
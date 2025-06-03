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
	/// 费用降低 2 点。
	/// <sprite name="비용3"><sprite name="이하">
	/// </summary>
    public class SE_Pachi_C_1:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill._AP >= 3;
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.APChange = -2;
        }
    }
}
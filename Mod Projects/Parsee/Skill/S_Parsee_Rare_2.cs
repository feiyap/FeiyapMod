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
namespace Parsee
{
	/// <summary>
	/// 爱姬
	/// </summary>
    public class S_Parsee_Rare_2:Skill_Extended
    {
        public override IEnumerator DrawAction()
        {
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, this.MySkill, false, false, true));
            return base.DrawAction();
        }
    }
}
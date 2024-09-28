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
namespace Inaba
{
	/// <summary>
	/// 「远古的骗术」
	/// 如果目标身上有3个以上弱化减益，抽取1个技能。
	/// </summary>
    public class S_Inaba_4: SE_Inaba_Draw
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int num = Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count;
            if (num >= 2)
            {
                InabaDraw(2);
            }
        }
    }
}
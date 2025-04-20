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
namespace Feiyap
{
	/// <summary>
	/// 明镜止水
	/// </summary>
    public class S_Feiyap_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (BattleAlly battleAlly in Targets)
            {
                foreach (Buff buff in battleAlly.GetBuffs(BattleChar.GETBUFFTYPE.CC, true, false))
                {
                    buff.SelfDestroy(false);
                }
                foreach (Buff buff in battleAlly.GetBuffs(BattleChar.GETBUFFTYPE.DOT, true, false))
                {
                    buff.SelfDestroy(false);
                }
            }
        }
    }
}
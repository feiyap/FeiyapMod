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
namespace KirisameMarisa
{
	/// <summary>
	/// 释放时，雾雨魔理沙获得2层<color=#00BFFF>危险等级</color>。
	/// </summary>
    public class SE_KirisameMarisa_C_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleChar battleChar2 = null;
            foreach (BattleChar battleChar3 in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar3.Info.KeyData == "KirisameMarisa")
                {
                    battleChar2 = battleChar3;
                    break;
                }
            }
            if (battleChar2.IsDead)
            {
                return;
            }

            battleChar2.BuffAdd("B_KirisameMarisa_P", battleChar2, false, 0, false, -1, false);
            battleChar2.BuffAdd("B_KirisameMarisa_P", battleChar2, false, 0, false, -1, false);
        }
    }
}
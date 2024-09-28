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
namespace HakureiReimu
{
	/// <summary>
	/// 使博丽灵梦获得1层<color=#B22222>符卡等级</color>。
	/// </summary>
    public class SE_HakureiReimu_C_1:Skill_Extended
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
                if (battleChar3.Info.KeyData == "HakureiReimu")
                {
                    battleChar2 = battleChar3;
                    break;
                }
            }
            if (battleChar2.IsDead)
            {
                return;
            }

            battleChar2.BuffAdd("B_HakureiReimu_F_P", battleChar2, false, 0, false, -1, false);
            battleChar2.BuffAdd("B_HakureiReimu_F_P", battleChar2, false, 0, false, -1, false);
        }
    }
}
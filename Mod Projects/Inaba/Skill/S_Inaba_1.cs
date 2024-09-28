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
	/// 瞬符「瞬间的闪光」
	/// 改变目标的嘲讽状态。
	/// </summary>
    public class S_Inaba_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (Targets[0] is BattleEnemy && (Targets[0] as BattleEnemy).istaunt)
            {
                Targets[0].BuffScriptReturn("Common_Buff_EnemyTaunt").SelfDestroy(false);
                return;
            }
            Targets[0].BuffAdd(GDEItemKeys.Buff_B_EnemyTaunt, Targets[0], false, 0, false, -1, false);
        }
    }
}
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
namespace Necromancer
{
	/// <summary>
	/// 骸骨暴乱
	/// 反转目标嘲讽
	/// </summary>
    public class S_Necromancer_3:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleChar target in Targets)
            {
                Buff buff = target.BuffScriptReturn("Common_Buff_EnemyTaunt");
                if (buff != null)
                {
                    buff.SelfDestroy(false);
                }
                else
                {
                    target.BuffAdd(GDEItemKeys.Buff_B_EnemyTaunt, target, false, 0, false, -1, false);
                }
            }
        }
    }
}
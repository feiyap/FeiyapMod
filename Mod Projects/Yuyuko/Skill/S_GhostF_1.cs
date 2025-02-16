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
namespace Yuyuko
{
	/// <summary>
	/// 魂魄「幽明求闻持聪明之法」
	/// </summary>
    public class S_GhostF_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffReturn("B_YoumuF_P_0")?.SelfDestroy();
            this.BChar.BuffAdd("B_YoumuF_P_1", this.BChar);

            this.BChar.BuffReturn("B_YoumuF_Spell")?.SelfDestroy();
            this.BChar.BuffReturn("B_YoumuF_Spell2")?.SelfDestroy();
            BattleChar ghost_youmu = BattleSystem.instance.CreatEnemy("Boss_Ghost_Youmu", new Vector3(-4.5f, 0f, 0f), true, false);

            MasterAudio.PlaySound("YoumuBoss_Phase2", 1f, null, 0f, null, null, false, false);
        }
    }
}
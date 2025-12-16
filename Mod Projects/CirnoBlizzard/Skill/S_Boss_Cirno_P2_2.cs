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
namespace CirnoBlizzard
{
	/// <summary>
	/// 烈冰之斩
	/// 无视防御。
	/// </summary>
    public class S_Boss_Cirno_P2_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillStat.Penetration = 100f;
        }
    }
}
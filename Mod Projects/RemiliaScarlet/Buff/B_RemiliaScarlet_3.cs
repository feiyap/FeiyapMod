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
namespace RemiliaScarlet
{
	/// <summary>
	/// 绯红色的幻想乡
	/// 只能攻击蕾米莉亚。击中时不解除。
	/// </summary>
    public class B_RemiliaScarlet_3:B_Taunt, IP_Awake, IP_SkillUse_User
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Weak = true;
        }

        public override void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].Info.Ally != this.BChar.Info.Ally)
            {
                Targets.Clear();
                Targets.Add(base.Usestate_L);
            }
        }
    }
}
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
namespace saber
{
	/// <summary>
	/// 决斗
	/// 无法攻击&target以外的目标。
	/// 攻击目标时解除。
	/// </summary>
    public class Saber_challenge_plus: B_Taunt, IP_Awake, IP_SkillUse_User
    {
        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&target", base.Usestate_F.Info.Name);
        }

        // Token: 0x06000014 RID: 20 RVA: 0x00002413 File Offset: 0x00000613
        public override void Init()
        {
            base.Init();
            this.PlusStat.hit = -10f; 
            base.Init();
            this.PlusStat.Weak = true;
        }

        // Token: 0x06000015 RID: 21 RVA: 0x00002430 File Offset: 0x00000630
        public override void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            bool flag = Targets[0].Info.Ally != this.BChar.Info.Ally;
            if (flag)
            {
                Targets.Clear();
                Targets.Add(base.Usestate_L);
            }
            base.SkillUse(SkillD, Targets);
        }
    }
}
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
namespace HiHouClab
{
	/// <summary>
	/// 暴击率提升
	/// </summary>
    public class B_Maribel_4_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 100;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (cs.skill.MySkill.KeyID == "S_Maribel_4" && cs.TargetReturn().Contains(this.BChar))
                {
                    return;
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (cs.skill.MySkill.KeyID == "S_Maribel_4" && cs.TargetReturn().Contains(this.BChar))
                {
                    return;
                }
            }
            SelfDestroy();
        }
    }
}
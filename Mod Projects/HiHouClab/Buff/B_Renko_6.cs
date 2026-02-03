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
using BasicMethods;
namespace HiHouClab
{
    /// <summary>
    /// 永恒的须臾
    /// 根据处于倒计时中的调查员技能的个数，增加自身的攻击力。
    /// </summary>
    public class B_Renko_6:Buff
    {
        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            int count = 0;
            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (cs.skill.Master.Info.Ally)
                {
                    count++;
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (cs.skill.Master.Info.Ally)
                {
                    count++;
                }
            }
            this.PlusStat.atk = count;
        }
    }
}
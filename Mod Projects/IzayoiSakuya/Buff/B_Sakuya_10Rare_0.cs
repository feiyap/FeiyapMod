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
namespace IzayoiSakuya
{
	/// <summary>
	/// 时符「个人空间」
	/// 无法使用手中的技能。
	/// </summary>
    public class B_Sakuya_10Rare_0:Buff
    {
        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.Master.BuffFind("B_Sakuya_10Rare_0", false))
                {
                    skill.NotAvailable = true;
                }
            }
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                skill.NotAvailable = false;
            }
        }
    }
}
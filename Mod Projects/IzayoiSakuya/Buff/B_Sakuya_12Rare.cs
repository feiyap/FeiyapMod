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
	/// 「完美女仆」
	/// 所有技能都能触发 [月魔术] 的额外效果。
	/// </summary>
    public class B_Sakuya_12Rare:Buff, IP_ChangeCantDraw, IP_Awake
    {
        public void Awake()
        {
            this.OnePassive = true;
            BattleSystem.instance.AllyTeam.NeedCantDrawCheck = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                foreach (Skill sk in BattleSystem.instance.AllyTeam.Skills)
                {
                    if (sk.Master == this.BChar && sk.ExtendedFind_DataName("SE_Sakuya_Rare_12") == null)
                    {
                        sk.ExtendedAdd(Skill_Extended.DataToExtended("SE_Sakuya_Rare_12"));
                    }
                }
            }
        }

        public void ChangeCantDraw(ref bool CantDraw)
        {
            CantDraw = true;
        }
    }
}
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
namespace Phrolova
{
	/// <summary>
	/// 变音符
	/// 固定能力造成的伤害提升&a%<color=#FF7A33>(&user攻击力的100%)</color>。
	/// </summary>
    public class B_Phrolova_4:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.RES_CC = 33;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar is BattleAlly && (this.BChar as BattleAlly).MyBasicSkill.buttonData.ExtendedFind<SE_Phrolova_4>() == null)
            {
                (this.BChar as BattleAlly).MyBasicSkill.buttonData.ExtendedAdd(new SE_Phrolova_4());
            }
        }

        public override string DescExtended()
        {
            string username = "";
            if (BattleSystem.instance != null)
            {
                username = this.BChar.Info.Name;
            }

            return this.BuffData.Description.Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 2f)).ToString())
                                            .Replace("&user", username);
        }
    }
}
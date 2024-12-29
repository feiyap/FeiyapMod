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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气 - 太阳雨
	/// 使手中所有技能获得“倒计时1，无视防御，造成的伤害提升15%”。
	/// </summary>
    public class B_Tenki_9:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            try
            {
                if (BattleSystem.instance != null)
                {
                    (this.BChar as BattleAlly).MyBasicSkill.buttonData.BasicOption = true;
                }
            }
            catch
            {
            }
        }
    }
}
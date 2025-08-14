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
	/// 定音
	/// 无法使用固定能力。
	/// </summary>
    public class B_Phrolova_P_2:Buff, IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_Phrolova_Rare_2"))
            {
                return;
            }
            if (this.BChar is BattleAlly && (this.BChar as BattleAlly).MyBasicSkill.buttonData.ExtendedFind<Extended_PopcornGirl_4>() == null)
            {
                (this.BChar as BattleAlly).MyBasicSkill.buttonData.ExtendedAdd_Battle(new Extended_PopcornGirl_4());
            }
        }
        
        public void TurnEnd()
        {
            base.SelfDestroy(false);
        }
    }
}
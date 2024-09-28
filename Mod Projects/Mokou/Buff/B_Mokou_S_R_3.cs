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
namespace Mokou
{
	/// <summary>
	/// 解除时，将一张不死「火鸟 -凤翼天翔-」加入手牌中。
	/// </summary>
    public class B_Mokou_S_R_3:Buff
    {
        public override void DestroyByTurn()
        {
            base.DestroyByTurn();
            MasterAudio.PlaySound("Mokou_R3_2", 1f, null, 0f, null, null, false, false);
            Skill skill = Skill.TempSkill("S_Mokou_R_3", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Skills.Add(skill);
        }
    }
}
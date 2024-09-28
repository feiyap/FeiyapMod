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
namespace Lumiore
{
	/// <summary>
	/// 伟大的调停者·佐伊
	/// 所有友军的体力降为1点。获得1回合BUFF[背水一战]：保护体力极限，受到的伤害转变为0。
	/// </summary>
    public class S_Lumiore_14Rare_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                this.BChar.HP = 1;
                battleChar.BuffAdd("B_Lumiore_14Rare", this.BChar, false, 0, false, 1, false);
            }
        }
    }
}
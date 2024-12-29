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
	/// 天气 - 苍天
	/// 本回合内每使用1个技能，获得“攻击力+1%、暴击率+1%、命中率+1%”。
	/// </summary>
    public class B_Tenki_4:Buff, IP_SkillUseHand_Team
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            count++;
            this.PlusPerStat.Damage = count;
            this.PlusStat.hit = count;
            this.PlusStat.cri = count;
        }
    }
}
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
namespace Inaba
{
	/// <summary>
	/// 白兔的四叶草
	/// 每拥有100金币，追加攻击/反击的伤害+1%。
	/// </summary>
    public class R_Inaba_0:PassiveItemBase, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
        }
        
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!Target.Info.Ally && (SkillD.PlusHit || SkillD.ExtendedFind("Lian_Ex_Counter", true) != null))
            {
                Damage += Damage * PlayData.Gold / 100 / 100;
            }
            return Damage;
        }
    }
}
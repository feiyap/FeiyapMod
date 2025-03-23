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
namespace VillageAlice
{
	/// <summary>
	/// 美梦闹铃
	/// 【童话】：造成混乱伤害。
	/// </summary>
    public class S_FVAlice_1:Skill_Extended, IP_ChangeDamageChaos
    {
        public void ChangeDamageChaos(SkillParticle SP, BattleChar Target, int DMG, bool Cri, ref bool ToChaos)
        {
            if (SP.SkillData == this.MySkill && SP.SkillData.ExtendedFind_DataName("SkillExtended_Fairytale") != null)
            {
                ToChaos = true;
            }
        }
    }
}
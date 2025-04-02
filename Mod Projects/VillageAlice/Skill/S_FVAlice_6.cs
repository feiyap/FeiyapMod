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
	/// 德洛丽丝摇篮曲
	/// 进入或离开[梦境]时，法力值消耗减少1。
	/// 【童话】：触发一次目标拥有的噩梦cc或美梦cc，不减少层数。
	/// </summary>
    public class S_FVAlice_6:Skill_Extended, IP_ChangeReality
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.MySkill.ExtendedFind_DataName("SkillExtended_Fairytale") != null)
            {
                if (Targets[0].BuffFind("B_FVAlice_0"))
                {
                    Targets[0].ChaosDamage(this.BChar, (int)(this.BChar.GetStat.atk * 1.5f), false);
                }
                if (Targets[0].BuffFind("B_FVAlice_1"))
                {
                    Targets[0].ChaosDamage(this.BChar, (int)(this.BChar.GetStat.atk * 0.5f + 1), false);
                }
            }
        }

        public void ChangeReality(bool istrue)
        {
            this.APChange -= 1;
        }
    }
}
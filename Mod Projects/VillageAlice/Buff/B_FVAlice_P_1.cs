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
	/// 梦境
	/// 在[梦境]中释放未被【童话】的技能将返回[现实]。
	/// </summary>
    public class B_FVAlice_P_1:Buff, IP_SkillUseHand_Team
    {
        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar && skill.ExtendedFind_DataName("SkillExtended_Fairytale") == null)
            {
                this.SelfDestroy();
                this.BChar.BuffAdd("B_FVAlice_P", this.BChar);

                foreach (IP_ChangeReality ip in BattleSystem.instance.IReturn<IP_ChangeReality>())
                {
                    if (ip != null)
                    {
                        ip.ChangeReality(false);
                    }
                }
            }
        }
    }
}
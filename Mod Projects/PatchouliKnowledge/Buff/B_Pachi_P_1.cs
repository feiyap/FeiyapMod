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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 元素充盈
	/// </summary>
    public class B_Pachi_P_1:Buff, IP_SkillUse_BasicSkill
    {
        public void SkillUseBasicSkill(Skill skill)
        {
            if (skill.MySkill.KeyID == "S_Pachi_P")
            {
                BattleSystem.DelayInputAfter(this.Del());
                
                this.SelfStackDestroy();
            }
        }

        private IEnumerator Del()
        {
            this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);

            yield break;
        }
    }
}
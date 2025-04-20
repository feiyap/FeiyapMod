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
namespace FFAce
{
	/// <summary>
	/// 朱雀刻印
	/// 每个回合首次使用固定能力时，额外翻开一张牌并获得相应的[翻开]效果。
	/// 每个回合开始时，额外获得2层[赤红之炎]。
	/// 使用[红焰轮舞]和[赤红之炎]时，额外造成[艾斯100%攻击力]点伤害的追加攻击。
	/// </summary>
    public class B_FFAce_Rare_2:Buff, IP_PlayerTurn, IP_SkillUse_Team_Target
    {
        public void Turn()
        {
            this.BChar.BuffAdd("B_FFAce_0", this.BChar);
            this.BChar.BuffAdd("B_FFAce_LucyD", this.BChar);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name)
                                      .Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1.0f)).ToString());
        }

        public void SkillUseTeam_Target(Skill skill, List<BattleChar> Targets)
        {
            if (!skill.FreeUse && !Targets[0].Info.Ally && skill.MySkill.KeyID == "S_FFAce_0" || skill.MySkill.KeyID == "S_FFAce_0_Ex")
            {
                foreach (BattleChar target in Targets)
                {
                    BattleSystem.DelayInput(this.Effect(target));
                }
            }
        }

        public IEnumerator Effect(BattleChar Target)
        {
            yield return new WaitForSeconds(0.06f);
            Skill skill = Skill.TempSkill("S_FFAce_Rare_2_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            this.BChar.ParticleOut(skill, Target);
            yield break;
        }
    }
}
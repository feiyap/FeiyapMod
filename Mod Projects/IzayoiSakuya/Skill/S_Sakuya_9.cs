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
namespace IzayoiSakuya
{
	/// <summary>
	/// 银符「银之跳跃」
	/// 未暴击时，获得1把<color=#EEE9E9>时停飞刀</color>，将这个技能拿回手中。
	/// 暴击时，放逐这个技能。
	/// </summary>
    public class S_Sakuya_9:Skill_Extended, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if ((SP.SkillData == this.MySkill) && !Cri)
            {
                P_IzayoiSakuya.getTimeKnife(this.BChar, 1);

                BattleSystem.DelayInput(this.Draw());
            }
            if ((SP.SkillData == this.MySkill) && Cri)
            {
                SP.SkillData.Delete();
            }
        }

        public IEnumerator Draw()
        {
            if (!this.MySkill.isExcept)
            {
                if (BattleSystem.instance.AllyTeam.Skills.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) == null)
                {
                    yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDrawList(this.MySkill.CharinfoSkilldata, null, true));
                }
            }
            else if (BattleSystem.instance.AllyTeam.Skills_UsedDeck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) != null)
            {
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.Remove(BattleSystem.instance.AllyTeam.Skills_UsedDeck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata));
            }
            else if (BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) != null)
            {
                BattleSystem.instance.AllyTeam.Skills_Deck.Remove(BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata));
            }
            yield return null;
            yield break;
        }
    }
}
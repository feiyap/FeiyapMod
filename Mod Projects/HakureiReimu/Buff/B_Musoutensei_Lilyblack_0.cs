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
namespace HakureiReimu
{
	/// <summary>
	/// 凋叶棕
	/// 自身每次获得增益时，莉莉黑会对随机敌人发动一次&a伤害的追加攻击<color=#FF7A33>(攻击力的33%)</color>。
	/// </summary>
    public class B_Musoutensei_Lilyblack_0:Buff, IP_BuffAdd
    {
        public override string DescExtended()
        {
            if (BattleSystem.instance == null)
            {
                return base.DescExtended().Replace("&a", (0).ToString());
            }

            BattleChar llb = new BattleChar();
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc.Info.Name == "Touhou_LilyBlack")
                {
                    llb = bc;
                    break;
                }
            }

            if (llb == null)
            {
                return base.DescExtended().Replace("&a", (0).ToString());
            }

            return base.DescExtended().Replace("&a", ((int)((float)llb.GetStat.atk * 0.33f)).ToString());
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar)
            {
                BattleChar llb = new BattleChar();
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    if (bc.Info.Name == "Touhou_LilyBlack")
                    {
                        llb = bc;
                        break;
                    }
                }

                if (llb == null)
                {
                    return;
                }

                Skill skill = Skill.TempSkill("S_Musoutensei_Lilyblack_1", llb, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill, llb));
            }
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar use)
        {
            yield return new WaitForSecondsRealtime(0.1f);

            use.ParticleOut(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));

            yield return null;
            yield break;
        }
    }
}
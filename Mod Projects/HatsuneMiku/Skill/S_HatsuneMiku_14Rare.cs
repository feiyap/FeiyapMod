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
namespace HatsuneMiku
{
    /// <summary>
    /// ワールドイズマイン
    /// 只要这张卡在手中：
    /// 每个回合结束时，为所有队友施加2层[未来之音]。
    /// 音律3：额外施加2层[未来之音]。
    /// 音律9：对所有敌人造成自己[未来之音]层数*&a的伤害。
    /// </summary>
    public class S_HatsuneMiku_14Rare:Skill_Extended, IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_HatsuneMiku_14Rare_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSeconds(0.3f);
            yield break;
        }

        public override string DescExtended(string desc)
        {
            int num = (int)(this.BChar.GetStat.reg * 0.1f);
            return base.DescExtended(desc).Replace("&a", num.ToString());
        }

        public void TurnEnd()
        {
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                BattleSystem.instance.AllyList[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                BattleSystem.instance.AllyList[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);

                if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 3)
                {
                    BattleSystem.instance.AllyList[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                    BattleSystem.instance.AllyList[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                }
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 9)
            {
               BattleSystem.DelayInput(this.Ienum());
            }
        }
    }
}
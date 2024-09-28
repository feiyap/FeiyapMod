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
	/// 砂の惑星
	/// 自己身上每有1层[未来之音]，暴击率提升10%。额外暴击率：%a
	/// 音律3：自己身上每有2层[未来之音]，额外造成1伤害。额外伤害：%b
	/// 音律9：将这张卡放回手卡中。
	/// </summary>
    public class S_HatsuneMiku_2:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0 || !this.BChar.BuffFind("B_HatsuneMiku_P", false))
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum / 2));
            }
        }

        public override void FixedUpdate()
        {
            if (this.BChar.BuffFind("B_HatsuneMiku_P", false))
            {
                this.PlusSkillStat.cri = this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum * 10f;
            }
            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 3)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
        }

        public override void Init()
        {
            base.Init();
        }

        public IEnumerator Draw()
        {
            if (!this.MySkill.isExcept)
            {
                if (BattleSystem.instance.AllyTeam.Skills.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) == null)
                {
                    yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDrawList(this.MySkill.CharinfoSkilldata, null));
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

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false))
            {
                this.PlusSkillStat.cri = this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum * 10f;
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 3)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }

            if (this.BChar.BuffFind("B_HatsuneMiku_P", false) && this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum >= 9)
            {
                if (!this.MySkill.isExcept)
                {
                    BattleSystem.DelayInput(this.Draw());
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", this.PlusSkillStat.cri.ToString()).Replace("&b", this.SkillBasePlus.Target_BaseDMG.ToString());
        }
    }
}
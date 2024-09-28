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
namespace saber
{
    public class Saber_jiejie_ex:Skill_Extended
    {
        public override void BattleStartDeck(List<Skill> Skills_Deck)
        {
            Skills_Deck.Remove(this.MySkill);
            Skills_Deck.Insert(0, this.MySkill);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            bool flag = Ex_Saber_jiefang.Checkzuocheng(2, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_jiejie_A");
                this.TargetBuff.Add(buffTag);
            }
            else
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_jiejie_B");
                this.TargetBuff.Add(buffTag);
            }
        }
        public int checkCount = 0;
    }
}
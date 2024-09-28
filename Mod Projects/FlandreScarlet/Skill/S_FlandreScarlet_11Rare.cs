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
namespace FlandreScarlet
{
	/// <summary>
	/// QED「495年的波纹」
	/// 当自己没有手牌时，将这个技能从牌库中抽取到手中。
	/// </summary>
    public class S_FlandreScarlet_11Rare:Skill_Extended
    {
        public override void FixedUpdate()
        {
            if (!this.flag)
            {
                return;
            }
            this.flame++;
            if (this.flame >= 20 && this.flag)
            {
                base.FixedUpdate();
                this.flame = 0;
                if (!BattleSystem.instance.DelayWait && BattleSystem.instance.ActWindow.On && this.SkillListCheck())
                {
                    this.flag = false;
                    List<BattleTeam.DrawInput> dd = null;
                    this.BChar.MyTeam.ForceDraw(this.BChar.MyTeam.Skills_Deck.Find((Skill a) => a.MySkill.Key == "S_FlandreScarlet_11Rare"), dd);
                }
            }
        }

        public bool SkillListCheck()
        {
            if (BattleSystem.instance.AllyTeam.Skills.Count == 0)
            {
                return true;
            }
            using (List<Skill>.Enumerator enumerator = BattleSystem.instance.AllyTeam.Skills.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (!enumerator.Current.isExcept)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        private int flame;
        public bool flag;
    }
}
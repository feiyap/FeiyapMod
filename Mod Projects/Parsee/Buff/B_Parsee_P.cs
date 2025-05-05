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
namespace Parsee
{
	/// <summary>
	/// 妒火
	/// 叠加到 6 层时，全体敌人与全体友军受到 &a 点痛苦伤害[100%治疗力]。
	/// 那之后，优先抽取帕露西的 1 个技能，然后层数变化为 1 。
	/// </summary>
    public class B_Parsee_P:Buff
    {
        public override void Init()
        {
            int dmg = (int)(this.BChar.GetStat.reg * 1);

            if (this.StackNum == 6)
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    bc.Damage(this.BChar, dmg, false, true);
                }
                foreach (BattleChar bc in BattleSystem.instance.EnemyList)
                {
                    bc.Damage(this.BChar, dmg, false, true);
                }
                BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();
                this.SelfStackDestroy();

                this.BChar.BuffAdd("B_Parsee_P_2", this.BChar);
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.reg * 1)).ToString());
        }
    }
}
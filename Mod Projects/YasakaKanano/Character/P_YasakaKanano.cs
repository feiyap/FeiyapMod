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
namespace YasakaKanano
{
	/// <summary>
	/// 八坂神奈子
	/// Passive:
	/// <b>神圣庄严的古战场</b> - 回合结束时若有剩余法力值，则下一回合开始时额外获得等量的法力值。（最多2点）
	/// <b>创造乾程度的能力</b> - 八坂神奈子可以通过技能设置不同种类的[御柱]，但同一时间只能有1个[御柱]被设置。
	/// 每当在战斗中通过特殊效果恢复1点法力值时，[御柱]的效果便会被触发1次。
	/// <b><color=green>连击X</color></b> - 每个回合中使用过的技能大于X个时，可以触发额外效果。
	/// <b><color=#FFC125>穗收X</color></b> - 打出时，如果牌库中的技能数量不小于X个，丢弃牌库最上方X个技能，可以触发额外效果。
	/// <b><color=#CD5555>饥馑X</color></b> - 打出时，如果牌库中的技能数量不大于X个，可以触发额外效果。
	/// </summary>
    public class P_YasakaKanano:Passive_Char, IP_TurnEnd, IP_PlayerTurn, IP_BattleEnd
    {
        public void BattleEnd()
        {
            this.SaveAP = 0;
        }
        
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public void Turn()
        {
            BattleSystem.instance.AllyTeam.AP += this.SaveAP;

            if (BattleSystem.instance.GetBattleValue<BV_Kanano_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Kanano_P());
                return;
            }
        }
        
        public void TurnEnd()
        {
            this.SaveAP = BattleSystem.instance.AllyTeam.AP;
            if (this.SaveAP >= 2)
            {
                this.SaveAP = 2;
            }
        }
        
        public int SaveAP;
    }
}
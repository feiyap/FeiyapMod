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
namespace Inaba
{
	/// <summary>
	/// 因幡帝
	/// Passive:
	/// <b>让人幸运程度的能力</b> - 战斗结束时，额外获得0~100金币。
	/// <b><color=#FFD700>帝的豪华奖池</color></b> - 帝的部分技能会从豪华奖池中随机生成效果：
	/// [兔群冲锋]倒计时2后，对所有敌人造成中等(70%)伤害，视为追加攻击。
	/// [年糕]倒计时1后，恢复体力最低的友军少量(50%)体力，施加[因幡/地运]：3回合；攻击力+15%。
	/// [小兔叽]倒计时5后，对随机敌人造成高额(120%)伤害，视为追加攻击。
	/// [苦药渣]倒计时1后，对随机敌人造成少量(50%)伤害，视为追加攻击，施加[因幡/药毒]：130%弱化；3回合；攻击力-10%，防御力-10%。
	/// [铁锤砸下]倒计时1后，对随机敌人造成中等(60%)伤害，120%眩晕，视为追加攻击。
	/// [炸弹？！]倒计时1后，使随机敌人获得[炸弹？！]：回合结束时，造成超高额(180%)伤害，视为追加攻击。攻击后将此减益转移至目标身上。
	/// [冬日温泉一日游大奖！]非常稀有；倒计时1后，消除所有友军的过载，获得2法力值，获得10金币。
	/// </summary>
    public class P_Inaba:Passive_Char, IP_BattleEnd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleEnd()
        {
            int ran = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 1, 201);
            InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, ran));
        }
    }
}
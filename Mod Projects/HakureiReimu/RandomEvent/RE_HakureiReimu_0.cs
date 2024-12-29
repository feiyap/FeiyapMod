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
	/// 赛钱箱
	/// Button
	/// 塞钱400金币。
	/// 塞钱800金币。
	/// 塞钱1200金币。
	/// ButtonToolTip
	/// 所有队友恢复50%体力。
	/// 下1场战斗开始时所有敌人失去10%最大体力值。
	/// 永久提升1个调查员1攻击力和治疗力。
	/// </summary>
    public class RE_HakureiReimu_0:RandomEventBaseScript
    {
        public override void UseButton1()
        {
            if (PlayData.Gold >= 250)
            {
                PlayData.Gold -= 250;
                foreach (Character character in PlayData.TSavedata.Party)
                {
                    character.HealHP(character.get_stat.maxhp / 2, true);
                }
                return;
            }
            EffectView.SimpleTextout(this.MyUI.ButtonList[1].transform, ScriptLocalization.UI_RandomEventUI.NeedGold, 1f, false, 1f);
        }

        public override void UseButton2()
        {
            base.UseButton2();

            if (PlayData.BattleLucy.BuffFind("B_RE_HakureiReimu_0"))
            {
                EffectView.SimpleTextout(this.MyUI.ButtonList[1].transform, ModManager.getModInfo("HakureiReimu").localizationInfo.SystemLocalizationUpdate("Event/Buyed"), 1f, false, 1f);
                return;
            }

            if (PlayData.Gold >= 500)
            {
                PlayData.Gold -= 500;
                PlayData.BattleLucy.BuffAdd("B_RE_HakureiReimu_0", PlayData.BattleLucy, false, 0, false, -1, false);
                return;
            }
            EffectView.SimpleTextout(this.MyUI.ButtonList[1].transform, ScriptLocalization.UI_RandomEventUI.NeedGold, 1f, false, 1f);
        }

        public override void UseButton3()
        {
            base.FieldAllyTargetOn(new FieldSystem.FieldTargetClickDel(this.FieldTargetClickDel));
        }

        public void FieldTargetClickDel(AllyWindow Ally)
        {
            if (PlayData.Gold >= 1000)
            {
                PlayData.Gold -= 1000;

                Ally.Info.OriginStat.atk += 1;
                Ally.Info.OriginStat.reg += 1;
                return;
            }

            EffectView.SimpleTextout(this.MyUI.ButtonList[1].transform, ScriptLocalization.UI_RandomEventUI.NeedGold, 1f, false, 1f);
        }
    }
}
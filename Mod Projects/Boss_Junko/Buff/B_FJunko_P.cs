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
namespace Boss_Junko
{
	/// <summary>
	/// 纯狐被动
	/// 总被动
	/// </summary>
    public class B_FJunko_P:Buff, IP_BattleStart_UIOnBefore
    {
        //处理战斗事件
        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            MasterAudio.StopBus("BGM");

            BattleSystem.DelayInput(this.Start1());
        }

        //开场对话
        public IEnumerator Start1()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);
            
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("Boss_Junko").localizationInfo.SystemLocalizationUpdate("BattleDia/FJunkoBattleStart/Text1"), true, 0, 0f);
            }

            yield break;
        }
    }
}
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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天人之姿
	/// 天子解放<color=#B22222>十</color><color=#00BFFF>之</color><color=#00FF7F>权</color><color=#FFD700>能</color>。
	/// 免疫所有减益。
	/// 每回合行动次数+1。
	/// <color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>的持续时间变为永久。
	/// </summary>
    public class Boss_B_Tenshi_Phase_2:Buff, IP_UsedDeckToDeck
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public IEnumerator UsedDeckToDeck()
        {
            if (BattleSystem.instance.AllyTeam.Skills_Deck.Count >= 20)
            {
                BattleSystem.instance.TurnNum += 1;

                BattleSystem.instance.TurnAni.gameObject.SetActive(true);
                BattleSystem.instance.TurnAni.Play("TurnUpdate", 0, 0f);
                BattleSystem.instance.TurnText.text = BattleSystem.instance.TurnNum.ToString();
                BattleSystem.instance.MainMist.MistAni.SetInteger("Phase", BattleSystem.instance.FogTurn - BattleSystem.instance.TurnNum);
                if (BattleSystem.instance.FogTurn == BattleSystem.instance.TurnNum)
                {
                    BattleSystem.instance.MistAni.Play("MistOn");
                }
            }
            yield return null;
            yield break;
        }
    }
}
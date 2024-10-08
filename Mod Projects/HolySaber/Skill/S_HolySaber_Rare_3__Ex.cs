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
namespace HolySaber
{
	/// <summary>
	/// <color=#FFA500>光辉现世·拉</color>
	/// 使当前回合数+2。
	/// </summary>
    public class S_HolySaber_Rare_3__Ex: SkillExtended_HolySaber
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.instance.TurnNum += 2;

            BattleSystem.instance.TurnAni.gameObject.SetActive(true);
            BattleSystem.instance.TurnAni.Play("TurnUpdate", 0, 0f);
            BattleSystem.instance.TurnText.text = BattleSystem.instance.TurnNum.ToString();
            BattleSystem.instance.MainMist.MistAni.SetInteger("Phase", BattleSystem.instance.FogTurn - BattleSystem.instance.TurnNum);
            if (BattleSystem.instance.FogTurn == BattleSystem.instance.TurnNum)
            {
                BattleSystem.instance.MistAni.Play("MistOn");
            }
        }
    }
}
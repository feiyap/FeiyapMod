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
	/// 「Mountain of Faith」
	/// 选择 - 从三个神符中选择一个生效。
	/// 一场战斗中，一个神符只能选择一次。
	/// </summary>
    public class S_Kanano_Rare_3:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            ChoiceSkillList.Clear();
            this.ChoiceSkillList.Add("S_Kanano_Rare_3_1");
            this.ChoiceSkillList.Add("S_Kanano_Rare_3_2");
            this.ChoiceSkillList.Add("S_Kanano_Rare_3_3");
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;

                if (BattleSystem.instance.GetBattleValue<BV_Kanano_Rare_3>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Kanano_Rare_3());
                    return;
                }
            }
        }
    }
}
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
namespace KirisameMarisa
{
	/// <summary>
	/// 魔废「Deep Ecological Bomb」
	/// 抽取1个技能。依据当前速度：
	/// 大于0：额外抽取1个技能，恢复1点法力值。
	/// 等于0：额外抽取1个技能。
	/// 小于0：恢复3点法力值。
	/// </summary>
    public class S_KirisameMarisa_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(1);

            if (PlayData.PartySpeed > 0)
            {
                BattleSystem.instance.AllyTeam.Draw(1);
                BattleSystem.instance.AllyTeam.AP++;
            }
            else if (PlayData.PartySpeed < 0)
            {
                BattleSystem.instance.AllyTeam.AP += 3;
            }
            else
            {
                BattleSystem.instance.AllyTeam.Draw(1);
            }
        }
    }
}
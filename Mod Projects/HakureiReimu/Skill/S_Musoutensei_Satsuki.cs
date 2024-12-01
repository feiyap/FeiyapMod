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
	/// 幻梦终焉「永别吧，这拥有幻想乡的此世，向那如梦般飘散的未来」
	/// *「梦想天生」+终焉「满溢着光的摇篮中」
	/// 消耗所有法力值。丢弃所有手中的技能。抽取X个技能。恢复法力值至X点。清除所有队友的过载。所有队友获得X层[幻梦终焉]：3回合内，攻击力+10%，治疗力+10%。效果解除时，立即死亡。
	/// X为这个技能消耗的法力值。
	/// </summary>
    public class S_Musoutensei_Satsuki: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("Musoutensei_Satsuki", 1f, null, 0f, null, null, false, false);

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.IsDamage)
                {
                    skill.ExtendedAdd("SE_Musoutensei_Satsuki_0");
                }
            }
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_Deck)
            {
                if (skill.IsDamage)
                {
                    skill.ExtendedAdd("SE_Musoutensei_Satsuki_0");
                }
            }
        }
    }
}
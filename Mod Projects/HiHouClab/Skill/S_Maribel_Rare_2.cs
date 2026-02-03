using BasicMethods;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace HiHouClab
{
	/// <summary>
	/// 轮椅上的未来宇宙
	/// 这个技能不会因为回合结束而被释放。
	/// 倒计时期间，所有目标获得“无敌”增益。
	/// </summary>
    public class S_Maribel_Rare_2:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit, IP_PlayerTurn
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            CustomMethods.CountingSkillNotUseTurnEnd(ThisSkill);
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                bc.BuffAdd("B_Maribel_Rare_2", this.BChar);
            }
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                bc.BuffRemove("B_Maribel_Rare_2");
            }
        }

        public void Turn()
        {
            List<CastingSkill> removeList = new List<CastingSkill>();
            foreach (CastingSkill cs in BattleSystem.instance.CastSkills)
            {
                if (cs.skill.CharinfoSkilldata.Seed == this.MySkill.CharinfoSkilldata.Seed)
                {
                    cs.CastButton.CountingLeft -= 1;

                    if (cs.CastSpeed <= 0)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(cs);
                        removeList.Add(cs);
                    }
                }
            }
            foreach (CastingSkill cs in BattleSystem.instance.SaveSkill)
            {
                if (cs.skill.CharinfoSkilldata.Seed == this.MySkill.CharinfoSkilldata.Seed)
                {
                    cs.CastButton.CountingLeft -= 1;

                    if (cs.CastSpeed <= 0)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(cs);
                        removeList.Add(cs);
                    }
                }
            }
            foreach (CastingSkill castingSkill3 in removeList)
            {
                BattleSystem.instance.CastSkills.Remove(castingSkill3);
                BattleSystem.instance.SaveSkill.Remove(castingSkill3);
            }
        }
    }
}
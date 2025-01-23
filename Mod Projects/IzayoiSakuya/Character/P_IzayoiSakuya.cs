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
namespace IzayoiSakuya
{
	/// <summary>
	/// 十六夜咲夜
	/// Passive:
	/// 操纵时间程度的能力 - 每次打出技能时，使所有处于倒计时中的十六夜咲夜的技能倒计时减少1点。每有1个技能因这个效果减少倒计时，获得1把[时停飞刀]。
    /// 危险的戏法家 - 咲夜每次打出位于手中最上方或最下方的技能时，获得1层<color=#00BFFF>时钟停摆</color>。<color=#00BFFF>时钟停摆</color>堆叠至4层后，将1张“时计「月时计」”加入手中。
    /// <color=#4169E1>月魔术</color> - 咲夜的部分技能在位于手中最上方或最下方被打出时，能够触发额外效果。
	/// </summary>
    public class P_IzayoiSakuya:Passive_Char, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && !this.BChar.BuffFind("B_Sakuya_12Rare"))
            {
                List<CastingSkill> removeList = new List<CastingSkill>();
                foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
                {
                    if (castingSkill.skill.Master == this.BChar)
                    {
                        castingSkill.CastButton.CountingLeft--;
                        getTimeKnife(this.BChar, 1);

                        if (castingSkill.CastSpeed <= 0)
                        {
                            BattleSystem.instance.ActWindow.CastingWaste(castingSkill);
                            removeList.Add(castingSkill);

                            Skill skill2 = castingSkill.skill.CloneSkill(true, null, null, false);
                            skill2.Counting = -99;

                            if (castingSkill.Target != null)
                            {
                                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, castingSkill.Target, false, false, false, null));
                            }
                            else if (castingSkill.SkillTarget != null)
                            {
                                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, castingSkill.SkillTarget));
                            }
                            else
                            {
                                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, null));
                            }
                        }
                        else
                        {
                            if (castingSkill.skill.MySkill.KeyID == "S_Sakuya_4" && castingSkill.CastButton.CountingLeft > 1)
                            {
                                Skill skill2 = Skill.TempSkill("S_Sakuya_4_0", this.BChar, this.BChar.MyTeam);
                                skill2.Counting = castingSkill.CastButton.CountingLeft - 1;
                                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill2, castingSkill.Target, false, false, false, null));
                            }
                        }
                    }
                }
                foreach (CastingSkill castingSkill2 in BattleSystem.instance.SaveSkill)
                {
                    if (castingSkill2.skill.Master == this.BChar)
                    {
                        castingSkill2.CastButton.CountingLeft--;
                        getTimeKnife(this.BChar, 1);

                        if (castingSkill2.CastSpeed <= 0)
                        {
                            BattleSystem.instance.ActWindow.CastingWaste(castingSkill2);
                            //BattleSystem.instance.SaveSkill.Remove(castingSkill2);
                            removeList.Add(castingSkill2);

                            Skill skill2 = castingSkill2.skill.CloneSkill(true, null, null, false);
                            skill2.Counting = -99;

                            if (castingSkill2.Target != null)
                            {
                                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, castingSkill2.Target, false, false, false, null));
                            }
                            else if (castingSkill2.SkillTarget != null)
                            {
                                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, castingSkill2.SkillTarget));
                            }
                            else
                            {
                                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, null, false, false, false, null));
                            }
                        }
                    }
                }
                foreach (CastingSkill castingSkill3 in removeList)
                {
                    BattleSystem.instance.CastSkills.Remove(castingSkill3);
                    BattleSystem.instance.SaveSkill.Remove(castingSkill3);
                }
            }

            if (!skill.BasicSkill && skill.Master == this.BChar && skill.MySkill.KeyID != "S_Sakuya_P" && skill.MySkill.KeyID != "S_Sakuya_0_0" && skill.MySkill.KeyID != "S_Public_29")
            {
                if (skill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || skill == BattleSystem.instance.AllyTeam.Skills[0])
                {
                    this.BChar.BuffAdd("B_Sakuya_P_0", this.BChar, false, 0, false, -1, false);
                }
            }
        }

        public static void getTimeKnife(BattleChar chara, int count)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Sakuya_TKnife());
            }
            
            if (BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList.ContainsKey(chara))
            {
                BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[chara] += count;
            }
            else
            {
                BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList.Add(chara, count);
            }
            
            if (!chara.BuffFind("B_Sakuya_Knife"))
            {
                chara.BuffAdd("B_Sakuya_Knife", chara);
            }
        }
    }
}
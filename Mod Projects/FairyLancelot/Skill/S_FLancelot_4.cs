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
namespace FairyLancelot
{
	/// <summary>
	/// 你已完全属于我
	/// </summary>
    public class S_FLancelot_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].BuffFind("B_FLancelot_2") && Targets[0].BuffFind("B_FLancelot_3"))
            {
                for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
                {
                    BattleSystem.instance.AllyTeam.Skills[i].Delete(false);
                    i--;
                }

                BattleSystem.instance.AllyTeam.Skills.RemoveAll((Skill a) => a.MySkill.KeyID == "S_FLancelot_2" || a.MySkill.KeyID == "S_FLancelot_3" || a.MySkill.KeyID == "S_FLancelot_4" );
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.RemoveAll((Skill a) => a.MySkill.KeyID == "S_FLancelot_2" || a.MySkill.KeyID == "S_FLancelot_3" || a.MySkill.KeyID == "S_FLancelot_4" );
                BattleSystem.instance.AllyTeam.Skills_Deck.RemoveAll((Skill a) => a.MySkill.KeyID == "S_FLancelot_2" || a.MySkill.KeyID == "S_FLancelot_3" || a.MySkill.KeyID == "S_FLancelot_4" );

                this.BChar.MyTeam.AP += 5;

                for (int i = 0; i < 10 - BattleSystem.instance.AllyTeam.Skills.Count; i++)
                {
                    BattleSystem.instance.AllyTeam.Draw();
                }

                this.BChar.BuffAdd("B_FLancelot_4_0", this.BChar);
                
                for (int i = 0; i < Targets[0].BuffReturn("B_FLancelot_2").StackInfo.Count; i++)
                {
                    Targets[0].BuffReturn("B_FLancelot_2").StackInfo[i].RemainTime = 999;
                }

                for (int i = 0; i < Targets[0].BuffReturn("B_FLancelot_3").StackInfo.Count; i++)
                {
                    Targets[0].BuffReturn("B_FLancelot_3").StackInfo[i].RemainTime = 999;
                }

                for (int i = 0; i < Targets[0].BuffReturn("B_FLancelot_4").StackInfo.Count; i++)
                {
                    Targets[0].BuffReturn("B_FLancelot_4").StackInfo[i].RemainTime = 999;
                }
            }
        }
    }
}
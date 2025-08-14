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
	/// 最后的妖精
	/// 骑士 - 抽取 1 个技能。依据“舞者”的层数：①恢复 5 点体力值；②使抽取到的技能费用降低 1 点；③选择并生成 1 个自己的专属技能。
	/// 邪龙 - 获得持续 1 回合的“攻击力+1”。依据“龙之心”的层数：①额外获得持续 1 回合的“攻击力+1”；②额外获得持续 1 回合的“防御穿透+10%”；③选择并生成 1 个自己的专属技能。
	/// 好感度大于 10 时，若自身为“理智”：本回合结束时恢复所有友方单位 5 点体力值；
	/// 若自身为“狂化”：本回合结束时生成 1 个“龙鳞”。
	/// </summary>
    public class S_FLancelot_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FLancelot_C_2"))
            {
                switch (this.BChar.BuffReturn("B_FLancelot_P_4")?.StackNum ?? 0)
                {
                    case 1:
                        {
                            this.BChar.MyTeam.Draw();
                            this.BChar.BuffAdd("B_FLancelot_0_3", this.BChar);
                        }
                        break;
                    case 2:
                        {
                            this.BChar.MyTeam.Draw(new BattleTeam.DrawInput(this.Drawinput));
                            this.BChar.BuffAdd("B_FLancelot_0_3", this.BChar);
                        }
                        break;
                    case 3:
                        {
                            this.BChar.MyTeam.Draw(new BattleTeam.DrawInput(this.Drawinput));
                            this.BChar.BuffAdd("B_FLancelot_0_3", this.BChar);

                            CreateSkill();
                        }
                        break;
                }
            }
            if (this.BChar.BuffFind("B_FLancelot_C_1"))
            {
                this.BChar.BuffAdd("B_FLancelot_0", this.BChar);
                switch (this.BChar.BuffReturn("B_FLancelot_P_3")?.StackNum ?? 0)
                {
                    case 1:
                        {
                            this.BChar.BuffAdd("B_FLancelot_0", this.BChar);
                        }
                        break;
                    case 2:
                        {
                            this.BChar.BuffAdd("B_FLancelot_0", this.BChar);
                            this.BChar.BuffAdd("B_FLancelot_0_1", this.BChar);
                        }
                        break;
                    case 3:
                        {
                            this.BChar.BuffAdd("B_FLancelot_0", this.BChar);
                            this.BChar.BuffAdd("B_FLancelot_0_1", this.BChar);

                            CreateSkill();
                        }
                        break;
                }
            }
            if (PlayData.TSavedata.GetCustomValue<CV_FairyLancelotGood>().heartPoint >= 10)
            {
                this.BChar.BuffAdd("B_FLancelot_0_2", this.BChar);
            }
        }

        public void CreateSkill()
        {
            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck.FindAll(t => t.MySkill.KeyID != "S_Feiyap_3"));
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master.IsLucyNoC || list[i].Master != this.BChar)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
        }

        public void Drawinput(Skill skill)
        {
            skill.APChange = -1;
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill);
        }
    }
}
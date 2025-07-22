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
using System.Xml.Serialization;

namespace FairyLancelot
{
	/// <summary>
	/// 兰斯洛特
	/// Passive:
	/// 最大法力值提升 1 点。

    ///每当体力值小于等于最大体力值50%时，获得“狂化”；否则获得“理智”。

    ///每回合开始时，从“骑士”和“邪龙”中选择1项作为自己的形态。

    ///无法违背的誓约：进入战斗时，从 5 种“誓言”中选择 2 项。
    ///若在战斗中违背“誓言”，则好感度清零。
    ///若遵守“誓言”完成战斗，增加对应的好感度。
    ///到达100好感度时，解锁这个被动，不再需要“誓言”。
	/// </summary>
    public class P_FairyLancelot:Passive_Char, IP_BattleStart_Ones, IP_HPChange, IP_PlayerTurn
    {
        static public List<string> heartList = new List<string>();

        [XmlIgnore]
        public List<Skill> heartSkills = new List<Skill>();

        static public int heartPoint = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.MPR = 1;
            heartPoint = 0;
        }

        public void BattleStart(BattleSystem Ins)
        {
            heartList.Clear();

            this.BChar.BuffAdd("B_FLancelot_P", this.BChar);

            if (this.BChar.HP <= this.BChar.GetStat.maxhp * 0.5)
            {
                this.BChar.BuffAdd("B_FLancelot_P_1", this.BChar);
            }
            else
            {
                this.BChar.BuffAdd("B_FLancelot_P_2", this.BChar);
            }

            if (heartPoint < 100)
            {
                heartSkills = new List<Skill>();
                heartSkills.Add(Skill.TempSkill("S_FLancelot_H_1", this.BChar, this.BChar.MyTeam));
                heartSkills.Add(Skill.TempSkill("S_FLancelot_H_2", this.BChar, this.BChar.MyTeam));
                heartSkills.Add(Skill.TempSkill("S_FLancelot_H_3", this.BChar, this.BChar.MyTeam));
                heartSkills.Add(Skill.TempSkill("S_FLancelot_H_4", this.BChar, this.BChar.MyTeam));
                heartSkills.Add(Skill.TempSkill("S_FLancelot_H_5", this.BChar, this.BChar.MyTeam));
                foreach (Skill skill in heartSkills)
                {
                    skill.DelObj = this.BChar;
                }
                for (int i = 0; i < 2; i++)
                {
                    BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(heartSkills, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
                }
            }
        }

        public void Del(SkillButton Mybutton)
        {
            heartList.Add(Mybutton.Myskill.MySkill.KeyID);
            heartSkills.Remove(Mybutton.Myskill);
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char != this.BChar)
            {
                return;
            }
            if (Char.BuffFind("B_FLancelot_P_1", false))
            {
                if (Char.HP > this.BChar.GetStat.maxhp * 0.5)
                {
                    Char.BuffReturn("B_FLancelot_P_1")?.SelfDestroy();
                    Char.BuffAdd("B_FLancelot_P_2", this.BChar);
                }
            }
            else
            {
                if (Char.HP <= this.BChar.GetStat.maxhp * 0.5)
                {
                    Char.BuffReturn("B_FLancelot_P_2")?.SelfDestroy();
                    Char.BuffAdd("B_FLancelot_P_1", this.BChar);
                }
            }
        }

        public void Turn()
        {
            //好感度
            if (BattleSystem.instance.TurnNum == 3)
            {
                var haogan1 = BattleSystem.instance.AllyTeam.Skills_Deck.Where(s => s.MySkill.KeyID == "S_FLancelot_2").ToList();
                if (haogan1.Count != 0)
                {
                    BattleSystem.instance.AllyTeam.Skills_Deck.Remove(haogan1[0]);
                    BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, haogan1[0]);
                }

                var haogan2 = BattleSystem.instance.AllyTeam.Skills_Deck.Where(s => s.MySkill.KeyID == "S_FLancelot_3").ToList();
                if (haogan2.Count != 0)
                {
                    BattleSystem.instance.AllyTeam.Skills_Deck.Remove(haogan2[0]);
                    BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, haogan2[0]);
                }

                var haogan3 = BattleSystem.instance.AllyTeam.Skills_Deck.Where(s => s.MySkill.KeyID == "S_FLancelot_4").ToList();
                if (haogan3.Count != 0)
                {
                    BattleSystem.instance.AllyTeam.Skills_Deck.Remove(haogan3[0]);
                    BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, haogan3[0]);
                }
            }

            if (! (this.BChar.BuffFind("B_FLancelot_Rare_1") || this.BChar.BuffFind("B_FLancelot_Rare_2")))
            {
                List<Skill> list = new List<Skill>();
                list.Add(Skill.TempSkill("S_FLancelot_C_1", this.BChar, this.BChar.MyTeam));
                list.Add(Skill.TempSkill("S_FLancelot_C_2", this.BChar, this.BChar.MyTeam));
                foreach (Skill skill in list)
                {
                    skill.DelObj = this.BChar;
                }
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del2), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));

            }

            //遗骸
            var matchingSkills = BattleSystem.instance.AllyTeam.Skills_Deck.Where(s => s.MySkill.KeyID == "S_FLancelot_10").ToList();

            if (matchingSkills.Count == 0)
            {
                return;
            }

            new List<Skill>();
            List<Skill> list2 = new List<Skill>();
            list2.Add(Skill.TempSkill("S_FLancelot_10_1", this.BChar, this.BChar.MyTeam));
            list2.Add(Skill.TempSkill("S_FLancelot_10_2", this.BChar, this.BChar.MyTeam));
            foreach (Skill skill in list2)
            {
                skill.DelObj = this.BChar;
            }

            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list2, new SkillButton.SkillClickDel(this.Del3), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));
        }

        public void Del2(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_FLancelot_C_1")
            {
                this.BChar.BuffAdd("B_FLancelot_C_1", this.BChar);
                this.BChar.BuffReturn("B_FLancelot_C_2")?.SelfDestroy();
                this.BChar.BuffReturn("B_FLancelot_P_4")?.SelfDestroy();
                return;
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_FLancelot_C_2")
            {
                this.BChar.BuffAdd("B_FLancelot_C_2", this.BChar);
                this.BChar.BuffReturn("B_FLancelot_C_1")?.SelfDestroy();
                this.BChar.BuffReturn("B_FLancelot_P_3")?.SelfDestroy();
                return;
            }
        }

        public void Del3(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_FLancelot_10_1")
            {
                var matchingSkills = BattleSystem.instance.AllyTeam.Skills_Deck.Where(s => s.MySkill.KeyID == "S_FLancelot_10").ToList();

                if (matchingSkills.Count == 0)
                {
                    return;
                }

                if (matchingSkills.Count == 1)
                {
                    this.BChar.MyTeam.ForceDraw(matchingSkills[0]);
                    return;
                }

                // 有多个匹配项，随机返回其中一个
                System.Random rnd = new System.Random();
                int randomIndex = rnd.Next(0, matchingSkills.Count);
                this.BChar.MyTeam.ForceDraw(matchingSkills[randomIndex]);

                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    bc.Damage(this.BChar, 5, false, true);
                }

                return;
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_FLancelot_10_2")
            {
                return;
            }
        }
    }
}
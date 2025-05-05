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
namespace Parsee
{
	/// <summary>
	/// 面向露西的诅咒学概论
	/// 抽取 2 个技能。
	/// 选择
	/// - 生成 1 张“痛苦诅咒”。
	/// - 额外抽取 1 个技能，生成一张“痛苦诅咒”，生成一张魔女的“痛苦诅咒”。
	/// - 额外抽取 1 个技能。回复一点法力值，随机触发血雾诅咒。
	/// </summary>
    public class S_Parsee_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Parsee_LucyD_0", this.MySkill.Master, this.MySkill.Master.MyTeam));
            list.Add(Skill.TempSkill("S_Parsee_LucyD_1", this.MySkill.Master, this.MySkill.Master.MyTeam));
            list.Add(Skill.TempSkill("S_Parsee_LucyD_2", this.MySkill.Master, this.MySkill.Master.MyTeam));
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.TargetEffectSelect, false, false, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Parsee_LucyD_0")
            {
                Skill tmpSkill = Skill.TempSkill("S_WitchRelic", BattleSystem.instance.AllyTeam.LucyChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Parsee_LucyD_1")
            {
                BattleSystem.instance.AllyTeam.Draw();

                Skill tmpSkill = Skill.TempSkill("S_WitchRelic", BattleSystem.instance.AllyTeam.LucyChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

                Skill tmpSkill2 = Skill.TempSkill("S_Witch_P_0", BattleSystem.instance.AllyTeam.LucyChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Parsee_LucyD_2")
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleSystem.instance.AllyTeam.AP += 1;

                List<string> list = new List<string>();
                int per = this.ReturnPer();
                if (RandomManager.RandomPer(this.BChar.GetRandomClass().Main, 100, per))
                {
                    list.Add(GDEItemKeys.Skill_S_Transcendence_Virtue);
                    if (PlayData.TSavedata.bMist != null)
                    {
                        PlayData.TSavedata.bMist.CurseCardNum = 0;
                    }
                }
                else
                {
                    list.Add(GDEItemKeys.Skill_S_Transcendence_ManaMinus);
                    list.Add(GDEItemKeys.Skill_S_Transcendence_PainDamage);
                    list.Add(GDEItemKeys.Skill_S_Transcendence_Resist);
                    list.Add(GDEItemKeys.Skill_S_Transcendence_Shield);
                    list.Add(GDEItemKeys.Skill_S_Transcendence_Stun);
                    if (PlayData.TSavedata.bMist != null)
                    {
                        PlayData.TSavedata.bMist.CurseCardNum++;
                    }
                }
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(new List<Skill>
                {
                    Skill.TempSkill(list.Random(this.BChar.GetRandomClass().Main), BattleSystem.instance.AllyTeam.LucyAlly, null)
                }, new SkillButton.SkillClickDel(this.SelectSkill), ScriptLocalization.System_SkillSelect.BloodMyst, false, false, true, false, false));
            }
        }

        private int ReturnPer()
        {
            int result = 5;
            if (PlayData.TSavedata.bMist != null)
            {
                if (PlayData.TSavedata.bMist.CurseCardNum == 1)
                {
                    result = 5;
                }
                if (PlayData.TSavedata.bMist.CurseCardNum == 2)
                {
                    result = 15;
                }
                if (PlayData.TSavedata.bMist.CurseCardNum == 3)
                {
                    result = 25;
                }
                if (PlayData.TSavedata.bMist.CurseCardNum == 4)
                {
                    result = 25;
                }
                if (PlayData.TSavedata.bMist.CurseCardNum == 5)
                {
                    result = 25;
                }
                if (PlayData.TSavedata.bMist.CurseCardNum == 6)
                {
                    result = 100;
                }
            }
            return result;
        }

        private void SelectSkill(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == GDEItemKeys.Skill_S_Transcendence_ManaMinus)
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap - 1;
            }
            else if (Mybutton.Myskill.MySkill.KeyID == GDEItemKeys.Skill_S_Transcendence_PainDamage)
            {
                if (BattleSystem.instance.AllyTeam.AliveChars.Count >= 1)
                {
                    BattleChar battleChar = BattleSystem.instance.AllyTeam.AliveChars[0];
                    foreach (BattleChar battleChar2 in BattleSystem.instance.AllyTeam.AliveChars)
                    {
                        if (battleChar.HP < battleChar2.HP)
                        {
                            battleChar = battleChar2;
                        }
                    }
                    battleChar.Damage(BattleSystem.instance.DummyChar, 12, false, true, true, 0, false, false, false);
                }
            }
            else if (Mybutton.Myskill.MySkill.KeyID == GDEItemKeys.Skill_S_Transcendence_Stun)
            {
                BattleSystem.instance.AllyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main).BuffAdd(GDEItemKeys.Buff_B_Common_Rest, BattleSystem.instance.DummyChar, false, 200, false, -1, false);
            }
            else
            {
                if (Mybutton.Myskill.MySkill.KeyID == GDEItemKeys.Skill_S_Transcendence_Shield)
                {
                    using (List<BattleEnemy>.Enumerator enumerator2 = BattleSystem.instance.EnemyList.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            BattleEnemy battleEnemy = enumerator2.Current;
                            battleEnemy.BuffAdd(GDEItemKeys.Buff_B_Armor_P_1, BattleSystem.instance.DummyChar, false, 0, false, -1, false);
                        }
                        goto IL_26C;
                    }
                }
                if (Mybutton.Myskill.MySkill.KeyID == GDEItemKeys.Skill_S_Transcendence_Resist)
                {
                    using (List<BattleEnemy>.Enumerator enumerator2 = BattleSystem.instance.EnemyList.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            BattleEnemy battleEnemy2 = enumerator2.Current;
                            battleEnemy2.BuffAdd(GDEItemKeys.Buff_B_Blockdebuff, BattleSystem.instance.DummyChar, false, 0, false, -1, false);
                        }
                        goto IL_26C;
                    }
                }
                if (Mybutton.Myskill.MySkill.KeyID == GDEItemKeys.Skill_S_Transcendence_Virtue)
                {
                    BattleSystem.instance.AllyTeam.Draw();
                    BattleTeam allyTeam2 = BattleSystem.instance.AllyTeam;
                    int ap = allyTeam2.AP;
                    allyTeam2.AP = ap + 1;
                }
            }
        IL_26C:
            if (this.MySkill != null && this.MySkill.MyButton != null)
            {
                this.MySkill.Except();
            }
        }

        private BattleChar TargetTemp;
    }
}
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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 蛙符「涂有鲜血的赤蛙塚」
	/// 这个技能释放后拿回手中。
	/// 将目标技能放回牌库最下方。那之后，选择 - 重复释放1次，然后抽取1个技能，并使这个技能获得1层[苏醒]；或是什么都不做。
	/// 当这个技能获得5层[苏醒]时，放逐这个技能，将1个[祟神「赤口大人」]加入手中。
	/// </summary>
    public class S_Suwako_Rare_3:Skill_Extended, IP_SkillSelfLeaveHand
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;

                if (BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Suwako_Rare3());
                    return;
                }
            }
        }

        public Skill thisSkill;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            thisSkill = SkillD;
            BattleSystem.DelayInputAfter(Back());
            BattleSystem.DelayInputAfter(Reply());
        }

        public IEnumerator Back()
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));

            yield return BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true);

            yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));

            yield break;
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.DelayInputAfter(CustomMethods.I_SkillBackToDeck(Mybutton.Myskill, -1, false));
        }

        public IEnumerator Reply()
        {
            yield return null;

            List<Skill> list = new List<Skill>();

            list.Add(Skill.TempSkill("S_Suwako_Rare_3_1", this.BChar, this.BChar.MyTeam));
            list.Add(Skill.TempSkill("S_Suwako_Rare_3_2", this.BChar, this.BChar.MyTeam));

            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del2), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));

            yield return null;
            yield break;
        }

        public void Del2(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Suwako_Rare_3_1")
            {
                BattleSystem.DelayInputAfter(Back2());
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Suwako_Rare_3_2")
            {
                thisSkill.Delete(false);
            }
        }

        public IEnumerator Back2()
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));

            yield return BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true);

            yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));

            yield return BattleSystem.instance.AllyTeam._Draw();

            BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum++;

            if (BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum >= 5)
            {
                thisSkill.Except();

                Skill tmpSkill = Skill.TempSkill("S_Suwako_Rare_3_0", this.BChar, this.BChar.MyTeam);
                Skill_Extended se = new Skill_Extended();
                se.PlusSkillStat.Penetration = 100f;
                se.IsDamage = true;
                tmpSkill.ExtendedAdd(se);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

                BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum = 0;

                Skill tmpSkill2 = Skill.TempSkill("S_Suwako_Rare_3", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.InsertRandom(this.BChar.GetRandomClass().Main, tmpSkill2);
            }
            else
            {
                yield return BattleSystem.instance.AllyTeam._ForceDraw(thisSkill);
            }

            yield break;
        }

        public bool SelfLeaveHand(bool isUsed)
        {
            if (isUsed)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum == 5)
                {
                    this.MySkill.isExcept = true;

                    Skill tmpSkill = Skill.TempSkill("S_Suwako_Rare_3_0", this.BChar, this.BChar.MyTeam);
                    Skill_Extended se = new Skill_Extended();
                    se.PlusSkillStat.Penetration = 100f;
                    se.IsDamage = true;
                    tmpSkill.ExtendedAdd(se);
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public override string DescExtended(string desc)
        {
            int num = 0;
            if (BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>() != null)
            {
                num = BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum;
            }
            string str = "";
            str = ModManager.getModInfo("Suwako").localizationInfo.SystemLocalizationUpdate("S_Suwako_Rare_3/Text" + num);

            if (!BattleSystem.instance)
            {
                return base.DescExtended(desc).Replace("&a", num.ToString()).Replace("&b", str);
            }
            
            return base.DescExtended(desc).Replace("&a", BattleSystem.instance.GetBattleValue<BV_Suwako_Rare3>().UseNum.ToString()).Replace("&b", str);
        }
    }
}
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
namespace FFAce
{
	/// <summary>
	/// 朱雀刻印
	/// 在艾斯的所有技能中选择一个生成并获得相应的[抽取]效果。
	/// 可再次使用固定能力。
	/// 翻开：不将本技能将放回原位，而是置入手中。
	/// </summary>
    public class S_FFAce_Rare_2: SkillBase_Ace
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();
            List<GDESkillData> list2 = new List<GDESkillData>();
            foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
            {
                if (gdeskillData.User == Targets[0].Info.KeyData)
                {
                    list2.Add(gdeskillData);
                }
            }
            foreach (GDESkillData gdeskillData2 in list2)
            {
                if (gdeskillData2 != null && !gdeskillData2.KeyID.IsNullOrEmpty())
                {
                    Skill skill = Skill.TempSkill(gdeskillData2.KeyID, Targets[0], BattleSystem.instance.AllyTeam).CloneSkill(false, null, null, false);
                    skill.isExcept = true;
                    list.Add(skill);
                }
            }
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));

            BattleAlly ba = (this.BChar as BattleAlly);
            ba.MyBasicSkill.CoolDownNum = 0;
            if (ba.MyBasicSkill.ThisSkillUse)
            {
                ba.MyBasicSkill.InActive = false;
                ba.MyBasicSkill.ThisSkillUse = false;
            }
            if (ba.MyBasicSkill.InActive)
            {
                ba.MyBasicSkill.InActive = false;
            }
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.instance.AllyTeam.Add(Mybutton.Myskill, true);
        }

        public override void AceDraw()
        {
            base.AceDraw();
            BattleSystem.DelayInput(this.Draw());
            this.BChar.BuffAdd("B_FFAce_0", this.BChar);
        }

        public IEnumerator Draw()
        {
            if (!this.MySkill.isExcept)
            {
                bool flag = false;
                using (List<Skill>.Enumerator enumerator = BattleSystem.instance.AllyTeam.Skills.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.CharinfoSkilldata == this.MySkill.CharinfoSkilldata)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDrawList(this.MySkill.CharinfoSkilldata, null, true));
                }
            }
            else
            {
                int num = -1;
                for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills_UsedDeck.Count; i++)
                {
                    if (BattleSystem.instance.AllyTeam.Skills_UsedDeck[i].CharinfoSkilldata == this.MySkill.CharinfoSkilldata)
                    {
                        num = i;
                        break;
                    }
                }
                if (num != -1)
                {
                    BattleSystem.instance.AllyTeam.Skills_UsedDeck.RemoveAt(num);
                }
                else
                {
                    for (int j = 0; j < BattleSystem.instance.AllyTeam.Skills_Deck.Count; j++)
                    {
                        if (BattleSystem.instance.AllyTeam.Skills_Deck[j].CharinfoSkilldata == this.MySkill.CharinfoSkilldata)
                        {
                            BattleSystem.instance.AllyTeam.Skills_Deck.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            yield return null;
            yield break;
        }
    }
}
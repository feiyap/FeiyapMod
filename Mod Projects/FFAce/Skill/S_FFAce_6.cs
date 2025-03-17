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
	/// 冰晶共鸣
	/// 此技能被丢弃时，拿回手中并使艾斯获得1层[苍蓝之冰]。
	/// 翻开：获得1层[苍蓝之冰]，可再次使用固定能力。
	/// </summary>
    public class S_FFAce_6: SkillBase_Ace
    {
        public override void DiscardSingle(bool Click)
        {
            base.DiscardSingle(Click);
            BattleSystem.DelayInput(this.Draw());
            this.BChar.BuffAdd("B_FFAce_5", this.BChar);
        }

        public override void AceDraw()
        {
            base.AceDraw();

            this.BChar.BuffAdd("B_FFAce_5", this.BChar);

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
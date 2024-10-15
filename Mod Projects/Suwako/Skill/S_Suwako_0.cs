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
	/// 神具「洩矢的铁轮」
	/// <color=green>连击2</color> - 释放后返回牌组。
	/// <color=#008B45>旋回</color> - 本次战斗期间的所有[神具「洩矢的铁轮」]的伤害增加&a(30%)点。
	/// </summary>
    public class S_Suwako_0:Skill_Extended, IP_OnSkillAddToDeck
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.DelayInput(this.Delay(SkillD, Targets));
        }
        
        public IEnumerator Delay(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.DelayInput(this.Input(this.MySkill));

            yield return null;
            yield break;
        }
        
        public IEnumerator Input(Skill Useskill)
        {
            Skill Temp = Useskill.CloneSkill(true, Useskill.Master, null, false);
            if (!Useskill.isExcept && !Useskill.Disposable)
            {
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.Remove(Useskill);
                BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, Useskill);
            }
            else
            {
                Useskill.Delete(false);
            }
            yield return BattleSystem.instance.ActAfter();
            yield return null;
            yield break;
        }

        public IEnumerator OnSkillAddToDeck(List<Skill> AddToDeck_Skills)
        {
            Debug.Log("A");
            BattleSystem instance = BattleSystem.instance;
            if (((instance != null) ? instance.EnemyTeam : null) == null)
            {
                yield break;
            }
            this.BChar.BuffAdd("B_Suwako_0", this.BChar);
            Debug.Log("B");
            List<Skill> list = AddToDeck_Skills.FindAll((Skill x) => x.Master == this.BChar && x == this.MySkill);
            if (list != null && list.Count > 0)
            {
                Debug.Log("C");
                this.BChar.BuffAdd("B_Suwako_0", this.BChar);
            }

            yield break;
        }
    }
}
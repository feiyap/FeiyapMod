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
using UnityEngine.Events;

namespace DiffcultSystem
{
	/// <summary>
	/// 内啡肽
	/// 已激活的内啡肽：
	/// &a
	/// </summary>
    public class Endorphin:PassiveItemBase, IP_TurnEnd, IP_PlayerTurn
    {
        public override string DescExtended(string desc)
        {
            string baseDesc = base.DescExtended(desc);

            if (EndorphinSave.Instance.endorphinActiveList == null || EndorphinSave.Instance.endorphinActiveList.Count == 0)
            {
                return baseDesc.Replace("&a", "");
            }
            else
            {
                string replacementText = string.Join("\n",
                    EndorphinSave.Instance.endorphinActiveList.Select(key =>
                    {
                        ItemBase item = ItemBase.GetItem(key, 1);
                        return item?.GetName ?? key;
                    })
                );
                return baseDesc.Replace("&a", replacementText);
            }
        }

        public override void Init()
        {
            base.Init();
            //食髓知味：+速度+2。每回合抽取6个技能。
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Addicted"))
            {
                this.PlusStat.PlusDraw = 4;
                this.PlusStat.spd = 2;
            }
            else
            {
                this.PlusStat.PlusDraw = 0;
                this.PlusStat.spd = 0;
            }

            
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            //鬼祟玲珑：+露西技能法力值消耗-1。
            //鬼祟玲珑：+露西技能获得迅速。
        }

        public void Turn()
        {
            //疑神疑鬼：战斗开始时，在抽牌堆中随机加入一张露西技能。
            if (BattleSystem.instance.TurnNum == 1)
            {
                List<GDESkillData> list = new List<GDESkillData>();
                List<Skill> list2 = new List<Skill>();

                GDESkillData gdeskillData2 = list.Random(BattleSystem.instance.AllyTeam.LucyChar.GetRandomClass().Main);
                list2.Add(Skill.TempSkill(gdeskillData2.KeyID, BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam));
                if (list.Count > 0)
                {
                    BattleSystem.instance.AllyTeam.Skills_Deck.Add(list2.Random<Skill>());
                }
            }
        }

        public void TurnEnd()
        {
            //食髓知味：+回合结束时丢弃所有手牌。
            //食髓知味：-速度小于3时，回合结束时所有队员获得1层盐疫。
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Addicted"))
            {
                BattleSystem.DelayInput(this.Del());
                foreach (BattleAlly ba in BattleSystem.instance.AllyList)
                {
                    ba.BuffAdd("B_FishingVillageDebuff", ba);
                }
            }
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();

            for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
            {
                BattleSystem.instance.AllyTeam.Skills[i].Delete(false);
            }
            yield return new WaitForFixedUpdate();

            yield break;
        }
    }
}
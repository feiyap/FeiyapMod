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
    /// <color=green>连击4</color> - 释放后返回牌组。
    /// <color=#008B45>旋回</color> - 本次战斗期间的所有[神具「洩矢的铁轮」]的伤害增加&a(30%)点。
    /// </summary>
    public class S_Suwako_0 : SkillExtend_Suwako, IP_SkillSelfToDeck, IP_SkillSelfLeaveHand
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3)).ToString());
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance.GetBattleValue<BV_Suwako_0>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Suwako_0());
                return;
            }
            this.PlusAtk = (int)(this.BChar.GetStat.atk * 0.3);
            this.SkillBasePlus.Target_BaseDMG = BattleSystem.instance.GetBattleValue<BV_Suwako_0>().UseNum * this.PlusAtk;
        }

        public bool SelfLeaveHand(bool isUsed)
        {
            if (CheckUsedSkills(4) && isUsed)
            {
                BattleSystem.instance.AllyTeam.Skills_Deck.Add(this.MySkill);
                BattleSystem.instance.AllyTeam.Skills.Remove(this.MySkill);
                return false;
            }
            return true;
        }

        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleSystem.instance.GetBattleValue<BV_Suwako_0>().UseNum++;
        }

        private int PlusAtk = 0;
        public int UseNum;
    }
}
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
namespace Jhin
{
	/// <summary>
	/// 死之四章
	/// 每个回合只能使用 4 个技能。当前使用的技能数：<color=orange>&a</color>/4
	/// </summary>
    public class B_Jhin_P:Buff, IP_PlayerTurn, IP_SkillUse_User_After
    {
        int shotnum
        {
            get
            {
                if (BattleSystem.instance.GetBattleValue<BV_Jhin_P>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Jhin_P());
                }

                return BattleSystem.instance.GetBattleValue<BV_Jhin_P>().shotNum;
            }
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            (this.BChar as BattleAlly).MyBasicSkill.gameObject.SetActive(false);

            switch (shotnum)
            {
                case 1:
                    this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Jhin_P_1");
                    break;
                case 2:
                    this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Jhin_P_2");
                    break;
                case 3:
                    this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Jhin_P_3");
                    break;
                case 4:
                    this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Jhin_P_4");
                    break;
                default:
                    this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Jhin_P_5");
                    break;
            }
            
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            string nowID = "SE_Jhin_P_" + shotnum;
            return AddedSkill.Master == this.BChar && AddedSkill.ExtendedFind_DataName(nowID) == null && AddedSkill.MySkill.Rare == false;
        }

        public void SkillUseAfter(Skill SkillD)
        {
            if (SkillD.Master == this.BChar && SkillD.MySkill.Rare == false)
            {
                BattleSystem.instance.GetBattleValue<BV_Jhin_P>().shotNum++;
                if (shotnum == 4)
                {
                    this.BChar.BuffAdd("B_Jhin_P_0", this.BChar);
                }
            }
        }

        public void Turn()
        {
            BattleSystem.instance.GetBattleValue<BV_Jhin_P>().shotNum = 1;
        }

        public override string DescInit()
        {
            return base.DescInit().Replace("&a", (shotnum - 1).ToString());
        }
    }
}
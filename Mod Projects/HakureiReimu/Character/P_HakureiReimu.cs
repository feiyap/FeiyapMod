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
namespace HakureiReimu
{
    /// <summary>
    /// 博丽灵梦
    /// Passive:
    /// <b>在空中飞翔的不可思议的巫女</b> - 回合开始时，博丽灵梦获得1层[博丽结界]：所有增益抵抗+100%，受到攻击时解除1层，最大3层。
    /// <b>符卡等级</b> - 博丽灵梦每次使用与上次卡名不同的技能时，获得1层[符卡等级]；否则失去所有[符卡等级]。每层[符卡等级] 提供2%命中率和闪避率，并会解锁技能的额外效果。最多拥有5层[符卡等级]。
	/// </summary>
    public class P_HakureiReimu:Passive_Char, IP_PlayerTurn, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            this.BChar.BuffAdd("B_HakureiReimu_F_P_1", this.BChar, false, 0, false, -1, false);
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar && BattleSystem.instance.BattleLogs != null)
            {
                Skill lastSkill = BattleSystem.instance.BattleLogs.getLastSkill(false, false, (BattleLog log) => log.WhoUse == this.BChar, (Skill skilled) => !skilled.FreeUse);
                if (lastSkill == null || skill.MySkill.KeyID != lastSkill.MySkill.KeyID)
                {
                    this.BChar.BuffAdd("B_HakureiReimu_F_P", this.BChar, false, 0, false, -1, false);
                }
                else
                {
                    if (this.BChar.BuffFind("B_HakureiReimu_F_P") && !this.BChar.BuffFind("B_HakureiReimu_F_11Rare_0"))
                    {
                        this.BChar.BuffReturn("B_HakureiReimu_F_P").SelfDestroy();
                    }
                }
            }
        }
    }
}
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
namespace FairyLancelot
{
	/// <summary>
	/// 幻想种
	/// </summary>
    public class B_FLancelot_Rare_2:Buff, IP_DealDamage, IP_TurnEnd
    {
        public int fixCount = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            
            this.PlusStat.cri = 20;
            this.PlusStat.Penetration = 20;
            this.PlusStat.RES_CC = 40;
            this.PlusPerStat.Damage = 20;
            this.PlusPerStat.MaxHP = 110;
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 20 && !Take.Info.Ally)
            {
                //this.BChar.Damage(this.BChar, 5, false, true);
                
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    bc.BuffAdd("B_FLancelot_Barrier", this.BChar).BarrierHP += 5;
                }
            }
        }

        public void TurnEnd()
        {
            this.PlusStat.atk += this.BChar.MyTeam.AP;
            if (this.PlusStat.atk > 30)
            {
                this.PlusStat.atk = 30;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                foreach (Skill skill in this.BChar.MyTeam.Skills)
                {
                    if (skill.Master == this.BChar && skill.ExtendedFind_DataName("SE_FLancelot_Rare_2") == null)
                    {
                        skill.ExtendedAdd(Skill_Extended.DataToExtended("SE_FLancelot_Rare_2"));
                    }
                }
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 1.1f)).ToString());
        }
    }
}
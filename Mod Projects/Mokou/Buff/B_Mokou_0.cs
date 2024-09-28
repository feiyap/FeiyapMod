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
namespace Mokou
{
    public class B_Mokou_0:Buff, IP_TurnEndButtonEnemy, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void BuffStat()
        {
            this.PlusStat.maxhp = (12 * base.StackNum);
            this.PlusStat.atk = (float)base.StackNum;
            this.PlusStat.reg = (float)base.StackNum;
            this.PlusStat.hit = (float)(5 * base.StackNum);
            this.PlusStat.cri = (float)(5 * base.StackNum);
            this.PlusStat.RES_CC = (float)(5 * base.StackNum);
            this.PlusStat.RES_DEBUFF = (float)(5 * base.StackNum);
            this.PlusStat.RES_DOT = (float)(5 * base.StackNum);
            this.PlusStat.HIT_CC = (float)(5 * base.StackNum);
            this.PlusStat.HIT_DEBUFF = (float)(5 * base.StackNum);
            this.PlusStat.HIT_DOT = (float)(5 * base.StackNum);
            base.BuffStat();
        }
        public void Refresh()
        {
            this.PlusStat.maxhp = (12 * base.StackNum);
            this.PlusStat.atk = (float)base.StackNum;
            this.PlusStat.reg = (float)base.StackNum;
            this.PlusStat.hit = (float)(5 * base.StackNum);
            this.PlusStat.cri = (float)(5 * base.StackNum);
            this.PlusStat.RES_CC = (float)(5 * base.StackNum);
            this.PlusStat.RES_DEBUFF = (float)(5 * base.StackNum);
            this.PlusStat.RES_DOT = (float)(5 * base.StackNum);
            this.PlusStat.HIT_CC = (float)(5 * base.StackNum);
            this.PlusStat.HIT_DEBUFF = (float)(5 * base.StackNum);
            this.PlusStat.HIT_DOT = (float)(5 * base.StackNum);
        }
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, 
          bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit == this.BChar && Dmg >= base.StackNum)
            {
                return Dmg-base.StackNum;
            }
            return 0;
        }
        public void TurnEndButtonEnemy()
        {
            foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                if (this.BChar.BuffFind("B_Mokou_0",false) == true)
                {
                    for (int i = 0; i < this.BChar.BuffReturn("B_Mokou_0").StackNum; i++)
                    {
                        battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                    }
                }
            }
        }
    }
}
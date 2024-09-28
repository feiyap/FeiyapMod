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
namespace Kirito
{
    /// <summary>
    /// 尤吉欧
    /// 获得+40%无法战斗抵抗。战斗开始时，获得[蓝蔷薇之剑]：对敌人造成伤害时附加1层[冻伤]。
    /// 回合结束时，根据场上[冻伤] 层数恢复2x层数体力。7层时清空所有冻伤，将1张[绽放吧！蓝蔷薇] 加入手中。
    /// 如果桐人进入濒死状态，[蓝蔷薇之剑] 转变为[血色蔷薇之剑]：攻击力+40%。每次攻击恢复100%攻击力体力。
    /// </summary>
    public class B_Eugeo_P:Buff, IP_BattleStart_Ones, IP_TurnEnd, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DeadImmune = 40;
        }

        public void BattleStart(BattleSystem Ins)
        {
            
        }

        public void TurnEnd()
        {
            int num = 0;
            foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
            {
                if (battleEnemy.BuffFind("B_Eugeo_P_0_0", false))
                {
                    num += battleEnemy.BuffReturn("B_Eugeo_P_0_0", false).StackNum;
                }
            }
            this.BChar.Heal(this.BChar, num * 2, false, false, null);
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char.BuffFind("B_Eugeo_P_0", false))
            {
                if (Char.HP <= 0)
                {
                    Char.BuffAdd("B_Eugeo_P_1", Char, false, 0, false, -1, false);
                    Char.BuffRemove("B_Eugeo_P_0", true);
                }
            }
            else if (Char.BuffFind("B_Eugeo_P_1", false))
            {
                if (Char.HP > 0)
                {
                    Char.BuffAdd("B_Eugeo_P_0", Char, false, 0, false, -1, false);
                    Char.BuffRemove("B_Eugeo_P_1", true);
                }
            }
        }
    }
}
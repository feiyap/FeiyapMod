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
namespace Phrolova
{
    /// <summary>
    /// “来生”
    /// 死亡时，对所有敌人造成<color=purple>&a痛苦伤害</color><color=#FF7A33>(&user攻击力的33%/每层)</color>。
    /// </summary>
    public class B_Phrolova_P_1 : Buff, IP_Dead
    {
        public int count = 0;

        public void Dead()
        {
            if (count > 0)
            {
                return;
            }
            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                if (be == this.BChar || be.HP <= 0)
                {
                    continue;
                }
                be.Damage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 0.33 * StackNum), false, true);
                count++;
            }
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 0.33f)).ToString())
                                            .Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}
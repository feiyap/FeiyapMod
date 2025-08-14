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
	/// 霜冻
	/// 达到3层后，再次受到物理攻击时使目标和目标两边的敌人受到&a点伤害(&user攻击力的120%)；
	/// 若只有一个敌人，则受到&b点伤害(&user攻击力的170%)。
	/// 触发后解除该减益。
	/// </summary>
    public class B_FFAce_5_1:Buff, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -6 * StackNum;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (this.StackNum == 4 && !NODEF)
            {
                if (BattleSystem.instance.EnemyList.Count == 1)
                {
                    this.BChar.Damage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 1.2), true, true);
                }
                else
                {
                    int num = 0;
                    List<BattleEnemy> list = (this.BChar as BattleEnemy).EnemyPosNum(out num);
                    List<BattleChar> list2 = new List<BattleChar>();
                    if (num != 0)
                    {
                        list2.Add(list[num - 1]);
                    }
                    if (list.Count > num + 1)
                    {
                        list2.Add(list[num + 1]);
                    }
                    foreach (BattleChar bc in list2)
                    {
                        bc.Damage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 1.2), RandomManager.RandomPer(Usestate_F.GetRandomClass().DamageCri, 100, (int)(Usestate_F.GetStat.cri + (float)bc.GetStat.crihit)), true);
                    }
                    this.BChar.Damage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 1.2), RandomManager.RandomPer(Usestate_F.GetRandomClass().DamageCri, 100, (int)(Usestate_F.GetStat.cri + (float)BChar.GetStat.crihit)), true);
                }

                this.SelfDestroy();
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name)
                                      .Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1.2f)).ToString())
                                      .Replace("&b", ((int)(this.Usestate_F.GetStat.atk * 1.7f)).ToString());
        }
    }
}
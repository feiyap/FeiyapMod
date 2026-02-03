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
namespace HiHouClab
{
    /// <summary>
    /// 量子纠缠
    /// 受到伤害时发生传导，使自身以外持有“量子纠缠”的单位受到 100% 的量子伤害。
    /// 陷入濒死状态时解除。
    /// </summary>
    public class B_Renko_5 : Buff, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg <= 0)
            {
                return;
            }
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc != this.BChar && bc.BuffFind("B_Renko_5"))
                {
                    AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_StigmaExplosion).Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();
                    bc.QuantumDamage(this.Usestate_F, Dmg, Cri);
                }
            }
            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                if (bc != this.BChar && bc.BuffFind("B_Renko_5"))
                {
                    AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_StigmaExplosion).Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();
                    bc.QuantumDamage(this.Usestate_F, Dmg, Cri);
                }
            }
        }
    }
}
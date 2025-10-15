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
namespace Necromancer
{
	/// <summary>
	/// 灵压内爆
	/// 解除时，对自身造成100%伤害。
	/// 溢出的灵压内爆，将解除伤害增加300%。
	/// </summary>
    public class B_Necromancer_3:Buff, IP_BuffAdd, IP_BuffRemove, IP_Hit
    {
		private int accumulation = 0;
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == BChar && addedbuff.BuffData.Key == this.BuffData.Key)
            {
                accumulation++;
            }
        }
        public override void DestroyByTurn()
        {
            BattleSystem.DelayInput(Boom());
        }
        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            BattleSystem.DelayInput(Boom());
        }

        public void BuffRemove(BattleChar buffMaster, Buff buff)
        {
            if (buff.BuffData.Key == this.BuffData.Key && buffMaster == BChar)
            {
                BattleSystem.DelayInput(Boom());
            }
        }
        public IEnumerator Boom()
        {
            yield return new WaitForSeconds(.3f);
            AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_StigmaExplosion).Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();
            BChar.Damage(Usestate_F, ((int)(Usestate_F.GetStat.atk + 10) * (2 + accumulation * 3)), false, true);
            yield break;
        }
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (((int)(Usestate_F.GetStat.atk + 10) * (2 + accumulation * 3))).ToString()).Replace("&b", ((int)((Usestate_F.GetStat.atk + 10) * 3)).ToString());
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg > 0)
            {
                if (this.StackInfo[0].RemainTime <= 1)
                {
                    this.SelfDestroy();
                    return;
                }
                this.StackInfo[0].RemainTime -= 1;
            }
        }
    }
}
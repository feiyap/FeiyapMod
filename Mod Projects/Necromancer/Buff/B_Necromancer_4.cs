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
	/// 此身为祭
	/// 回合开始前，每层独立造成3点痛苦伤害。
	/// 忘却之灵：转为治疗。
	/// </summary>
    public class B_Necromancer_4:Buff, IP_BuffAdd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void DestroyByTurn()
        {
            BattleSystem.DelayInput(this.ATick());
        }

        public IEnumerator ATick()
        {
            yield return new WaitForFixedUpdate();
            if (BChar.BuffFind("B_Necromancer_1") == false & BChar.HP > 0)
            {
                //Buff buff = BChar.BuffAdd(GDEItemKeys.Buff_B_Momori_P_NoDead, this.BChar, false, 0, false, -1, false);
                BChar.Damage(BChar, 3, false, true);
                //buff.SelfDestroy();
            }
            else
            {
                BChar.Heal(BChar, 3f, false, true);
            }
            yield break;
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == BChar && addedbuff.BuffData.Key == this.BuffData.Key)
            {
                int moreStackNum = this.StackNum + addedbuff.StackNum - this.BuffData.MaxStack;
                if (moreStackNum <= 0)
                {
                    return;
                }
                for (int i = 0; i < moreStackNum; i++)
                {
                    BattleSystem.DelayInput(this.ATick());
                }
            }
        }
        public bool StackReduciton(int num)
        {
            if (num > base.StackNum)
            {
                return false;
            }
            else
            {
                if (num == base.StackNum)
                {
                    this.SelfDestroy();
                    return true;
                }
                else
                {
                    for(int i = 0; i < num; i++)
                    {
                        this.SelfStackDestroy();
                    }
                    return true;
                }
            }
        }
    }
}
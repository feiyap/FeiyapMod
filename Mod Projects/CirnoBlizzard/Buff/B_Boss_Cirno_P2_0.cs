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
namespace CirnoBlizzard
{
	/// <summary>
	/// 冰霜
	/// 每当自身被施加减益时，受到 &a 点痛苦伤害(攻击力的25%/每层)。
	/// </summary>
    public class B_Boss_Cirno_P2_0:Buff, IP_BuffAdd
    {
        public override string DescInit()
        {
            return base.DescInit().Replace("&a", ((int)(base.Usestate_F.GetStat.atk * 0.25f)).ToString());
        }
        
        public IEnumerator Damage(int damage)
        {
            yield return new WaitForSeconds(0.07f);
            AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Ilya_SnowFlakeEffect).Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();
            this.BChar.Damage(base.Usestate_F, damage, false, true, false, 0, false, false, false);
            yield break;
        }
        
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Debuff && addedbuff.BuffData.Key != "B_Neardeath")
            {
                BattleSystem.DelayInput(this.Damage((int)(base.Usestate_F.GetStat.atk * 0.25f)));
            }
        }
    }
}
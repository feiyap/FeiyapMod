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
	/// 无光之境界
	/// 保护罩破裂时对所有敌人造成 &a 量子伤害(&user治疗力的160%)。
	/// </summary>
    public class B_Maribel_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.BarrierHP += (int)Misc.PerToNum(base.Usestate_L.GetStat.reg, 160f);
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            foreach (BattleChar be in BattleSystem.instance.EnemyList)
            {
                int dmg = (int)Misc.PerToNum(base.Usestate_L.GetStat.reg, 160f);
                AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_StigmaExplosion).Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = be.GetTopPos();
                be.QuantumDamage(this.Usestate_F, dmg, false);
            }
        }

        public override string DescInit()
        {
            return base.DescInit().Replace("&a", ((int)(this.BChar.GetStat.reg * 1.6)).ToString())
                                  .Replace("&user", this.BChar.Info.Name);
        }
    }
}
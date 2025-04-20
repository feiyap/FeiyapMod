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
namespace Yuyuko
{
	/// <summary>
	/// 完全凭依 - 幽幽子
	/// 造成的伤害转化为最大体力值降低。
	/// </summary>
    public class E_YuyukoF_2:EquipBase, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 2;
            this.PlusStat.cri = 25;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!View && Damage > 0)
            {
                if (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_YuyukoF_P());
                }

                Damage += (int)Misc.PerToNum((float)Damage, (float)((int)Target.GetStat.DMGTaken));

                if (Cri)
                {
                    Damage = (int)((float)Damage * (1.5f + (this.BChar.GetStat.PlusCriDmg + (float)Target.GetStat.CRIGetDMG) * 0.01f));
                }

                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(Target, Damage, this.BChar, false, Cri);

                return 0;
            }

            return Damage;
        }
    }
}
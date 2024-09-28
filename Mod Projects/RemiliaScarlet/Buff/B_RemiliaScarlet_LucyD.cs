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
namespace RemiliaScarlet
{
    /// <summary>
    /// 千年吸血鬼
    /// 防御力减少10%；造成伤害25%吸血；每次造成伤害抽1个技能，1回合最多触发4次。
    /// </summary>
    public class B_RemiliaScarlet_LucyD: Buff, IP_DealDamage
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -10f;
            count = 0;
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1)
            {
                this.BChar.Heal(this.BChar, (float)((int)((float)Damage * 0.25f)), false, false, null);
                if (count < 4)
                {
                    BattleSystem.instance.AllyTeam.Draw();
                    count++;
                }
            }
        }

        int count;
    }
}
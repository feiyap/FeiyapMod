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
	/// <color=#FF69B4>人魂蝶</color>
	/// &effect
	/// </summary>
    public class B_YuyukoF_Butterfly_R:Buff
    {
        public int effect = 0;

        public override void Init()
        {
            base.Init();

            this.PlusStat.IgnoreTaunt_EnemySelf = false;
            if (effect == 0)
            {
                this.PlusStat.IgnoreTaunt_EnemySelf = true;
            }
        }

        public void ButterflyChange()
        {
            switch (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M)
            {
                case "S_YuyukoF_0":
                    {
                        effect = 0;
                    }
                    break;
                case "S_YuyukoF_1":
                    {
                        effect = 1;
                    }
                    break;
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (effect == 1)
            {
                if (!NODEF)
                {
                    BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, Dmg, this.Usestate_F);
                    return 0;
                }
            }

            return Dmg;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&effect", ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate(BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_R + "_2/Text"));
        }
    }
}
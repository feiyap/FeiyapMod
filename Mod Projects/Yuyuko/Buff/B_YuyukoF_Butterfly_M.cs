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
	/// <color=#4876FF>幽冥蝶</color>
	/// &effect
	/// </summary>
    public class B_YuyukoF_Butterfly_M:Buff, IP_ButterflyChange, IP_DamageTakeChange
    {
        public int effect = 0;

        public override void Init()
        {
            base.Init();
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

        public override void TurnUpdate()
        {
            base.TurnUpdate();

            if (effect == 0)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, this.BChar.Info.OriginStat.maxhp * 10 / 100, this.Usestate_F);
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (effect == 1)
            {
                if (NODEF)
                {
                    BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, Dmg, this.Usestate_F);
                    return 0;
                }
            }

            return Dmg;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&effect", ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate(BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M + "_1/Text"));
        }
    }
}
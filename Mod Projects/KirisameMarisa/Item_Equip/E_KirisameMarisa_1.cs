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
namespace KirisameMarisa
{
	/// <summary>
	/// 普通的扫帚
	/// 在领地中点击该装备时，在“速度+5”和“速度-5”之间切换。
	/// </summary>
    public class E_KirisameMarisa_1:EquipBase, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 80;
        }

        public void BattleStart(BattleSystem Ins)
        {
            if (this.BChar.Info.Equip[0] != null && this.BChar.Info.Equip[0].itemkey == "E_KirisameMarisa_1")
            {
                this.PlusStat.spd = 5;
            }
            else
            {
                this.PlusStat.spd = -5;
            }
        }
    }
}
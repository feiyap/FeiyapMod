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
	/// 危险领域
	/// 这个增益被施加时，提供“等量于当前速度”的速度。
	/// </summary>
    public class B_KirisameMarisa_9_2:Buff, IP_HPChange
    {
        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char.HP <= 0)
            {
                Char.HP = 1;
                Char.IsDead = false;
                EffectView.SimpleTextout(Char.GetPos(), ScriptLocalization.UI_Battle.Endure, true, 1f, false, 1f);
            }
        }
    }
}
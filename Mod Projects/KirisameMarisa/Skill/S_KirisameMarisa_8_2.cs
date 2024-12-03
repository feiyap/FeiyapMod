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
	/// 天仪「Orrery's Solar System」
	/// <color=#00BFFF>危险等级2</color> - 获得2次等待次数。
	/// </summary>
    public class S_KirisameMarisa_8_2: S_KirisameMarisa_8
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Buff> list = new List<Buff>();
            foreach (Buff buff in this.BChar.Buffs)
            {
                if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                {
                    list.Add(buff);
                }
            }
            if (list.Count != 0)
            {
                this.BChar.BuffRemove(list.Random(this.BChar.GetRandomClass().Main).BuffData.Key, false);
            }
        }
    }
}
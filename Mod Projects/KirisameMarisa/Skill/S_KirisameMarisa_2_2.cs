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
	/// 魔符「Illusion Star」
	/// </summary>
    public class S_KirisameMarisa_2_2: SkillBase_KirisameMarisa
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int Fixed_count2 = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count2++;

            if (Fixed_count2 >= 12)
            {
                Fixed_count2 = 0;

                if (this.BChar.Recovery == this.BChar.HP)
                {
                    this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.8f);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.8f)).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.Recovery == this.BChar.HP)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.8f);
            }
        }
    }
}
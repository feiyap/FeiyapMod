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
namespace Phrolova
{
	/// <summary>
	/// 变音符
	/// 固定能力造成的伤害提升&a%<color=#FF7A33>(&user攻击力的100%)</color>。
	/// </summary>
    public class SE_Phrolova_4:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillPerFinal.Damage = (int)(this.BChar.GetStat.atk * 2);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!this.BChar.BuffFind("B_Phrolova_4"))
            {
                this.SelfDestroy();
            }
        }
    }
}
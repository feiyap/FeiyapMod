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
	/// 光击「Shoot the Moon」
	/// <color=#00BFFF>危险等级3</color> - 同时施加“提升等量于当前速度的速度”，持续3回合。
	/// </summary>
    public class S_KirisameMarisa_9_3: SkillBase_KirisameMarisa
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            ChoiceSkillList.Clear();
            this.ChoiceSkillList.Add("S_KirisameMarisa_9_C");
            this.ChoiceSkillList.Add("S_KirisameMarisa_9_D");
        }
    }
}
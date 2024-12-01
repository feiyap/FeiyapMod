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
	/// 光符「Earth Light Ray」
	/// 选择 - 施加[危险冲动]；
	/// 或施加[危险本能]。
	/// </summary>
    public class S_KirisameMarisa_9: SkillBase_KirisameMarisa
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            ChoiceSkillList.Clear();
            this.ChoiceSkillList.Add("S_KirisameMarisa_9_A");
            this.ChoiceSkillList.Add("S_KirisameMarisa_9_B");
        }
    }
}
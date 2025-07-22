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
namespace FAlice
{
	/// <summary>
	/// 苍符「博爱的奥尔良人形」
	/// 这个技能处于倒计时中时，为&user提供“+1治疗力”。
	/// 触发时，对体力值最低的、已受伤的友军治疗一次。
	/// 每触发 3 次后，下 1 次触发改为对所有友军造成治疗。
	/// </summary>
    public class S_FAlice_2:Skill_Extended
    {

    }
}
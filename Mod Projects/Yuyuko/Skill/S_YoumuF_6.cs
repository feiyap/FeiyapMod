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
	/// 人鬼「未来永劫斩」
	/// 无视防御。
	/// 先造成1次&a伤害(攻击力的60%)，再造成16次&b伤害(攻击力的29%)，最后造成一次&c伤害(攻击力的500%)。
	/// 若目标陷入濒死状态，且场上存在非濒死状态的调查员，则攻击对象转移至其他非濒死状态的调查员。
	/// </summary>
    public class S_YoumuF_6:Skill_Extended
    {

    }
}
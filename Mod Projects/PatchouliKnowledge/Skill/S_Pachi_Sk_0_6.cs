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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 月金符「日光反射器」
	/// 将目标变为一只人畜无害的小动物。
	/// 若目标是友军，还会驱散所有减益效果，且恢复 2 点法力值。
	/// 若目标是Boss，则改为眩晕 1 回合。
	/// </summary>
    public class S_Pachi_Sk_0_6:Skill_Extended
    {

    }
}
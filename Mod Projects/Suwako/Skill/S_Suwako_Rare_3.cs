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
namespace Suwako
{
	/// <summary>
	/// 蛙符「涂有鲜血的赤蛙塚」
	/// 这个技能释放后拿回手中。
	/// 将目标技能放回牌库最下方。那之后，选择 - 重复释放1次，然后抽取1个技能，并使这个技能获得1层[苏醒]；或是什么都不做。
	/// 当这个技能获得5层[苏醒]时，放逐这个技能，将1个[祟神「赤口大人」]加入手中。
	/// </summary>
    public class S_Suwako_Rare_3:Skill_Extended
    {

    }
}
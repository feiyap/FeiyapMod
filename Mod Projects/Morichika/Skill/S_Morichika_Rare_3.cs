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
namespace Morichika
{
	/// <summary>
	/// 无理由退换
	/// 这个技能握在手中时，每次使用其他技能会使这个技能费用降低 1 点，同时此技能的 X 回合后弃牌的回合计数将减少 1 。
	/// 使用时，展示目标在本场战斗中使用过的所有非放逐技能。选择其中 4 个，在手中生成其复制，附带放逐。
	/// 若这个技能在费用为 0 时使用，还会使那些技能费用变为 0 。
	/// </summary>
    public class S_Morichika_Rare_3:Skill_Extended
    {

    }
}
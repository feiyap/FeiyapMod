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
namespace Ralmia2
{
	/// <summary>
	/// 洛菈米娅
	/// Passive:
	/// 部分技能带有“融合”词条。
	/// 通过点击技能右侧的“融合”图标，可以将其他技能与该技能进行融合，触发“融合”效果。
	/// </summary>
    public class P_RalmiaBeyond:Passive_Char
    {

    }

    public interface IP_Fusion
    {
        void FusionCall(Skill skill);
    }

    public interface IP_FusionAfter
    {
        void FusionAfterCall();
    }
}
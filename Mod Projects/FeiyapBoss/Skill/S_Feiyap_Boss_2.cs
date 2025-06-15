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
namespace FeiyapBoss
{
	/// <summary>
	/// 明镜止水
	/// 若自身持有的减益数量超过 5 个，解除自身所有<sprite=0>弱化减益和<sprite=1>痛苦减益。受到那些减益的剩余伤害量的痛苦伤害。
	/// 移除所有手牌的额外增益效果。
	/// </summary>
    public class S_Feiyap_Boss_2:Skill_Extended
    {

    }
}
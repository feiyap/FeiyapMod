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
using ChronoArkMod.ModData;
namespace IzayoiSakuya
{
    class BV_Sakuya_TKnife
    {
        public int TimeKnife = 0;

        public Dictionary<BattleChar, int> KnifeList = new Dictionary<BattleChar, int>();
    }
}
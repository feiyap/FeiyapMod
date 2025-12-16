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
namespace Jhin
{
    /// <summary>
    /// 露出破绽
    /// 这个目标本回合内受过伤，已经被标记了！
    /// </summary>
    public class B_Jhin_2 : Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            this.SelfDestroy();
        }
    }
}
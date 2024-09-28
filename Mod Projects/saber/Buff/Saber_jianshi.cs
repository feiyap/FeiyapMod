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
namespace saber
{
    /// <summary>
    /// 剑势
    /// 阿尔托莉雅打出了<color=#ED5C26>剑技</color>
    /// </summary>
    public class Saber_jianshi : Buff, IP_SkillUse_User_After
    {
        public void SkillUseAfter(Skill SkillD)
        {
            base.SelfStackDestroy();
        }
    }
}
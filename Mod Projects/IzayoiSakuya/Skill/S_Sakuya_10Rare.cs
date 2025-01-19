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
namespace IzayoiSakuya
{
    /// <summary>
    /// 时符「个人空间」
    /// 倒计时期间，所有自己的技能变为0费，附加迅速、倒计时1，并且无法以任何方式抽取技能。
    /// </summary>
    public class S_Sakuya_10Rare:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.BChar.BuffAdd("B_Sakuya_10Rare_0", this.BChar, false, 0, false, -1, false);
        }
    }
}
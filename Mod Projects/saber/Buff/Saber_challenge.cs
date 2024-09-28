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
    /// 挑战
    /// </summary>
    public class Saber_challenge : B_Taunt, IP_Awake, IP_SkillUse_User
    {
        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&target", base.Usestate_F.Info.Name);
        }

        // Token: 0x06000011 RID: 17 RVA: 0x000023B7 File Offset: 0x000005B7
        public override void Init()
        {
            base.Init();
            this.PlusStat.hit = -10f;
        }
    }

}
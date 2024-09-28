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
    /// 整备
    /// 无法行动并获得50%减伤
    /// </summary>
    public class Saber_zhengbei : Common_Buff_Rest
    {
        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&target", base.Usestate_F.Info.Name);
        }

        // Token: 0x06000014 RID: 20 RVA: 0x00002413 File Offset: 0x00000613
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = -50f;
        }
    }
}
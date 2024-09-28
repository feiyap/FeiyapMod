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
    /// 无畏
    /// 暴击率＋10%
    /// 暴击伤害+20%
    /// 攻击力+25%
    /// 吾王剑之所指，吾等心之所向！
    /// </summary>
    public class Saber_lingdao_B : Buff
    {
        // Token: 0x0600000A RID: 10 RVA: 0x0000224B File Offset: 0x0000044B
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = (int)(float)(20 * base.StackNum);
            this.PlusStat.cri = (float)(10 * base.StackNum);
            this.PlusStat.PlusCriDmg = (float)(20 * base.StackNum);
            this.PlusStat.PlusCriHeal = (float)(20 * base.StackNum);
        }
    }
}
    
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
namespace VillageAlice
{
	/// <summary>
	/// 美梦
	/// 攻击时有概率&a(60%-干扰抵抗率)攻击自己。
	/// 进入[梦境]时，受到50%+1攻击力的混乱伤害，然后减少一层。
	/// </summary>
    public class B_FVAlice_1:Buff, IP_ChangeReality
    {
        public void ChangeReality(bool istrue)
        {
            if (istrue)
            {
                this.BChar.ChaosDamage(this.Usestate_F, (int)(this.Usestate_F.GetStat.atk * 0.5f + 1), false);
                this.SelfStackDestroy();
            }
        }
    }
}
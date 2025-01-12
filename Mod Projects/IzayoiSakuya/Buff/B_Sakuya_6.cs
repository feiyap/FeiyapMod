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
	/// 误导效应
	/// 其他友军被选定为技能的目标时，使目标改为指向自己。
	/// 触发后移除一层。
	/// </summary>
    public class B_Sakuya_6:Buff, IP_TargetedAlly
    {
        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            bool flag = false;
            for (int i = 0; i < SaveTargets.Count; i++)
            {
                if (SaveTargets[i] == this.BChar)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int j = 0; j < SaveTargets.Count; j++)
                {
                    if (SaveTargets[j] != this.BChar)
                    {
                        SaveTargets[j] = this.BChar;
                        EffectView.TextOutSimple(this.BChar, this.BuffData.Name);
                    }
                }
                SelfStackDestroy();
            }
            return null;
        }
    }
}
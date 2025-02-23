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
namespace Squall
{
	/// <summary>
	/// 枪刃格挡
	/// 每当敌方释放指向单个友军的技能时，由&user承受攻击。
	/// 承受攻击后该增益减少一层。
	/// </summary>
    public class B_Squall_0:Buff, IP_TargetedAlly
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
        }

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

                        foreach (IP_SaveTargets ip in BattleSystem.instance.IReturn<IP_SaveTargets>())
                        {
                            if (ip != null)
                            {
                                ip.SaveTargets();
                            }
                        }
                    }
                }
                SelfStackDestroy();
            }
            return null;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}
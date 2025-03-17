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
namespace FFAce
{
	/// <summary>
	/// 零式预判
	/// 闪避一次攻击，触发后解除该增益。
	/// 使敌人最先释放的下个攻击技能只能攻击有零式预判的友军。
	/// </summary>
    public class B_FFAce_3:Buff, IP_Dodge, IP_TargetedAlly
    {
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                base.SelfDestroy(false);
            }
        }
        
        public override void Init()
        {
            base.Init();
            this.PlusStat.PerfectDodge = true;
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
                    }
                }
                SelfStackDestroy();
            }
            return null;
        }
    }
}
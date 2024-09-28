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
namespace Mokou
{
    /// <summary>
    /// 咒符「无差别放火之符」
    /// 过热：3——所有敌人的痛苦减益持续时间增加1回合。
    /// </summary>
    public class S_Mokou_7 : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (EX_ability.CheckEXburn(3, this.BChar))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            num = 0;
            if (EX_ability.CheckEXburn(3, this.BChar))
            {
                num = 1;
            }
            if (this.BChar.Recovery > this.BChar.HP)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
                {
                    if (battleChar is BattleEnemy)
                    {
                        battleChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                    }
                }
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
        }
        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);
            if (num == 1)
            {
                BattleSystem.DelayInput(this.FireEffect());
                EX_ability.UseEXburn(3, this.BChar);
            }
        }
        public IEnumerator FireEffect()
        {
            foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
            {
                foreach (Buff buff in battleEnemy.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false))
                {
                    foreach (StackBuff stackBuff in buff.StackInfo)
                    {
                        if (stackBuff.RemainTime != 0)
                        {
                            stackBuff.RemainTime++;
                        }
                    }
                }
            }
            yield return null;
            yield break;
        }
        public int num = 0;
    }
}
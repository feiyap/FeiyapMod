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
	/// 狮子奋起
	/// 可以在<b>无法行动</b>的状态下使用。
	/// 解除自身的<sprite=2>干扰减益。
	/// 使<sprite=1>痛苦减益和<sprite=0>弱化减益的持续时间减少1回合。
	/// 给所有敌人赋予“挑衅”。
	/// </summary>
    public class S_Squall_1:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.CanUseStun = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.CC, false))
            {
                buff.SelfDestroy();
            }
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false))
            {
                if (!buff.BuffData.Hide)
                {
                    buff.TurnUpdate();
                }
            }
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false))
            {
                if (!buff.BuffData.Hide)
                {
                    buff.TurnUpdate();
                }
            }
            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                be.BuffAdd("B_Sqaull_WeakTaunt", this.BChar);
            }
        }
    }
}
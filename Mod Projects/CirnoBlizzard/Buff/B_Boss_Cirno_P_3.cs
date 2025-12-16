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
namespace CirnoBlizzard
{
    /// <summary>
    /// 爱与妖精之心
    /// 受到攻击时，恢复自身 &a 体力值(治疗力的39%)。
    /// 每次受到治疗时，获得“受到治疗量-5%”。
    /// 当自身受到治疗量低于0%时，追加释放“冰花恋曲”，并移除“受到治疗量降低”的效果。
    /// </summary>
    public class B_Boss_Cirno_P_3 : Buff, IP_Hit, IP_Dodge, IP_Healed
    {
        int Healnum
        {
            get
            {
                return (int)(this.BChar.GetStat.reg * 0.39);
            }
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                this.BChar.Heal(this.BChar, Healnum, false, false, null);
            }
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            this.BChar.Heal(this.BChar, Healnum, false, false, null);
        }

        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal)
        {
            if (HealedChar == this.BChar && HealNum > 0)
            {
                this.PlusStat.HEALTaken -= 5;
            }

            if (this.BChar.GetStat.HEALTaken < 0)
            {
                this.PlusStat.HEALTaken = 0;
                BattleSystem.DelayInputAfter(this.Del());
            }
        }

        private IEnumerator Del()
        {
            List<BattleChar> list = new List<BattleChar>();
            Skill skill = Skill.TempSkill("S_Boss_Cirno_P3_S", this.BChar, this.BChar.MyTeam);
            list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
            BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 9, false);
            yield break;
        }
    }
}
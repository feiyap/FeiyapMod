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
namespace Parsee
{
    /// <summary>
    /// 怨恨念法「积怨返」
    /// 握在手中时，每当队员受到来自友军的伤害时，该技能的伤害增加，增加量与所受伤害量相等，最多增加量为自身治疗力的600%。
    /// 自身处于濒死状态时，获得迅速。
    /// 所有友军处于濒死状态时，改为指向全体敌人。
    /// 妒火层数≥4时，暴击率+100%。
    /// </summary>
    public class S_Parsee_8:Skill_Extended, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = 0;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (User.Info.Ally && Hit.Info.Ally && !Preview)
            {
                this.SkillBasePlus.Target_BaseDMG += Dmg;
            }

            if (this.SkillBasePlus.Target_BaseDMG >= (int)(6 * this.BChar.GetStat.reg))
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(6 * this.BChar.GetStat.reg);
            }

            return Dmg;
        }

        public override void FixedUpdate()
        {
            if (this.BChar.HP <= 0)
            {
                this.NotCount = true;
            }
            else
            {
                this.NotCount = false;
            }

            if ((this.BChar.BuffReturn("B_Parsee_P")?.StackNum ?? 0) >= 4)
            {
                this.PlusSkillStat.cri = 100f;
            }
            else
            {
                this.PlusSkillStat.cri = 0f;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int count = 0;
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc.HP <= 0)
                {
                    count++;
                }
            }

            if (count >= BattleSystem.instance.AllyList.Count)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
                {
                    if (battleChar != Targets[0])
                    {
                        Targets.Add(battleChar);
                    }
                }
            }
        }
    }
}
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
    public class B_Sakuya_Knife:Buff, IP_SkillUse_Target, IP_Dodge
    {
        public override void Init()
        {
            base.Init();
            if (BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Sakuya_TKnife());
            }
        }

        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;
                
                int count = BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar];

                this.PlusStat.cri = 5 * count;
                this.PlusStat.dod = 5 * count;
            }
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if ((SP.SkillData.IsDamage || SP.SkillData.IsHeal) && Cri)
            {
                int count = BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar];

                if (count >= 1)
                {
                    BattleSystem.DelayInputAfter(this.Attack(hit));
                }
            }
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                int count = BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar];

                if (count >= 1)
                {
                    BattleSystem.DelayInputAfter(this.Attack(SP.SkillData.Master));
                }
            }
        }

        public IEnumerator Attack(BattleChar bc)
        {
            yield return new WaitForSecondsRealtime(0.25f);

            Skill skill = Skill.TempSkill("S_Sakuya_Knife", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;

            if (bc != null || bc.IsDead)
            {
                this.BChar.ParticleOut(skill, bc);
                BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar]--;
            }
            else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
                BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar]--;
            }
            
            yield break;
        }

        public override string DescInit()
        {
            return base.DescInit().Replace("&a", (BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar]).ToString())
                                  .Replace("&b", ((int)(base.Usestate_F.GetStat.atk * 0.3f)).ToString());
        }
    }
}
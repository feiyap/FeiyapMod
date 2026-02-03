using BasicMethods;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using NLog.Targets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace HiHouClab
{
    /// <summary>
    /// 七石之狼、登天吞云
    /// 倒计时期间，目标受到的伤害降低为0，并记录减免的伤害值。
    /// 这个技能造成的伤害增加记录的伤害值。
    /// 这个技能从倒计时栏离开时，这个技能立即释放。
    /// 当前记录伤害值：&a
    /// </summary>
    public class S_Renko_8 : Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit, IP_DamageTakeChange_Renko8
    {
        public BattleChar saveTarget = null;
        public bool isFlag = false;
        public int saveDamage = 0;

        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = saveDamage;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            saveTarget = ThisSkill.Target;
            isFlag = true;
            saveDamage = 0;
            saveTarget.BuffAdd("B_Renko_8", this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            if (ThisSkill.CastSpeed > 0)
            {
                ThisSkill.Use();
            }

            //saveTarget.BuffReturn("B_Renko_8").SelfDestroy();
            //BattleSystem.DelayInputAfter(this.Del(ThisSkill));
            saveTarget = null;
            isFlag = false;
        }

        private IEnumerator Del(CastingSkill ThisSkill)
        {
            yield return new WaitForFixedUpdate();
            if (!BattleSystem.instance.CastSkills.Any((CastingSkill i) => i != ThisSkill && i.skill.MySkill.KeyID == "S_Renko_8" && i.TargetReturn() == ThisSkill.TargetReturn()) && !BattleSystem.instance.SaveSkill.Any((CastingSkill i) => i != ThisSkill && i.skill.MySkill.KeyID == "S_Renko_8" && i.TargetReturn() == ThisSkill.TargetReturn()))
            {
                ThisSkill.Target.BuffRemove("B_Renko_8");
            }
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", saveDamage.ToString());
        }

        public void DamageTakeChange_Renko8(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (saveTarget == null || !isFlag || Preview) {  return; }

            saveDamage += Dmg;
        }
    }
}
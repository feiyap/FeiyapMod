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
using BasicMethods;
namespace Suwako
{
    /// <summary>
    /// 神具「洩矢的铁轮」
    /// <color=green>连击4</color> - 释放后返回牌组。
    /// <color=#008B45>旋回</color> - 本次战斗期间的所有[神具「洩矢的铁轮」]的伤害增加&a(30%)点。
    /// </summary>
    public class S_Suwako_0 : SkillExtend_Suwako, IP_SkillSelfToDeck
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.6)).ToString());
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckUsedSkills(2))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }

                if (BattleSystem.instance.GetBattleValue<BV_Suwako_0>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Suwako_0());
                    return;
                }
                this.PlusAtk = (int)(this.BChar.GetStat.atk * 0.6);
                this.SkillBasePlus.Target_BaseDMG = BattleSystem.instance.GetBattleValue<BV_Suwako_0>().UseNum * this.PlusAtk;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckUsedSkills(2))
            {
                this.MySkill.isExcept = true;
            }
        }

        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);

            if (CheckUsedSkills(4))
            {
                Skill skill = this.MySkill.CloneSkill(true, this.BChar, null, false);
                skill.isExcept = false;
                if (!this.MySkill.FreeUse)
                {
                    BattleSystem.DelayInputAfter(CustomMethods.I_SkillBackToDeck(skill, -1, false));
                }
            }
        }

        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleSystem.instance.GetBattleValue<BV_Suwako_0>().UseNum++;
        }

        private int PlusAtk = 0;
        public int UseNum;
    }
}
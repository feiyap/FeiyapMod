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
    /// 土著神「洩矢神」
    /// 将手中最上方的技能放回牌库，抽取1个技能。
    /// <color=green>连击4</color> - 生成1个1费的[土著神「洩矢神」]。
    /// </summary>
    public class S_Suwako_6 : SkillExtend_Suwako
    {
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
                if (CheckUsedSkills(4))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.StartCoroutine(this.EffectDelaysCo());

            if (CheckUsedSkills(4))
            {
                Skill tmpSkill = Skill.TempSkill("S_Suwako_6_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }

        private IEnumerator EffectDelaysCo()
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(this.BChar.MyTeam.Skills);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == this.MySkill)
                {
                    list.RemoveAt(i);
                    break;
                }
            }
            if (list.Count >= 1)
            {
                yield return CustomMethods.I_SkillBackToDeck(list[0], -1, true);
            }

            while (BattleSystem.instance.ListWait || BattleSystem.instance.Particles.Count != 0 || GameObject.FindGameObjectsWithTag("EffectView").Length != 0 || GameObject.FindGameObjectsWithTag("Tutorial").Length != 0 || BattleSystem.instance.DelayWait)
            {
                yield return new WaitForFixedUpdate();
            }

            yield return this.BChar.MyTeam._Draw();
        }
    }
}
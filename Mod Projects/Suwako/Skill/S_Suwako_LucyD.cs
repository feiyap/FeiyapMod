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
	/// 开宴「二拜二拍一拜」
	/// 将手中最下面的技能放回牌库，抽取3个技能。
	/// </summary>
    public class S_Suwako_LucyD:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(this.MySkill.Master.MyTeam.Skills);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == SkillD)
                {
                    list.RemoveAt(i);
                    break;
                }
            }
            if (list.Count >= 1)
            {
                //BattleSystem.DelayInputAfter(this.Return(list[list.Count - 1]));
                BattleSystem.instance.StartCoroutine(this.EffectDelaysCo(SkillD));
            }
            //BattleSystem.DelayInputAfter(this.Draw());
        }

        private IEnumerator EffectDelaysCo(Skill SkillD)
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(this.MySkill.Master.MyTeam.Skills);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == SkillD)
                {
                    list.RemoveAt(i);
                    break;
                }
            }
            if (list.Count >= 1)
            {
                yield return CustomMethods.I_SkillBackToDeck(list[list.Count - 1], 0, true);
            }

            while (BattleSystem.instance.ListWait || BattleSystem.instance.Particles.Count != 0 || GameObject.FindGameObjectsWithTag("EffectView").Length != 0 || GameObject.FindGameObjectsWithTag("Tutorial").Length != 0 || BattleSystem.instance.DelayWait)
            {
                yield return new WaitForFixedUpdate();
            }

            yield return this.BChar.MyTeam._Draw(3);
        }

        public IEnumerator Return(Skill skill)
        {
            yield return CustomMethods.I_SkillBackToDeck(skill, -1, true);

            yield return null;
            yield break;
        }

        public IEnumerator Draw()
        {
            yield return this.MySkill.Master.MyTeam._Draw(3);

            yield return null;
            yield break;
        }
    }
}
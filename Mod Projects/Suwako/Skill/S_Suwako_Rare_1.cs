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
	/// 蛙狩「蛙以口鸣，方致蛇祸」
	/// <color=green>连击4</color> - 随机从牌库中释放4个自己的技能。那之后，将他们放回牌库最上方。
	/// </summary>
    public class S_Suwako_Rare_1: SkillExtend_Suwako
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
            if (!CheckUsedSkills(4))
            {
                return;
            }

            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master.IsLucyNoC || list[i].Master != this.BChar)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            int num = 0;
            if (list.Count >= 4)
            {
                num = 4;
            }
            else
            {
                num = list.Count;
            }

            if (num <= 0)
            {
                return;
            }

            for (int i = 0; i < num; i++)
            {
                BattleSystem.DelayInput(this.Del(list[i]));
            }
        }

        private IEnumerator Del(Skill skill)
        {
            yield return new WaitForFixedUpdate();

            BattleSystem.DelayInputAfter(this.Draw(skill));
            BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
            BattleSystem.DelayInputAfter(CustomMethods.I_SkillBackToDeck(skill, -1, true));

            yield break;
        }

        public IEnumerator Draw(Skill skill)
        {
            yield return null;

            BattleSystem.instance.AllyTeam.ForceDraw(skill);

            yield return null;
            yield break;
        }
    }
}
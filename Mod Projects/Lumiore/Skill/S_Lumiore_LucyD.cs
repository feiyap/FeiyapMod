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
namespace Lumiore
{
	/// <summary>
	/// 聚龙之唤
	/// 优先抽取1张牌堆中消费最高的技能。
	/// 觉醒：从1张改为2张。
	/// </summary>
    public class S_Lumiore_LucyD:Skill_Extended
    {
        private bool useflag;
        private bool isSpecies;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();
            if (this.BChar.MyTeam.MAXAP >= 7)
            {
                this.isSpecies = true;
                base.SkillParticleOn();
            }
            else
            {
                this.isSpecies = false;
                base.SkillParticleOff();
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            BattleSystem.DelayInputAfter(this.Draw());
        }

        public IEnumerator Draw()
        {
            int num;
            int count = 1;
            if (isSpecies) count = 2;
            for (int i = 0; i < count; i = num + 1)
            {
                List<Skill> list = new List<Skill>();
                list.AddRange(this.BChar.MyTeam.Skills_Deck);
                if (list.Count != 0)
                {
                    list.Sort((Skill x1, Skill x2) => x2._AP.CompareTo(x1._AP));
                    yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(list[0], null));
                }
                num = i;
            }
            yield break;
        }
    }
}
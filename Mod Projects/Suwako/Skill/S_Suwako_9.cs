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
namespace Suwako
{
	/// <summary>
	/// 神樱「湛樱花吹雪」
	/// 从手牌和弃牌库中各选择1个技能，将它们放回牌堆，再抽取到手中。
	/// <color=#008B45>旋回</color> - 将弃牌库中最上面的1个技能放回牌堆，再抽取到手中。
	/// </summary>
    public class S_Suwako_9: SkillExtend_Suwako
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
                    this.PlusSkillStat.cri = 100f;
                }
                else
                {
                    base.SkillParticleOff();
                    this.PlusSkillStat.cri = 0;
                }
            }
        }
    }
}
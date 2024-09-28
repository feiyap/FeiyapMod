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
namespace Sunmeitian
{
	/// <summary>
	/// 筋斗云
	/// 如果自身拥有[真假猴王]，同时指向目标左边和右边的敌人。
	/// </summary>
    public class S_Sunmeitian_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_Sunmeitian_1", false))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (!this.MySkill.FreeUse && this.BChar.BuffFind("B_Sunmeitian_1"))
            {
                if (!Targets[0].Info.Ally)
                {
                    if (BattleSystem.instance.EnemyList.Count == 1)
                    {
                        return;
                    }

                    int num = 0;
                    List<BattleEnemy> list = (Targets[0] as BattleEnemy).EnemyPosNum(out num);
                    if (num != 0)
                    {
                        Targets.Add(list[num - 1]);
                    }
                    if (list.Count > num)
                    {
                        Targets.Add(list[num + 1]);
                        return;
                    }
                }
            }
        }
    }
}
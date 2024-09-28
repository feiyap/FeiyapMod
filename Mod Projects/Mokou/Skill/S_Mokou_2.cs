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
namespace Mokou
{
    /// <summary>
    /// 藤原「灭罪寺院伤」
    /// 过热：3——对具有烧伤的目标施加灭罪而非嘲讽，同时获得两回合的保护体力极限。
    /// </summary>
    public class S_Mokou_2 : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (EX_ability.CheckEXburn(3, this.BChar))
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
            num = 0;
            foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                if (EX_ability.CheckEXburn(3, this.BChar))
                {
                    num = 1;
                }
                if (battleChar.BuffFind("B_Mokou_T_1",false) == true && num == 1)
                {
                    battleChar.BuffAdd("B_Mokou_T_2", this.BChar, false, 0, false, -1, false);
                }
                else
                {
                    Buff buff = battleChar.BuffAdd(GDEItemKeys.Buff_B_Taunt, this.BChar, false, 0, false, 3, false);
                    if(battleChar.BuffFind(GDEItemKeys.Buff_B_Taunt,false) == true)
                    {
                        buff.TimeUseless = false;
                        buff.LifeTime = 3;
                        buff.StackInfo[0].RemainTime = 2;
                    }
                }
            }
            if (num == 1)
            {
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                EX_ability.UseEXburn(3, this.BChar);
            }
        }
        public int num = 0;
    }
}
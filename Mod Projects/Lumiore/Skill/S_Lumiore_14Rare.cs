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
	/// 伟大的调停者·佐伊
	/// 所有友军的体力降为1点。获得1回合BUFF[背水一战]：保护体力极限，受到的伤害转变为0。
	/// 激奏1：增加1张费用为4且没有激奏效果的伟大的调停者·佐伊到牌库中。抽取1个技能。
	/// </summary>
    public class S_Lumiore_14Rare:Skill_Extended
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
            if (this.BChar.MyTeam.AP < 11)
            {
                this.isSpecies = true;

                this.ChangedTarget = GDEItemKeys.s_targettype_Misc;
                this.APChange = -10;
            }
            else
            {
                this.isSpecies = false;

                this.ChangedTarget = GDEItemKeys.s_targettype_enemy;
                this.APChange = 0;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            if (!this.isSpecies)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    this.BChar.HP = 1;
                    battleChar.BuffAdd("B_Lumiore_14Rare", this.BChar, false, 0, false, 1, false);
                }
                return;
            }

            this.BChar.MyTeam.Skills_Deck.InsertRandom(Skill.TempSkill("S_Lumiore_14Rare_0", this.BChar, this.BChar.MyTeam));
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}
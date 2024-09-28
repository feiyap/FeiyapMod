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
	/// 金色威信·璐米欧儿
	/// 自己获得1回合BUFF[金色威信]：每次手中的技能被交换/丢弃时，对所有敌人造成交换/舍弃的个数x1倍攻击力的伤害。
	/// 然后回复3点能量。若[本场战斗中，丢弃手牌的次数]为4次以上，丢弃2个技能，抽取3个技能。
	/// </summary>
    public class S_Lumiore_13Rare:Skill_Extended
    {
        private bool useflag;
        private bool isSpecies;

        public override void Init()
        {
            base.Init();
            count = 0;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_Lumiore_P", false) && this.BChar.BuffReturn("B_Lumiore_P", false).StackNum >= 4)
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
            BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
            int ap = allyTeam.AP;
            allyTeam.AP = ap + 3;

            list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill y) => y != this.MySkill));
            for (int i = 0; i < 2; i++)
            {
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete(false);
            list.Remove(Mybutton.Myskill);
            count++;
            if (count == 2)
            {
                count = 0;
                if (!isSpecies)
                {
                    return;
                }

                BattleSystem.instance.AllyTeam.Draw(3);
            }
        }

        public int count;
        private List<Skill> list;
    }
}
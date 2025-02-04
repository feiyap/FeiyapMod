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
namespace szb_elena
{
	/// <summary>
	/// 传教司祭·萝蕾娜
	/// 将1个“萝蕾娜的圣水”加入手中。
	/// 当自己回复生命值时，如果该回复为自己本回合中的第2次，则会使这个技能获得“打出时，对随机敌人造成&a伤害(攻击力的130%)”。
	/// </summary>
    public class S_szb_elena_7:Skill_Extended, IP_ElenaHealed
    {
        private bool isSpecies ;
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 1.3)).ToString());
        }
        public void ElenaHealed()
        {
            if (P_szb_elena.TurnHealedNum == 2)
            {
                isSpecies = true;
                base.SkillParticleOn();
            }
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {

            Skill skill = Skill.TempSkill(ModItemKeys.Skill_S_szb_elena_7_0, this.BChar, this.BChar.MyTeam);
            skill.NotCount = true;
            skill.isExcept = true;
            this.BChar.MyTeam.Add(skill.CloneSkill(false, null, null, false), true);
            if (isSpecies) 
            {
                BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main).Damage(this.BChar, (int)(this.BChar.GetStat.atk * 1.3), false, false, false, 0, false, false, false);
                this.isSpecies = false;
                base.SkillParticleOff();
            }


        }
    }
}
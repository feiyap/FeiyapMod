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
namespace Necromancer
{
	/// <summary>
	/// 彻心之痛
	/// 同时对自身造成伤害。
	/// 忘却之灵：添加一张彻心之痛进入手牌。
	/// 抽到时，添加一张彻心之痛进入手牌，并抽取所有同名技能。
	/// </summary>
    public class S_P_Necromancer_3:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            
        }
        public override IEnumerator DrawAction()
        {
            Skill skill = Skill.TempSkill("S_P_Necromancer_3", BChar, BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(skill, true);

            foreach (Skill skill1 in BattleSystem.instance.AllyTeam.Skills_Deck)
            {
                if (skill1.MySkill.KeyID == "S_P_Necromancer_3")
                {
                    BattleSystem.instance.AllyTeam.ForceDraw(skill1);
                }
            }
            yield break;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!BChar.BuffFind("B_Necromancer_1") && BChar.HP > 0)
            {
                this.Flag = true;
            }
            else
            {
                this.Flag = false;
            }
        }
        public override bool Terms()
        {
            return this.Flag;
        }
        public bool Flag;
    }
}
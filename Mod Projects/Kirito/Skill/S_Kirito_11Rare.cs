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
namespace Kirito
{
	/// <summary>
	/// 星爆气流斩
	/// 重复造成一共16次伤害。依据选择的后宫团成员获得额外效果：
	/// -亚丝娜：使用时如果是0费，生成1张8费的[星爆气流斩]加入手中。
	/// -诗乃：抽1。触发3次[狙击支援]。
	/// -尤吉欧：抽2。施加[星爆气流]：受到痛苦伤害翻倍。
	/// </summary>
    public class S_Kirito_11Rare:Skill_Extended
    {
        public override void SkillUseHandBefore()
        {
            MasterAudio.PlaySound("S_Kirito_11Rare");
            BattleSystem.DelayInput(this.wait());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            //MasterAudio.PlaySound("S_Kirito_11Rare");
            //BattleSystem.DelayInput(this.wait());

            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                if (this.MySkill.UsedApNum == 0)
                {
                    Skill tmpSkill = Skill.TempSkill("S_Kirito_11Rare", this.BChar, this.BChar.MyTeam);
                    tmpSkill.APChange = -5;
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                }
            }

            if (this.BChar.BuffFind("B_Shino_P", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleSystem.DelayInputAfter(this.Ienum());
                BattleSystem.DelayInputAfter(this.Ienum());
                BattleSystem.DelayInputAfter(this.Ienum());
            }

            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleSystem.instance.AllyTeam.Draw();
                for (int i = 0; i < Targets.Count; i++)
                {
                    if (Targets[i] is BattleEnemy && !Targets[i].BuffFind("B_Eugeo_11Rare", false))
                    {
                        Targets[i].BuffAdd("B_Eugeo_11Rare", this.BChar, false, 0, false, -1, false);
                    }
                }
                Skill tmpSkill = Skill.TempSkill("S_Eugeo_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                Skill tmpSkill2 = Skill.TempSkill("S_Eugeo_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
                Skill tmpSkill3 = Skill.TempSkill("S_Eugeo_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill3, true);
            }
            
            for (int i = 0; i < 15; i++)
            {
                //BattleSystem.DelayInputAfter(this.Ienum2());
                BattleSystem.DelayInput(this.Effect());
            }
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Shino_0", this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }

        public IEnumerator Ienum2()
        {
            Skill skill = Skill.TempSkill("S_Kirito_11Rare", this.BChar, this.BChar.MyTeam);
            Skill_Extended extended = new Skill_Extended();
            skill.ExtendedAdd(extended);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSecondsRealtime(0.01f);
            yield break;
        }

        public IEnumerator Effect()
        {
            for (int i = 0; i < BattleSystem.instance.EnemyList.Count; i++)
            {
                Skill skill = Skill.TempSkill("S_Kirito_11Rare_0", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyList[i]);
            }
            yield return new WaitForSeconds(0.1f);
            yield break;
        }

        public IEnumerator wait()
        {
            yield return new WaitForSeconds(3.5f);
            yield break;
        }
    }
}
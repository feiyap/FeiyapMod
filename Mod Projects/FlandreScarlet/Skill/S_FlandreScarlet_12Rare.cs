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
namespace FlandreScarlet
{
	/// <summary>
	/// 禁忌「莱瓦汀」
	/// 使用这个技能击杀敌人后，回复2点法力值，获得永久1%暴击率加成，这场战斗中无法再从技能中获得永久暴击率加成。
	/// 禁忌 - 额外造成&a(75%)伤害，这个技能+10%暴击率。
	/// </summary>
    public class S_FlandreScarlet_12Rare:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.75f));
            }
        }

        public override void Init()
        {
            base.Init();
            flag = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = PlusDmg;
                this.PlusSkillStat.cri = 10f;
            }
            else
            {
                base.SkillParticleOff();
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.PlusSkillStat.cri = 0f;
            }

            if (!this.flag && this.MySkill.MyButton != null && !this.MySkill.BasicSkill && !this.MySkill.MyButton.AlreadyWasted)
            {
                bool flag = false;
                int num = -9;
                for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
                {
                    if (BattleSystem.instance.AllyTeam.Skills[i] == this.MySkill)
                    {
                        num = i;
                    }
                }
                int mynum = -9;
                for (int j = 0; j < BattleSystem.instance.AllyTeam.Skills.Count; j++)
                {
                    if (BattleSystem.instance.AllyTeam.Skills[j].MySkill.KeyID == "S_RemiliaScarlet_2" && (j == num - 1 || j == num + 1))
                    {
                        mynum = j;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    this.flag = true;
                    BattleSystem.DelayInput(this.Effect(num, mynum));
                }
            }
        }

        public IEnumerator Effect(int Mynum, int Mynum2)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            Skill skill;
            Skill skill2;
            if (Mynum < BattleSystem.instance.AllyTeam.Skills.Count && Mynum2 < BattleSystem.instance.AllyTeam.Skills.Count)
            {
                skill = BattleSystem.instance.AllyTeam.Skills[Mynum];
                skill2 = BattleSystem.instance.AllyTeam.Skills[Mynum2];
                if (skill.MyButton != null && !skill.MyButton.AlreadyWasted && skill2.MyButton != null && !skill2.MyButton.AlreadyWasted)
                {
                    skill.Delete(false);
                    skill2.Delete(false);
                }
                List<BattleChar> list = new List<BattleChar>();
                list.AddRange(BattleSystem.instance.AllyTeam.AliveChars);
                list.Reverse();
                BattleSystem.instance.AllyTeam.Skills.Add(Skill.TempSkill("S_FlandreScarlet_14Rare", skill.Master, skill.Master.MyTeam));
                BattleSystem.instance.AllyTeam.Skills.Add(Skill.TempSkill("S_FlandreScarlet_14Rare", skill2.Master, skill2.Master.MyTeam));
                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
            }

            yield return new WaitForFixedUpdate();
            yield break;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            flag = false;
            if (this.BChar.BuffFind("B_FlandreScarlet_P_V", false)
                || this.BChar.BuffFind("B_FlandreScarlet_7", false)
                || this.BChar.BuffFind("B_FlandreScarlet_11Rare", false))
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = PlusDmg;
                this.PlusSkillStat.cri = 10f;
            }
            else
            {
                base.SkillParticleOff();
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.PlusSkillStat.cri = 0f;
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            if (!this.BChar.BuffFind("B_FlandreScarlet_12Rare", false))
            {
                this.BChar.Info.OriginStat.cri += 1;
                this.BChar.BuffAdd("B_FlandreScarlet_12Rare", this.BChar);
            }
            this.BChar.MyTeam.AP += 2;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }

        public bool flag;
    }
}
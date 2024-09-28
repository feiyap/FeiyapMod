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
namespace IzayoiSakuya
{
	/// <summary>
	/// 时符「个人空间」
	/// 生成5张[时计「月时计」]加入手中。本回合干扰成功率+50%。倒计时期间咲夜不能使用手中的技能。
	/// 月魔术·上弦月：倒计时期间咲夜仍然能够使用手中的技能。
	/// 月魔术·下弦月：不再生成[时计「月时计」]。恢复AP至最大，清空露西和所有队员的过载，抽3张手牌。
	/// </summary>
    public class S_Sakuya_10Rare:Skill_Extended
    {
        public int flag;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                flag = 0;
                base.SkillParticleOff();
                this.MySkill.MySkill.Name = "时符「个人空间」";
                this.Counting = 2;
                if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[0]
                    || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null
                    || this.BChar.BuffFind("B_Sakuya_12Rare"))
                {
                    flag = 1;
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Name = "「咲夜的世界」";
                    this.Counting = 1;
                    return;
                }
                if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null
                    || this.BChar.BuffFind("B_Sakuya_12Rare"))
                {
                    flag = 2;
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Name = "「收缩的世界」";
                    this.Counting = 0;
                    return;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffAdd("B_Sakuya_10Rare", this.BChar, false, 0, false, -1, false);

            if (this.flag == 0)
            {
                this.Counting = 2;
                Skill tmpSkill = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                Skill tmpSkill2 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
                Skill tmpSkill3 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill3, true);
                Skill tmpSkill4 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill4, true);
                Skill tmpSkill5 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill5, true);
                return;
            }
            if (this.flag == 1)
            {
                this.Counting = 1;
                Skill tmpSkill = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                Skill tmpSkill2 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
                Skill tmpSkill3 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill3, true);
                Skill tmpSkill4 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill4, true);
                Skill tmpSkill5 = Skill.TempSkill("S_Sakuya_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill5, true);
                return;
            }
            if (this.flag == 2)
            {
                this.Counting = 0;
                this.BChar.MyTeam.AP = this.BChar.MyTeam.MAXAP;
                foreach (BattleChar battleChar in this.BChar.MyTeam.AliveChars)
                {
                    battleChar.Overload = 0;
                }
                BattleSystem.instance.AllyTeam.LucyChar.Overload = 0;
                this.BChar.MyTeam.Draw(3);
                return;
            }
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            if (this.flag == 0)
            {
                this.BChar.BuffAdd("B_Sakuya_10Rare_0", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}
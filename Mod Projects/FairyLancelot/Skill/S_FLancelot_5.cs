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
namespace FairyLancelot
{
	/// <summary>
	/// 龙之枪
    /// 骑士 - 击杀敌人时，溢出的伤害会分摊给其他敌人。

    /// 邪龙 - 施加“-10%防御力、+10%受到的伤害”，持续 3 回合。
    /// 丢弃手中最上方的技能，依据那个技能的原本费用：
    /// 0 - 抽取 1 个技能。
    /// 1 - 额外造成 &a 伤害(攻击力的90%)。
    /// 2及以上 - 自身获得“+20%暴击率”，持续 3 回合。

    /// 好感度50 - 随机生成 1 个露西稀有技能。
	/// </summary>
    public class S_FLancelot_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FLancelot_C_2"))
            {
                
            }
            if (this.BChar.BuffFind("B_FLancelot_C_1"))
            {
                Targets[0].BuffAdd("B_FLancelot_5", this.BChar);

                int num = BattleSystem.instance.AllyTeam.Skills[0]._AP;
                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
                BattleSystem.instance.AllyTeam.Skills[0].Delete(false);

                switch (num)
                {
                    case 0:
                        {
                            this.BChar.MyTeam.Draw();
                        }
                        break;
                    case 1:
                        {
                            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.9);
                        }
                        break;
                    case 2:
                        {
                            this.BChar.BuffAdd("B_FLancelot_5_1", this.BChar);
                        }
                        break;
                    default:
                        {
                            this.BChar.BuffAdd("B_FLancelot_5_1", this.BChar);
                        }
                        break;
                }
            }
            if (P_FairyLancelot.heartPoint >= 50)
            {
                CreateSkill();
            }
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (this.BChar.BuffFind("B_FLancelot_C_2"))
            {
                if (DMG > hit.HP)
                {
                    foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                    {
                        if (be != hit)
                        {
                            be.Damage(this.BChar, DMG - hit.HP, false);
                        }
                    }
                }
            }
        }

        public void CreateSkill()
        {
            List<Skill> list = new List<Skill>();
            List<GDESkillData> list2 = new List<GDESkillData>();
            using (List<GDESkillData>.Enumerator enumerator = PlayData.ALLSKILLLIST.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    GDESkillData i = enumerator.Current;
                    if (i.Category.Key == GDEItemKeys.SkillCategory_LucySkill && i.User == "Lucy")
                    {
                        list2.Add(i);
                    }
                }
            }
            GDESkillData gdeskillData = list2.Random(this.BChar.GetRandomClass().Main);
            BattleSystem.instance.AllyTeam.Add(Skill.TempSkill(gdeskillData.Key, PlayData.TempBattleTeam.DummyChar, PlayData.TempBattleTeam).CloneSkill(false, null, null, false), true);
        }
    }
}
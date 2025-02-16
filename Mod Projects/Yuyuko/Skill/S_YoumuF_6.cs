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
using System.Linq;
namespace Yuyuko
{
	/// <summary>
	/// 人鬼「未来永劫斩」
	/// 无视防御。
	/// 先造成1次&a伤害(攻击力的60%)，再造成16次&b伤害(攻击力的29%)，最后造成一次&c伤害(攻击力的500%)。
	/// 若目标陷入濒死状态，且场上存在非濒死状态的调查员，则攻击对象转移至其他非濒死状态的调查员。
	/// </summary>
    public class S_YoumuF_6:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            bool flag = BattleSystem.instance != null;
            string result;
            if (flag)
            {
                string text = base.DescExtended(desc);
                result = ((text != null) ? text.Replace("&a", ((int)Misc.PerToNum(this.BChar.GetStat.atk, (float)new GDESkillData("S_YoumuF_6_1").Effect_Target.DMG_Per)).ToString()).Replace("&b", ((int)Misc.PerToNum(this.BChar.GetStat.atk, (float)new GDESkillData("S_YoumuF_6_2").Effect_Target.DMG_Per)).ToString()).Replace("&c", ((int)Misc.PerToNum(this.BChar.GetStat.atk, (float)new GDESkillData("S_YoumuF_6_3").Effect_Target.DMG_Per)).ToString()) : null);
            }
            else
            {
                string text2 = base.DescExtended(desc);
                result = ((text2 != null) ? text2.Replace("&a", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 60f)).ToString()).Replace("&b", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 29f)).ToString()).Replace("&c", ((int)Misc.PerToNum(this.BChar.GetStat.atk, 500f)).ToString()) : null);
            }
            return result;
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.MySkill.MySkill.Effect_Target.DMG_Per = 0;
            this.SkillBasePlus.Target_BaseDMG = 0;

            BattleSystem.DelayInput(this.Effect(Targets));
        }
        
        public IEnumerator Effect(List<BattleChar> Targets)
        {
            Skill skill = Skill.TempSkill("S_YoumuF_6_1", this.BChar, this.BChar.MyTeam);
            skill.FreeUse = true;
            skill.PlusHit = true;

            Skill skill2 = Skill.TempSkill("S_YoumuF_6_2", this.BChar, this.BChar.MyTeam);
            skill2.FreeUse = true;
            skill2.PlusHit = true;

            Skill skill3 = Skill.TempSkill("S_YoumuF_6_3", this.BChar, this.BChar.MyTeam);
            skill3.FreeUse = true;

            foreach (Skill_Extended allExtended in this.MySkill.AllExtendeds)
            {
                foreach (string item in this.MySkill.MySkill.SkillExtended)
                {
                    if (item.Contains(allExtended.Name))
                    {
                        skill3.ExtendedAdd(item);
                    }
                }
            }

            if (Targets[0].HP >= 1)
            {
                this.BChar.ParticleOut(this.MySkill, skill, Targets[0]);
            }
            else if (BattleSystem.instance.AllyTeam.AliveChars.Any((BattleChar i) => i.HP > 0))
            {
                var validAllies = BattleSystem.instance.AllyTeam.AliveChars.Where(a => a.HP > 0).ToList();

                this.BChar.ParticleOut(this.MySkill, skill, RandomManager.Random<BattleChar>(validAllies, BattleRandom.GetRandomClass(this.BChar).Main));
            }

            yield return new WaitForSecondsRealtime(1f);
            
            for (int i = 0; i < 16; i++)
            {
                if (Targets[0].HP >= 1)
                {
                    this.BChar.ParticleOut(this.MySkill, skill2, Targets[0]);
                }
                else if (BattleSystem.instance.AllyTeam.AliveChars.Any((BattleChar m) => m.HP > 0))
                {
                    var validAllies = BattleSystem.instance.AllyTeam.AliveChars.Where(a => a.HP > 0).ToList();

                    this.BChar.ParticleOut(this.MySkill, skill2, RandomManager.Random<BattleChar>(validAllies, BattleRandom.GetRandomClass(this.BChar).Main));
                }
                yield return new WaitForSecondsRealtime(0.1f);
            }

            yield return new WaitForSecondsRealtime(0.5f);
            
            if (Targets[0].HP >= 1)
            {
                this.BChar.ParticleOut(this.MySkill, skill3, Targets[0]);
            }
            else if (BattleSystem.instance.AllyTeam.AliveChars.Any((BattleChar i) => i.HP > 0))
            {
                var validAllies = BattleSystem.instance.AllyTeam.AliveChars.Where(a => a.HP > 0).ToList();

                this.BChar.ParticleOut(this.MySkill, skill3, RandomManager.Random<BattleChar>(validAllies, BattleRandom.GetRandomClass(this.BChar).Main));
            }
            this.MySkill.MySkill.Effect_Target.DMG_Per = 1024;

            yield break;
        }
    }
}
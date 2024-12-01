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
namespace HakureiReimu
{
	/// <summary>
	/// 天月下「地上的大密室」
	/// <color=#FFD700>*「梦想天生」+秘术「天文密葬法」*</color>
	/// 随机对自身施加5种增益效果。
	/// 那之后，自身每有1种增益效果，进行1次追加攻击，造成&a(30%)伤害，并连锁治疗自己&a(30%)体力值。
	/// </summary>
    public class S_Musoutensei_Eirin: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("Musoutensei_Eirin", 1f, null, 0f, null, null, false, false);

            List<string> list = new List<string>();
            GDEDataManager.GetAllDataKeysBySchema(GDESchemaKeys.Buff, out list);
            int buffcount = 0;
            for (int i = 0; i < 200; i++)
            {
                GDEBuffData gdebuffData = new GDEBuffData(RandomManager.Random<string>(list, BattleRandom.GetRandomClass(this.BChar).Main));
                bool flag = !gdebuffData.Hide && !gdebuffData.Debuff && gdebuffData.LifeTime > 0;
                if (flag)
                {
                    this.BChar.BuffAdd(gdebuffData.Key, this.BChar, false, 120, false, -1, false);
                    buffcount++;
                    if (buffcount >= 5)
                    {
                        break;
                    }
                }
            }

            int count = CheckBuffNum();

            BattleSystem.DelayInput(this.Effect(Targets, count));
        }

        public int CheckBuffNum()
        {
            int count = 0;

            count = this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false).Count;

            return count;
        }

        public IEnumerator Effect(List<BattleChar> Target, int Count)
        {
            yield return new WaitForSeconds(0.15f);
            int num;
            for (int i = 0; i < Count; i = num + 1)
            {
                foreach (BattleChar bc in Target)
                {
                    if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
                    {
                        Skill skill = Skill.TempSkill("S_HakureiReimu_F_1_EX", this.BChar, this.BChar.MyTeam);
                        skill.MySkill.Effect_Target.DMG_Per = 30;
                        skill.PlusHit = true;
                        if (!bc.IsDead)
                        {
                            this.BChar.ParticleOut(this.MySkill, skill, bc);
                            this.BChar.Heal(this.BChar, (float)((int)this.BChar.GetStat.atk * 10f / 100f), this.BChar.GetCri(), false, new BattleChar.ChineHeal());
                        }
                    }
                }
                
                yield return new WaitForSeconds(0.1f);
                num = i;
            }
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3f)).ToString());
        }
    }
}
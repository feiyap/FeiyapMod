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
	/// 狂灵/绯色月
	/// 每次&user使用技能时，铃仙会对目标发动一次免费的<color=#B22222>幻象/乱弹</color>。
	/// </summary>
    public class B_Musoutensei_Reisen_0:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (SP.SkillData.Master == this.Usestate_F)
            {
                BattleChar battleChar2 = null;
                foreach (BattleChar battleChar3 in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (battleChar3.Info.KeyData == "Reisen")
                    {
                        battleChar2 = battleChar3;
                        break;
                    }
                }
                if (battleChar2.IsDead)
                {
                    return;
                }

                BattleSystem.DelayInputAfter(this.Ienum(this.BChar, battleChar2));
            }
        }

        public IEnumerator Ienum(BattleChar hit, BattleChar battleChar2)
        {
            Skill skill;
            if (battleChar2.BuffFind("B_Reisen_6"))
            {
                skill = Skill.TempSkill("S_Reisen_P_2", battleChar2, this.BChar.MyTeam);
            }
            else if (battleChar2.BuffFind("B_Reisen_P"))
            {
                skill = Skill.TempSkill("S_Reisen_P_1", battleChar2, this.BChar.MyTeam);
            }
            else
            {
                skill = Skill.TempSkill("S_Reisen_P_0", battleChar2, this.BChar.MyTeam);
            }

            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;

            if (hit.BuffFind("B_Reisen_2"))
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillStat.hit += 100f;
                skill.ExtendedAdd(skill_Extended);
            }
            if (hit.BuffFind("B_Reisen_2_0"))
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillStat.cri += 100f;
                skill.ExtendedAdd(skill_Extended);
            }

            yield return new WaitForSecondsRealtime(0.1f);

            battleChar2.ParticleOut(skill, hit);

            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", base.Usestate_F.Info.Name);
        }
    }
}
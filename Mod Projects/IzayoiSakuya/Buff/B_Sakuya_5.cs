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
	/// 时符「完美空间」
	/// </summary>
    public class B_Sakuya_5:Buff, IP_DamageTake
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg > 0 && !resist)
            {
                resist = true;
            }
            foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
            {
                if (castingSkill.Usestate == this.BChar && castingSkill.skill.MySkill.KeyID == "S_Sakuya_5")
                {
                    Skill skill2 = Skill.TempSkill("S_Sakuya_5_0", this.BChar, this.BChar.MyTeam);
                    skill2.isExcept = true;
                    skill2.FreeUse = true;
                    skill2.PlusHit = true;
                    BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
                    //BattleSystem.instance.ActWindow.CastingWaste(castingSkill.skill);
                    BattleSystem.instance.CastSkills.Remove(castingSkill);
                    BattleSystem.instance.SaveSkill.Remove(castingSkill);
                    base.SelfDestroy(false);
                    return;
                }
            }
            foreach (CastingSkill castingSkill2 in BattleSystem.instance.SaveSkill)
            {
                if (castingSkill2.Usestate == this.BChar && castingSkill2.skill.MySkill.KeyID == "S_Sakuya_5")
                {
                    Skill skill2 = Skill.TempSkill("S_Sakuya_5_0", this.BChar, this.BChar.MyTeam);
                    skill2.isExcept = true;
                    skill2.FreeUse = true;
                    skill2.PlusHit = true;
                    BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
                    //BattleSystem.instance.ActWindow.CastingWaste(castingSkill2.skill);
                    BattleSystem.instance.CastSkills.Remove(castingSkill2);
                    BattleSystem.instance.SaveSkill.Remove(castingSkill2);
                    base.SelfDestroy(false);
                    return;
                }
            }
            base.SelfDestroy(false);
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.MySkill.KeyID == "S_Sakuya_3")
            {
                base.SelfDestroy(false);
                this.BChar.BuffRemove("B_Sakuya_5", false);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.Usestate_L.IsDead)
            {
                base.SelfDestroy(false);
            }
        }
    }
}
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
	/// 幻在「钟表的残骸」
	/// 倒计时1后，再造成%a伤害。
	/// 月魔术 - 倒计时延长为3。倒计时期间，目标受到的伤害增加15%。
	/// </summary>
    public class S_Sakuya_3: SkillExtended_Sakuya
    {
        public bool flag2;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckLunaMagic())
            {
                flag2 = true;
            }
            else
            {
                flag2 = false;
            }
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (this.flag2)
            {
                Skill skill = Skill.TempSkill("S_Sakuya_3_1", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, hit, false, false, true, null));
                this.MySkill.MySkill.Name = ModManager.getModInfo("IzayoiSakuya").localizationInfo.SystemLocalizationUpdate(this.MySkill.MySkill.KeyID + "L");
            }
            else
            {
                Skill skill = Skill.TempSkill("S_Sakuya_3_0", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, hit, false, false, true, null));
                this.MySkill.MySkill.Name = ModManager.getModInfo("IzayoiSakuya").localizationInfo.SystemLocalizationUpdate(this.MySkill.MySkill.KeyID + "N");
            }
        }
        
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString()).Replace("%b", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString());
        }
    }
}
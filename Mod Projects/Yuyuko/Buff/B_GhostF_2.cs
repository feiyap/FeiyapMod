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
namespace Yuyuko
{
	/// <summary>
	/// 空观剑「六根清净斩」
	/// </summary>
    public class B_GhostF_2:Buff, IP_Hit, IP_Dodge
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 2f)).ToString());
        }
        
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                this.Counter(SP);
            }
        }
        
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            this.Counter(SP);
        }
        
        public void Counter(SkillParticle SP)
        {
            if (!SP.SkillData.PlusHit && SP.SkillData.CounterEnable && !SP.UseStatus.NullCheck())
            {
                CastingSkill castingSkill = new CastingSkill();
                castingSkill.skill = Skill.TempSkill("S_GhostF_2_0", this.BChar, this.BChar.MyTeam);
                castingSkill.Target = SP.UseStatus;
                castingSkill.Usestate = this.BChar;
                castingSkill.skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.EnemyCounterAttack(castingSkill));
            }
        }
        
        public IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.5f);
            yield break;
        }
    }
}
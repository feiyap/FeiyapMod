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
namespace Inaba
{
    /// <summary>
    /// 炸弹？！
    /// 回合结束时，造成超高额伤害(攻击力的200%)。攻击后将此减益转移至目标身上。被重复施加炸弹时，立即引爆上一个炸弹，并使新的炸弹伤害变为上一个炸弹的伤害的 2 倍。
    /// </summary>
    public class B_Inaba_P_5:Buff, IP_SkillUse_Target, IP_TurnEnd, IP_BuffAdd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.Master == this.BChar && DMG > 0)
            {
                this.SelfDestroy();
                hit.BuffAdd("B_Inaba_P_5", this.Usestate_F);
            }
        }

        public void TurnEnd()
        {
            BattleSystem.DelayInputAfter(this.EffectBomb());
            base.SelfDestroy(false);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", base.Usestate_L.Info.Name).Replace("&a", ((int)(base.Usestate_L.GetStat.atk * 2f)).ToString());
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar && BuffTaker.BuffFind("B_Inaba_P_5") && addedbuff.BuffData.Key == "B_Inaba_P_5")
            {
                BattleSystem.DelayInputAfter(this.EffectBomb());
            }
        }

        public IEnumerator EffectBomb()
        {
            yield return new WaitForSeconds(0.1f);

            Skill skill = Skill.TempSkill("S_Inaba_P_5_0", this.Usestate_F, this.Usestate_F.MyTeam);
            skill.PlusHit = true;
            skill.FreeUse = true;
            this.Usestate_F.ParticleOut(skill, skill, this.BChar);

            yield return null;
            yield break;
        }
    }
}
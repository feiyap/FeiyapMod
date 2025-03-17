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
namespace FFAce
{
    public class B_FFAce_Rare_1_0:Buff, IP_CriPerChange, IP_DamageChange_sumoperation
    {
        public override void Init()
        {
            base.Init();
        }
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!base.Usestate_L.BuffFind("B_FFAce_Rare_1", false))
            {
                base.SelfDestroy(false);
            }
        }

        public void CriPerChange(Skill skill, BattleChar Target, ref float CriPer)
        {
            if (skill.Master == this.BChar && (skill.MySkill.KeyID == "S_FFAce_0" || skill.MySkill.KeyID == "S_FFAce_0_Ex"))
            {
                CriPer += 25f;
            }
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            if (SkillD.Master == this.BChar && (SkillD.MySkill.KeyID == "S_FFAce_0" || SkillD.MySkill.KeyID == "S_FFAce_0_Ex") && Cri)
            {
                PlusDamage = (int)((float)Damage * 0.35f);
            }
        }

        public Buff Mainbuff;
    }
}
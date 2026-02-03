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
using BasicMethods;
namespace HiHouClab
{
	/// <summary>
	/// 哑光之境界
	/// </summary>
    public class B_Maribel_P:Buff, IP_QuantumDamageTake
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            foreach (CastingSkill cs in CustomMethods.GetCastingSkills(this.Usestate_F))
            {
                if (cs.TargetReturn().Contains(this.BChar))
                {
                    return;
                }
            }
            SelfDestroy();
        }

        public void QuantumDamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                this.BChar.BuffAdd("B_Maribel_Barrier", this.Usestate_F).BarrierHP += Dmg;
            }
        }
    }
}
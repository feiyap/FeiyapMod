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
namespace RemiliaScarlet
{
	/// <summary>
	/// 夜符「Bad Lady Scramble」
	/// 倒计时期间被击中的话，抵消该次伤害，并依据自身最大体力值，对所有敌人造成%a伤害。
	/// </summary>
    public class S_RemiliaScarlet_6:Skill_Extended, IP_DamageTake, IP_SkillCastingStart
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&b", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }

        // Token: 0x06000F97 RID: 3991 RVA: 0x0008B2FD File Offset: 0x000894FD
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target.Info.Ally)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.5f);
            }
        }

        // Token: 0x06000F98 RID: 3992 RVA: 0x0008B32F File Offset: 0x0008952F
        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
        }

        // Token: 0x06000F99 RID: 3993 RVA: 0x0008B340 File Offset: 0x00089540
        public void SkillCasting(CastingSkill ThisSkill)
        {
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                battleChar.BuffAdd(GDEItemKeys.Buff_B_Momori_8, this.BChar, false, 0, false, -1, false);
            }
        }
    }
}
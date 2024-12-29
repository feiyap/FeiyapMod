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
namespace HinanawiTenshi
{
	/// <summary>
	/// 比那名居天子
	/// Passive:
	/// 幼小的有顶天 - 当自己身上没有减益效果时，造成的伤害提升10%。
	/// 操纵大地程度的能力 - 队友被施加增益效果时，比那名居天子会获得1点<color=#97FFFF>气质</color>。
	/// 天人之姿 - 受到的伤害降低1点。
	/// <color=#97FFFF>天启X</color> - 比那名居天子身上拥有的<color=#97FFFF>气质</color>超过X点时，释放技能会消耗X点<color=#97FFFF>气质</color>，触发额外效果。
	/// </summary>
    public class P_HinanawiTenshi:Passive_Char, IP_DamageChange, IP_BattleStart_Ones, IP_BuffAdd, IP_DamageTakeChange_sumoperation, IP_BattleEnd, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count == 0)
            {
                return (int)(Damage * 1.1);
            }
            return Damage;
        }

        public void BattleStart(BattleSystem Ins)
        {
            this.BChar.BuffAdd("B_Tenshi_P", this.BChar);
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Tenshi_P());
                }

                BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi++;
            }
        }

        public void DamageTakeChange_sumoperation(BattleChar Hit, BattleChar User, int Dmg, bool Cri, ref int PlusDmg, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit == this.BChar)
            {
                PlusDmg = -1;
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Tenshi_P());
            }

            if (BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().list.Count >= 9)
            {
                Skill tmpSkill = Skill.TempSkill("S_Tenshi_Rare_4", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }

        public void BattleEnd()
        {
            this.BGMEnd();
        }

        public void BGMEnd()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);
        }
    }
}
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
namespace Mokou
{
	/// <summary>
	/// 不死鸟之尾
	/// 攻击力+2
	/// 最大生命值+20
	/// 闪避率-30%
	/// 受到的伤害-2
	/// 被攻击概率中幅增加
	/// 被击中时给予攻击者1层烧伤痛苦减益（100%）。如果装备者是藤原妹红，额外给予攻击者和自身1层烧伤痛苦减益（100%）。
	/// 根据装备角色的痛苦成功率增加概率。
	/// </summary>
    public class Mokou_Plume:EquipBase, IP_Hit, IP_Dodge, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 2f;
            this.PlusStat.maxhp = 10;
            this.PlusStat.dod = -30f;
            this.PlusStat.AggroPer = 66;
        }

        // Token: 0x060030FF RID: 12543 RVA: 0x0015565C File Offset: 0x0015385C
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (SP.SkillData.IsDamage && SP.UseStatus.Info.Ally != this.BChar.Info.Ally && !SP.SkillData.PlusHit)
            {
                SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, (int)(100f + this.BChar.GetStat.HIT_DOT), false, -1, false);
                if(this.BChar.Info.KeyData == "Mokou")
                {
                    SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, (int)(100f + this.BChar.GetStat.HIT_DOT), false, -1, false);
                    this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, (int)(100f + this.BChar.GetStat.HIT_DOT), false, -1, false);
                }
            }
        }

        // Token: 0x06003100 RID: 12544 RVA: 0x001556C4 File Offset: 0x001538C4
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar && SP.SkillData.IsDamage && SP.UseStatus.Info.Ally != this.BChar.Info.Ally && !SP.SkillData.PlusHit)
            {
                SP.UseStatus.BuffAdd("B_Mokou_T_1", SP.UseStatus, false, 0, false, -1, false);
                if (this.BChar.Info.KeyData == "Mokou")
                {
                    SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, (int)(100f + this.BChar.GetStat.HIT_DOT), false, -1, false);
                    this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, (int)(100f + this.BChar.GetStat.HIT_DOT), false, -1, false);
                }
            }
        }
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false,
          bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit == this.BChar && Dmg >= 2)
            {
                return Dmg - 2;
            }
            else
            {
                return 0;
            }
        }

        // Token: 0x06003101 RID: 12545 RVA: 0x00155737 File Offset: 0x00153937
        public IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.5f);
            yield break;
        }
    }
}
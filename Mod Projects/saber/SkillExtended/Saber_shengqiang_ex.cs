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
namespace saber
{
    public class Saber_shengqiang_ex:Skill_Extended,IP_DamageChange
    {
        // Token: 0x06000C11 RID: 3089 RVA: 0x0008010C File Offset: 0x0007E30C
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
        }
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (View)
            {
                return Damage;
            }
            if (Target is BattleEnemy && Target.Info.EnemyCate != GDEItemKeys.EnemyCategory_ECategory_TrialEnemy && this.MySkill.UsedApNum >= 0 && !this.MySkill.FreeUse && !this.MySkill.PlusHit)
            {
                if ((Target as BattleEnemy).Boss)
                {
                    if (40f >= Misc.NumToPer((float)Target.GetStat.maxhp, (float)Target.HP))
                    {
                        Target.HPToZero();
                        if (this.BChar.Info.KeyData == GDEItemKeys.Character_Ilya)
                        {
                            BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), this.BChar.Info.GetData.Text_Character[0], false));
                        }
                        return 0;
                    }
                }
                else if (100f >= Misc.NumToPer((float)Target.GetStat.maxhp, (float)Target.HP))
                {
                    Target.HPToZero();
                    if (this.BChar.Info.KeyData == GDEItemKeys.Character_Ilya)
                    {
                        BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), this.BChar.Info.GetData.Text_Character[0], false));
                    }
                    return 0;
                }
            }
            return Damage;
        }
        public override void Init()
        {
            base.Init();
        }

        // Token: 0x06000C0B RID: 3083 RVA: 0x0008001A File Offset: 0x0007E21A
        public override void HandInit()
        {
            base.HandInit();
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
        }
    }
}   
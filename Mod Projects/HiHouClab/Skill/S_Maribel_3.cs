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
    /// 卫星露天咖啡座
    /// 这个技能不会因为回合结束而被释放。
    /// 倒计时期间，目标每次受到伤害时（包括量子伤害），超额治疗 &a 体力值(治疗力的20%)。
    /// 这个技能从倒计时栏离开时，恢复所有目标的体力极限。
    /// </summary>
    public class S_Maribel_3 : Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit, IP_DamageTake, IP_QuantumDamageTake
    {
        bool isFlag = false;

        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
            isFlag = false;
        }
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (isFlag && Target == this.BChar)
            {
                int num = (int)(this.BChar.GetStat.reg * 0.2f);
                this.BChar.Heal(this.BChar, (float)num, false, true, null);
            }
        }

        public void QuantumDamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (isFlag && Target == this.BChar)
            {
                int num = (int)(this.BChar.GetStat.reg * 0.2f);
                this.BChar.Heal(this.BChar, (float)num, false, true, null);
            }
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            isFlag = true;
            CustomMethods.CountingSkillNotUseTurnEnd(ThisSkill);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            isFlag = false;
            foreach (BattleChar bc in ThisSkill.TargetReturn())
            {
                if (bc.HP < bc.Recovery)
                {
                    int num = bc.Recovery - bc.HP;
                    bc.Heal(this.BChar, (float)num, false, false, null);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.2)).ToString());
        }
    }
}
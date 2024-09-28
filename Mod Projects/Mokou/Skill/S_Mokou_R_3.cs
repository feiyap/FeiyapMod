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
using Spine;
namespace Mokou
{
	/// <summary>
	/// 不死「火鸟 -凤翼天翔-」
	/// 施加无法抵抗的眩晕，立即触发一层重生。
	/// </summary>
    public class S_Mokou_R_3:Skill_Extended, IP_DamageTake, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.UseNum = 0;
        }
        public override void FixedUpdate()
        {
            this.APChange = -this.UseNum;
        }
        public override bool Terms()
        {
            bool count = true;
            if (this.BChar.BuffFind("B_Mokou_0", false) == true && this.BChar.BuffReturn("B_Mokou_0", false).StackNum >= (this.BChar.Info.LV + 1) / 2)
            {
                count = false;
            }
            return count;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.UseNum = 0;
            MasterAudio.PlaySound("Mokou_R3_1", 1f, null, 0f, null, null, false, false);
            foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                battleChar.BuffAdd(GDEItemKeys.Buff_B_Common_Rest, this.BChar, false, 999, false, -1, false);
            }
            BattleSystem.DelayInput(this.Wait());
            EX_ability.MokouRebirth(this.BChar,false);
            base.SkillUseSingle(SkillD, Targets);
        }
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (SkillD.MySkill.KeyID == "S_Mokou_R_3")
            {
                Damage -= (int)((float)Damage * 0.75f);
                return Damage;
            }
            else
            {
                return Damage;
            }
        }
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false,
            bool NOEFFECT = false, BattleChar Target = null)
        {
            if(Dmg > 0 && Target == this.BChar)
            {
                this.UseNum++;
            }
        }
        public int UseNum;
        public IEnumerator Wait()
        {
            yield return new WaitForSeconds(2f);
            yield break;
        }
    }
}
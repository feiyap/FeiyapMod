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
namespace HakureiReimu
{
	/// <summary>
	/// 赤色杀人魔！
	/// </summary>
    public class B_Musoutensei_Daiyousei_2:Buff
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Musoutensei_Daiyousei_0");
        }

        public void SkillUseAfter(Skill SkillD)
        {
            if (SkillD.IsDamage)
            {
                BattleSystem.DelayInputAfter(this.Del());
            }
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();
            base.SelfDestroy(false);
            yield break;
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.IsDamage && AddedSkill.ExtendedFind_DataName("SE_Musoutensei_Daiyousei_0") == null;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (10 * base.StackNum).ToString());
        }
    }
}
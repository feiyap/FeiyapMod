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
namespace Phrolova
{
	/// <summary>
	/// 重世
	/// 强化自己的下 1 个技能，使其造成的伤害增加&a%<color=#FF7A33>(&user攻击力的100%)</color>。
	/// </summary>
    public class B_Phrolova_2:Buff
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Phrolova_2");
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.IsDamage && AddedSkill.ExtendedFind<SE_Phrolova_2>() == null;
        }

        public override string DescExtended()
        {
            string username = "";
            if (BattleSystem.instance != null)
            {
                username = this.BChar.Info.Name;
            }

            return this.BuffData.Description.Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 2f)).ToString())
                                            .Replace("&user", username);
        }
    }
}
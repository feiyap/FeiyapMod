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
namespace KirisameMarisa
{
	/// <summary>
	/// 危险改装
	/// 下一个“指向敌人”的技能获得“转变为指向所有敌人；且若目标只有一个，以暴击形式命中”的效果。
	/// </summary>
    public class B_KirisameMarisa_8:Buff
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_KirisameMarisa_8");
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.IsDamage && AddedSkill.TargetTypeKey == GDEItemKeys.s_targettype_enemy && AddedSkill.ExtendedFind_DataName("SE_KirisameMarisa_8") == null;
        }
    }
}
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
	/// 费用-1，使目标获得随机天气增益。
	/// 指向队友
	/// </summary>
    public class SE_Tenshi_C_0: SkillBase_Tenshi
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_otherally);
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.APChange = 1;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            AddTenki(Targets[0], 1);
        }
    }
}
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
	/// 费用+1，同时治疗所有队友。
	/// 指向单体的治疗技能
	/// </summary>
    public class SE_KirisameMarisa_C_1:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsHeal && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_self 
                || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_otherally);
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

            if (SkillD.Master.Info.Ally && !SkillD.FreeUse && !SkillD.PlusHit && !SkillD.ForceAction && !SkillD.BasicSkill)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (battleChar != Targets[0])
                    {
                        Targets.Add(battleChar);
                    }
                }
            }
        }
    }
}
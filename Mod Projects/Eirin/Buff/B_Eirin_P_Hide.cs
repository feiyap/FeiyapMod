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
namespace Eirin
{
	/// <summary>
	/// 无缺/月人
	/// </summary>
    public class B_Eirin_P_Hide:Buff, IP_Draw
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.maxhp = 10;
            this.PlusStat.atk = 5;
            this.PlusStat.reg = 5;
            this.PlusStat.DeadImmune = 20;

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.Master == this.BChar && skill.IsHeal && !skill.IsDamage && skill.ExtendedFind_DataName("SE_Eirin_P_Hide") == null && skill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
                {
                    skill.ExtendedAdd_Battle(Skill_Extended.DataToExtended("SE_Eirin_P_Hide"));
                }
            }
        }

        public IEnumerator Draw(Skill Drawskill, bool NotDraw)
        {
            if (BattleSystem.instance != null && this.BChar != null)
            {
                using (List<Skill>.Enumerator enumerator = this.BChar.MyTeam.Skills.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Skill skill = enumerator.Current;
                        if (skill.Master == this.BChar && skill.IsHeal && !skill.IsDamage && skill.ExtendedFind_DataName("SE_Eirin_P_Hide") == null && skill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
                        {
                            skill.ExtendedAdd_Battle(Skill_Extended.DataToExtended("SE_Eirin_P_Hide"));
                        }
                    }
                    yield break;
                }
            }
            yield break;
        }
    }
}
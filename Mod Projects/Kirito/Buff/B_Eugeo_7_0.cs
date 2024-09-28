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
namespace Kirito
{
    /// <summary>
    /// 切换
    /// </summary>
    public class B_Eugeo_7_0 : Buff, IP_Hit, IP_Dodge
    {
        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                List<Skill> list = new List<Skill>();
                foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
                {
                    if (skill.Master == this.BChar && skill.IsDamage)
                    {
                        list.Add(skill);
                    }
                }
                Skill skill2 = list.Random(this.BChar.GetRandomClass().Main);
                skill2.FreeUse = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, 
                    BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main), true, true, false, null));
            }
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1 && !SP.UseStatus.Info.Ally)
            {
                List<Skill> list = new List<Skill>();
                foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
                {
                    if (skill.Master == this.BChar && skill.IsDamage)
                    {
                        list.Add(skill);
                    }
                }
                Skill skill2 = list.Random(this.BChar.GetRandomClass().Main);
                skill2.FreeUse = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2,
                    BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main), true, true, false, null));
            }
        }
    }
}
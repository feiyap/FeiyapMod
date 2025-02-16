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
namespace Yuyuko
{
	/// <summary>
	/// 半灵
	/// </summary>
    public class Boss_Ghost:AI
    {
        public override List<BattleChar> TargetSelect(Skill SelectedSkill)
        {
            if (SelectedSkill.MySkill.KeyID == "S_GhostF_0")
            {
                List<BattleChar> list = new List<BattleChar>();
                BattleChar temp = new BattleChar();
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    if (bc.BuffFind("B_YoumuF_1"))
                    {
                        temp = bc;
                        break;
                    }
                }
                list.Add(temp);
                return list;
            }
            return base.TargetSelect(SelectedSkill);
        }
    }
}
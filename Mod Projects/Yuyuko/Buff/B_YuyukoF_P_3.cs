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
    /// <color=#8B008B>永眠</color>
    /// /// 当前返魂值为：&a
    /// </summary>
    public class B_YuyukoF_P_3:Buff, IP_Awake, IP_Draw
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.def = 50;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().fanhun).ToString());
        }

        public void Awake()
        {
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.Master == this.BChar)
                {
                    skill.ExtendedAdd(new Ex_LucyD_21());
                }
            }
        }
        
        public IEnumerator Draw(Skill Drawskill, bool NotDraw)
        {
            yield return new WaitForFixedUpdate();
            if (Drawskill.Master == this.BChar)
            {
                Drawskill.ExtendedAdd(new Ex_LucyD_21());
            }
            yield break;
        }
    }
}
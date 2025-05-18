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
namespace VillageAlice
{
	/// <summary>
	/// 处于梦境……
	/// 除了&user以外，无法使用手中的技能。
	/// </summary>
    public class B_FVAlice_Rare_2_1:Buff, IP_PlayerTurn, IP_Awake, IP_Draw
    {
        public void Awake()
        {
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.Master != this.BChar || skill.Master.IsLucyNoC)
                {
                    skill.ExtendedAdd(new Ex_LucyD_21());
                }
            }
        }

        public IEnumerator Draw(Skill Drawskill, bool NotDraw)
        {
            yield return new WaitForFixedUpdate();
            if (Drawskill.Master != this.BChar || Drawskill.Master.IsLucyNoC)
            {
                Drawskill.ExtendedAdd(new Ex_LucyD_21());
            }
            yield break;
        }

        public override void Init()
        {
            base.Init();
            this.NoShowTimeNum_Tooltip = true;
            this.OnePassive = true;
        }

        public void Turn()
        {
            base.SelfDestroy(false);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}
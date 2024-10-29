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
namespace MinamiRio
{
	/// <summary>
	/// 莉央
	/// Passive:
	/// <b>锚点</b> - 莉央无法造成暴击，但是升级时获得远超常人的命中率提升。莉央超过100%的那部分命中率转化为50%的<color=#FA8072>穿甲</color>。
	/// <b><color=#FA8072>穿甲</color></b> - 莉央攻击时视作目标减少等量于<color=#FA8072>穿甲</color>的防御力。
	/// <b><color=#FFD700>单弓</color></b> - 莉央在<color=#FFD700>单弓</color>形态下手中的攻击技能获得无视嘲讽；且部分技能会触发额外效果。
	/// <b><color=#F0FFFF>和弓</color></b> - 莉央在<color=#F0FFFF>和弓</color>形态下增加20%命中率；且部分技能会触发额外效果。
	/// </summary>
    public class P_MinamiRio:Passive_Char, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance.GetBattleValue<BV_MinamiRio_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_MinamiRio_P());
                return;
            }

            BattleSystem.instance.GetBattleValue<BV_MinamiRio_P>().ArmorPiercing = (int)((this.BChar.GetStat.hit - 100) / 2);
        }

        public void Turn()
        {
            if (!this.BChar.BuffFind("B_MinamiRio_P1") && !this.BChar.BuffFind("B_MinamiRio_P1"))
            {
                this.BChar.BuffAdd("B_MinamiRio_P1", this.BChar);
            }
        }

        public static Stat StatChange(Stat Original)
        {
            Stat result = Original;
            bool needChange = P_MinamiRio.NeedChange;
            if (needChange)
            {
                float num = 0;
                foreach (BattleChar bc in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (bc.Info.KeyData == "MinamiRio")
                    {
                        num = BattleSystem.instance.GetBattleValue<BV_MinamiRio_P>().ArmorPiercing;
                        break;
                    }
                }
                if (num > 0)
                {
                    result.def -= num;
                }
            }
            return result;
        }
        
        public static void SetNeedChange_Skill(Skill skill)
        {
            P_MinamiRio.SetNeedChange(skill.Master);
        }
        
        public static void SetNeedChange(BattleChar c)
        {
            bool flag = c.Info.Ally && c.Info.KeyData == "MinamiRio";
            if (flag)
            {
                P_MinamiRio.NeedChange = true;
            }
            else
            {
                P_MinamiRio.NeedChange = false;
            }
        }
        
        public static void ResetNeedChange()
        {
            P_MinamiRio.NeedChange = false;
        }
        
        public static bool NeedChange;
    }
}
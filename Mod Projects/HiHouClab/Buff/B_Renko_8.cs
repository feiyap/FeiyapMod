using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace HiHouClab
{
    /// <summary>
    /// 登天吞云
    /// </summary>
    public class B_Renko_8 : Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            Debug.Log("DamageTakeChange");
            Debug.Log(Dmg);
            if (Hit == this.BChar)
            {
                foreach (IP_DamageTakeChange_Renko8 ip_renko8 in this.Usestate_F.IReturn<IP_DamageTakeChange_Renko8>())
                {
                    if (ip_renko8 != null)
                    {
                        ip_renko8.DamageTakeChange_Renko8(Hit, User, Dmg, Cri, NODEF, NOEFFECT, Preview);
                    }
                }

                return 0;
            }

            return Dmg;
        }
    }

    public interface IP_DamageTakeChange_Renko8
    {
        void DamageTakeChange_Renko8(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false);
    }
}
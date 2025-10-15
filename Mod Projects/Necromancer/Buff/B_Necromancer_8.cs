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
namespace Necromancer
{
	/// <summary>
	/// 生命崩解
	/// 回合开始时，每层生命崩解，将使每回合伤害增加20%。
	/// </summary>
    public class B_Necromancer_8:Buff, IP_DamageTake
    {
        private float disintegration = 0;
        //private float totalTick = 0;
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void TurnUpdate()
        {
            base.TurnUpdate();
            BChar.BuffAdd("B_Necromancer_8", BChar);
        }
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((Usestate_F.GetStat.atk * .1f * StackNum * StackNum * .1f)).ToString()).Replace("&b", (((Usestate_F.GetStat.atk * .1f) + disintegration + StackNum * .1f * Usestate_F.GetStat.atk * .1f * StackNum + 4)).ToString()).Replace("&c" , "" + (StackNum * (int)(((Usestate_F.GetStat.atk * .1f) + disintegration + StackNum * .1f * Usestate_F.GetStat.atk * .1f * StackNum + 4))));
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg <= 0 || Cri == false || NODEF == true)
            {
                return;
            }
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar.Info.KeyData == "Necromancer")
                {
                    if (battleChar.BuffFind("B_Necromancer_4"))
                    {
                        int nowstack = StackNum;
                        for (int i = 0; i < nowstack; i++)
                        {
                            BChar.BuffAdd("B_Necromancer_8", BChar);
                        }
                    }
                }
            }
            
        }
        /*
        public void OldAction()
        {
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (battleChar.Info.KeyData == "Necromancer")
                {
                    if (battleChar.BuffFind("B_Necromancer_4"))
                    {
                        if (!(battleChar.BuffReturn("B_Necromancer_4") as B_Necromancer_4).StackReduciton(1))
                        {
                            return;
                        }
                    }
                }
            }
            AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Ilya_SnowFlakeEffect).Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();
            disintegration += StackNum * .1f * Usestate_F.GetStat.atk * .1f * StackNum;
            this.PlusDamageTick = (int)(disintegration + Usestate_F.GetStat.atk * .1f * StackNum - (int)(Usestate_F.GetStat.atk * StackNum * .1f));
        }
        */
    }
}
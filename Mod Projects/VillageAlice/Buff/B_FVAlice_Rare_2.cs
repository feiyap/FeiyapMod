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
	/// 梦境弄臣
	/// 回合结束后，额外进行一次梦境回合。
	/// </summary>
    public class B_FVAlice_Rare_2:Buff, IP_PlayerTurn
    {
        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            //var filter = UIManager.inst.UIcamera.gameObject.GetComponent<RuntimePinkFilter>();
            //UnityEngine.Object.Destroy(filter as UnityEngine.Object);
        }

        public void Turn()
        {
            foreach (BattleChar ba in BattleSystem.instance.AllyList)
            {
                if (ba != this.Usestate_F)
                {
                    ba.BuffAdd("B_FVAlice_Rare_2_1", this.Usestate_F);
                }
            }
            this.SelfStackDestroy();
        }
    }
}
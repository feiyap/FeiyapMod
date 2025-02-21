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
	/// 罐装幽灵
	/// 敌人出现时，失去10%最大体力值。
	/// </summary>
    public class R_YuyukoF_0:PassiveItemBase, IP_EnemyAwake
    {
        public void EnemyAwake(BattleChar Enemy)
        {
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(Enemy, Enemy.Info.OriginStat.maxhp * 10 / 100, Enemy);
        }
    }
}
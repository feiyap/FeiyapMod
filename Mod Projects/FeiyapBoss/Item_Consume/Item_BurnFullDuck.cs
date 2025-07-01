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
namespace FeiyapBoss
{
	/// <summary>
	/// 烤全鸭
	/// 恢复友军100%的体力值，同时解除无法战斗状态。
	/// </summary>
    public class Item_BurnFullDuck:UseitemBase
    {
        public override bool Use(Character CharInfo)
        {
            MasterAudio.PlaySound("Food Eat 02", 1f, null, 0f, null, null, false, false);
            this.PassiveEffect(CharInfo);
            this.Effect(CharInfo);

            return true;
        }

        public override void Effect(Character CharInfo)
        {
            base.Effect(CharInfo);
            if (CharInfo.Incapacitated)
            {
                CharInfo.Incapacitated = false;
                CharInfo.Hp = 0;
            }

            CharInfo.HealHP((int)Misc.PerToNum((float)CharInfo.get_stat.maxhp, 100f), true);
        }
    }
}
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
namespace RemiliaScarlet
{
    /// <summary>
    /// 蕾米莉亚
    /// Passive:
    /// 蕾米莉亚能够操纵命运，增加所有队友10%暴击率、命中率、闪避率。
    /// 此外，每个敌人阵亡时，增加蕾米莉亚1点永久最大体力值。最多增加当前等级x5点。
    /// </summary>
    public class P_RemiliaScarlet:Passive_Char, IP_BattleStart_Ones, IP_SomeOneDead, IP_LevelUp
    {
        int hp_change;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            hp_change = 0;
        }

        public void BattleStart(BattleSystem Ins)
        {
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                BattleSystem.instance.AllyList[i].BuffAdd("B_RemiliaScarlet_P", this.BChar, true, 0, false, -1, false);
            }
        }

        public void SomeOneDead(BattleChar DeadChar)
        {
            if (hp_change < this.BChar.Info.LV * 5)
            {
                this.BChar.Info.OriginStat.maxhp += 1;
                hp_change++;
            }
        }

        public void LevelUp()
        {
            if (hp_change == 0 && this.BChar.Info == PlayData.TSavedata.Party[3])
            {
                this.BChar.Info.OriginStat.maxhp += 10;
                hp_change += 10;
            }
        }
    }
}
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
namespace Mokou
{
	/// <summary>
	/// 难题「龙颈之玉　-五色的弹丸-」
	/// 每回合结束时，如果至少一半的角色没有体力极限（向上取整），恢复所有友方5点体力值；反之，下一回合开始时辉夜恢复所有生命值。
	/// </summary>
    public class S_Kaguya_1_S:Skill_Extended, IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override bool Terms()
        {
            return false;
        }
        public void TurnEnd()
        {
            count1 = 0;
            count2 = 0;
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                count1 += 1;
                if (battleAlly.Info.Hp == battleAlly.Recovery)
                {
                    count2 += 1;
                }
            }
            if (count2 >= (count1 + 1)/2)
            {
                foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
                {
                    battleAlly.Heal(battleAlly, 5, false, false, null);
                }
                foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
                {
                    if (battleChar.Info.KeyData == "Kaguya")
                    {
                        battleChar.BuffAdd("B_Kaguya_Achieve", this.BChar, false, 0, false, -1, false);
                    }
                }
            }
            else
            {
                foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
                {
                    if (battleChar.Info.KeyData == "Kaguya")
                    {
                        battleChar.BuffAdd("B_Kaguya_Fail", this.BChar, false, 0, false, -1, false);
                        battleChar.Heal(battleChar, (float)((double)battleChar.Info.get_stat.maxhp * 0.1), false, true, null);
                    }
                }
            }
        }
        public int count1 = 0;
        public int count2 = 0;
    }
}
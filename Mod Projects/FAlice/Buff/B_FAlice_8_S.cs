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
using BasicMethods;

namespace FAlice
{
    /// <summary>
    /// 绊线
    /// 使下一个行动的敌人取消行动并眩晕。
    /// </summary>
    public class B_FAlice_8_S : Buff, IP_EnemyActionBefore
    {
        public IEnumerator EnemyActionBefore(BattleEnemy ActionEnemy, Skill EnemyUseSkill, bool IsDelayWait)
        {
            ActionEnemy.BuffAdd(ModItemKeys.Buff_B_FAlice_8_Hidden, this.BChar);
            this.SelfDestroy();
            yield break;
        }
    }
}
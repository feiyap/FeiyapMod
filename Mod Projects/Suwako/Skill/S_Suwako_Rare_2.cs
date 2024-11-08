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
namespace Suwako
{
    /// <summary>
    /// 蛙休「总是能够冬眠」
    /// 释放时如果场上没有[风雨已至]，使随机敌人获得1层[风雨已至]。
    /// </summary>
    public class S_Suwako_Rare_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            bool isExist = false;

            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                if (be.BuffFind("B_Suwako_Dot"))
                {
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
            {
                BattleEnemy be = BattleSystem.instance.EnemyList.Random(BChar.GetRandomClass().Main);
                be.BuffAdd("B_Suwako_Dot", this.BChar);
            }
        }
    }
}
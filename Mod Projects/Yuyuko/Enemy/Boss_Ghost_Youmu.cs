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
	/// 魂魄妖梦·半灵
	/// </summary>
    public class Boss_Ghost_Youmu:AI
    {
        public override Skill SkillSelect(int ActionCount)
        {
            System.Random random = new System.Random();
            int randomValue = random.Next(0, 100);

            // 根据随机数的范围映射到目标值
            if (randomValue < 30)
            {
                return this.BChar.Skills[0]; // 30%概率
            }
            else if (randomValue < 60)
            {
                return this.BChar.Skills[1]; // 30%概率
            }
            else if (randomValue < 90)
            {
                return this.BChar.Skills[2]; // 30%概率
            }
            else if (randomValue < 95)
            {
                return this.BChar.Skills[3]; // 5%概率
            }
            else
            {
                return this.BChar.Skills[4]; // 5%概率
            }
        }
    }
}
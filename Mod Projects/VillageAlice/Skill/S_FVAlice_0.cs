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
	/// 梦境信件
	/// 处于[梦境]时，再次释放一次此技能。
	/// 【童话】：手牌中随机一个调查队员的技能被【童话】化。
	/// </summary>
    public class S_FVAlice_0:Skill_Extended
    {
        public override void FixedUpdate()
        {
            if (!this.flag && BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Find((Skill a) => a == this.MySkill) != null)
            {
                this.flag = true;
                UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), this.MySkill.MyButton.transform);
            }
        }

        public bool flag;
    }
}
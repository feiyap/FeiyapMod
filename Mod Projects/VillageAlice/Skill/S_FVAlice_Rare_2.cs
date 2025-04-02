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
	/// 梦境留言
	/// 释放技能后，此回合无法进入梦境，技能目标无法被选中。
	/// 回合结束后，额外进行一次梦境回合。
	/// 进入梦境回合时，手中&user外所有其他所有友军技能无法使用。
	/// 梦境回合结束时，若技能目标被击杀，则再额外进行一次梦境回合，随机选取一名目标成为梦境留言的目标。
	/// 梦境回合所有敌人无行动。
	/// </summary>
    public class S_FVAlice_Rare_2:Skill_Extended
    {

    }
}
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
namespace KirisameMarisa
{
	/// <summary>
	/// 危险扳机
	/// 使一个角色攻击力+3，防御力-15%。
	/// 对雾雨魔理沙使用时，使她在本次轮回中<color=#00BFFF>危险等级</color>上限+1。
	/// </summary>
    public class Item_KirisameMarisa_DangerTrigger:UseitemBase
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
            CharInfo.Buff_FieldAdd("B_KirisameMarisa_DangerTrigger");
        }
    }
}
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
	/// 辉夜的五难题
	/// 当前难题：&a
	/// 当前阶段完成难题次数：&b
	/// 当前阶段未完成难题次数：&c
	/// 辉夜改变阶段时，如果完成次数大于未完成次数，全体友方获得提升5%攻击力与治疗力的增益；反之，辉夜获得提升10%攻击力与治疗力的增益。
	/// </summary>
    public class B_Kaguya_P_1:Buff, IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override string DescExtended()
        {
            string text = base.DescExtended();
            switch (this.StackNum)
            {
                case 1:
                    text = text.Replace("&a", "难题「龙颈之玉　-五色的弹丸-」").Replace("&b", "" + Kaguya_Achieve).Replace("&c", "" + Kaguya_Fail);
                    break;
                case 2:
                    text = text.Replace("&a", "难题「佛御石之钵　-不碎的意志-」").Replace("&b", "" + Kaguya_Achieve).Replace("&c", "" + Kaguya_Fail);
                    break;
                case 3:
                    text = text.Replace("&a", "难题「火鼠的皮衣　-不焦躁的内心-」").Replace("&b", "" + Kaguya_Achieve).Replace("&c", "" + Kaguya_Fail);
                    break;
                case 4:
                    text = text.Replace("&a", "难题「燕的子安贝　-永命线-」").Replace("&b", "" + Kaguya_Achieve).Replace("&c", "" + Kaguya_Fail);
                    break;
                case 5:
                    text = text.Replace("&a", "难题「蓬莱的弹枝　-七色的弹幕-」").Replace("&b", "" + Kaguya_Achieve).Replace("&c", "" + Kaguya_Fail);
                    break;
            }
            return text;
        }
        public void TurnEnd()
        {
            if (this.BChar.BuffFind("B_Kaguya_Achieve"))
            {
                Kaguya_Achieve = this.BChar.BuffReturn("B_Kaguya_Achieve", false).StackNum;
            }
            else
            {
                Kaguya_Achieve = 0;
            }
            if (this.BChar.BuffFind("B_Kaguya_Fail"))
            {
                Kaguya_Fail = this.BChar.BuffReturn("B_Kaguya_Fail", false).StackNum;
            }
            else
            {
                Kaguya_Fail = 0;
            }
        }
        public int Kaguya_Achieve = 0;
        public int Kaguya_Fail = 0;
    }
}
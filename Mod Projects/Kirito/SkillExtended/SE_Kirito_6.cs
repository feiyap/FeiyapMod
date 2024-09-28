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
namespace Kirito
{
	/// <summary>
	/// 剩余使用次数
	/// 剩余 &a 次
	/// </summary>
    public class SE_Kirito_6:Skill_Extended
    {
        public override string ExtendedDes()
        {
            return base.ExtendedDes().Replace("&a", this.UseNum.ToString());
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc);
        }

        public override void Init()
        {
            base.Init();
            this.UseNum = 2;
        }

        public override void SkillUseHandBefore()
        {
            this.UseNum--;
            base.SkillUseHandBefore();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.BuffIconStackNum = this.UseNum;
            if (this.UseNum == 1)
            {
                this.MySkill.Disposable = true;
            }
        }

        public int UseNum;
    }
}
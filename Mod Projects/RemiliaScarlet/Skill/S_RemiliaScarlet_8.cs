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
	/// 诅咒「弗拉德·特佩斯的诅咒」
	/// 仅在自身拥有[吸血鬼之心]增益的时候才可使用。
	/// 消耗1层[吸血鬼之心]增益，超额治疗&a(自身20%最大体力值)的体力。
	/// </summary>
    public class S_RemiliaScarlet_8:Skill_Extended
    {
        public int Heal
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.2));
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            this.Flag = false;
            if (this.BChar.BuffFind("B_RemiliaScarlet_5", false))
            {
                this.Flag = true;
            }
        }

        public override bool Terms()
        {
            return this.Flag;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.BuffFind("B_RemiliaScarlet_5", false))
            {
                this.BChar.BuffReturn("B_RemiliaScarlet_5", false).SelfStackDestroy();
                Targets[0].Heal(this.BChar, (float)((int)((float)Heal * 1.0f)), this.BChar.GetCri(), true, null);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.Heal).ToString());
        }

        public bool Flag;
    }
}
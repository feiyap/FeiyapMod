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
namespace Necromancer
{
	/// <summary>
	/// 广域生命剥夺
	/// 对自身造成（生命上限50%）点痛苦伤害。
	/// 若只有一名目标，则额外施加一层生命崩解。
	/// </summary>
    public class S_Necromancer_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
            if (BChar.BuffFind("B_Necromancer_4"))
            {
                (BChar.BuffReturn("B_Necromancer_4") as B_Necromancer_4).StackReduciton(2);
            }
            foreach (BattleChar BattleChar in Targets)
            {
                if (!BattleChar.BuffFind("B_Necromancer_8"))
                {
                    BattleChar.BuffAdd("B_Necromancer_8", BChar);
                }
            }
            if (Targets.Count == 1)
            {
                BChar.BuffAdd("B_Necromancer_4", BChar);
                BChar.BuffAdd("B_Necromancer_4", BChar);
                BChar.BuffAdd("B_Necromancer_4", BChar);
            }
            else
            {
                //BChar.Damage(BChar, (int)(BChar.GetStat.maxhp * .5f), false, true);
            }
		}
        /*
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(BChar.GetStat.maxhp * .5f)).ToString());
        }
        */
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BChar.BuffFind("B_Necromancer_4") && BChar.BuffReturn("B_Necromancer_4").StackNum >= 2)
            {
                this.Flag = true;
            }
            else
            {
                this.Flag = false;
            }
        }
        public override bool Terms()
        {
            return this.Flag;
        }
        public bool Flag;
    }
}
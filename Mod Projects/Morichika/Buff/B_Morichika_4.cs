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
namespace Morichika
{
	/// <summary>
	/// 受骗
	/// 攻击改为指向随机其他怪物。
	/// </summary>
    public class B_Morichika_4:Buff, IP_SkillUse_User
    {
        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            Targets.Clear();
            List<BattleChar> list = new List<BattleChar>();
            list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars);
            list.Remove(this.BChar);

            Targets.Add(list.Random(this.BChar.GetRandomClass().Main));
            this.SelfDestroy();
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
        }
    }
}
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
namespace Phrolova
{
	/// <summary>
	/// 重世
	/// 下 1 个技能造成的伤害增加&a%<color=#FF7A33>(&user攻击力的100%)</color>。
	/// </summary>
    public class SE_Phrolova_2: BuffSkillExHand
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillPerFinal.Damage = (int)(this.BChar.GetStat.atk * 2f);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (SkillD.IsDamage)
            {
                BattleSystem.DelayInputAfter(this.Del());
            }
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();
            this.MainBuff.SelfDestroy(false);
            yield break;
        }

        public override string ExtendedDes()
        {
            return base.ExtendedDes().Replace("&a", ((int)(this.BChar.GetStat.atk * 2f)).ToString()).Replace("&user", (this.BChar.Info.Name).ToString());
        }
    }
}
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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 洩矢诹访子
	/// Passive:
	/// </summary>
    public class P_Suwako:Passive_Char,IP_TurnEnd, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_Deck)
            {
                if (skill.CharinfoSkilldata == this.BChar.Info.SkillDatas[0])
                {
                    skill.ExtendedAdd(Skill_Extended.DataToExtended("SkillEn_BattleStartDraw"));
                }
            }
        }

        public void TurnEnd()
        {
            BattleSystem.instance.StartCoroutine(this.EffectDelaysCo());
        }

        private IEnumerator EffectDelaysCo()
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(this.BChar.MyTeam.Skills);
            if (list.Count >= 1)
            {
                yield return CustomMethods.I_SkillBackToDeck(list[0], 0, true);
            }

            while (BattleSystem.instance.ListWait || BattleSystem.instance.Particles.Count != 0 || GameObject.FindGameObjectsWithTag("EffectView").Length != 0 || GameObject.FindGameObjectsWithTag("Tutorial").Length != 0 || BattleSystem.instance.DelayWait)
            {
                yield return new WaitForFixedUpdate();
            }
            
            yield return this.BChar.MyTeam._Draw();
        }
    }
}
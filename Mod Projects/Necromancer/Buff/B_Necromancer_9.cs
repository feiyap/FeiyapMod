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
    public class B_Necromancer_9:Buff
    {
        float saveatk;
        float saveb = .95f;
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            saveatk = (2f * (this.BChar.Info.LV - 1) + 20);
            this.PlusStat.atk = saveatk * -saveb;
        }
        public void EnterFroge()
        {
            saveb = Mathf.Max(0, saveb  -.05f);
            this.PlusStat.atk = saveatk * -saveb;
            if (BChar.HP > 0)
            {
                BattleSystem.DelayInputAfter(this.Draw());
            }
            else
            {
                saveb = Mathf.Max(0, saveb - .05f);
            }
        }
        public IEnumerator Draw()
        {
            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => skill.Master == BChar);
            if (skill2 == null)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
            else
            {
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
            }
            yield return null;
            yield break;
        }
    }
}
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
namespace SatsukiRin
{
	/// <summary>
	/// 冴月麟
	/// Passive:
	/// </summary>
    public class P_SatsukiRin:Passive_Char, IP_BattleStart_Ones, IP_DamageTake, IP_BattleEnd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            int num = 17 + this.BChar.Info.LV * 3;
            for (int i = 0;i<num;i++)
            {
                this.BChar.BuffAdd("B_Satsuki_P", this.BChar, false, 0, false, -1, false);
            }
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (this.BChar.Info.Hp - Dmg <= 0)  
            {
                if (this.BChar.BuffFind("B_Satsuki_P", false) && this.BChar.BuffReturn("B_Satsuki_P", false).StackNum >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        this.BChar.BuffReturn("B_Satsuki_P", false).SelfStackDestroy();
                    }

                    BattleSystem.DelayInput(Revive(Dmg));
                }
            }
        }

        public IEnumerator Revive(int Dmg)
        {
            yield return new WaitForSecondsRealtime(0.2f);

            this.BChar.Heal(this.BChar, (float)(Mathf.Abs(this.BChar.HP) + Dmg + this.BChar.GetStat.maxhp), false, true, null);

            BattleTeam.DrawInput a = null;

            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => (skill.IsHeal && skill.Master == this.BChar));
            if (skill2 == null)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
            else
            {
                BattleSystem.instance.AllyTeam.ForceDraw(skill2, a);
            }

            yield return new WaitForFixedUpdate();
            yield break;
        }

        public void BattleEnd()
        {
            this.BGMEnd();
        }

        public void BGMEnd()
        {
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);
        }
    }
}
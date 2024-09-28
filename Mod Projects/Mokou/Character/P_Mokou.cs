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
using static System.Net.Mime.MediaTypeNames;
namespace Mokou
{
	/// <summary>
	/// 藤原妹红
	/// Passive:
	/// 每次体力低于0受到致命伤害时,无效此伤害,清除自身所有DEBUFF并提升全属性,然后恢复全部生命值,一场战斗最多生效等级除以2（向上取整）的次数.
	/// </summary>
    public class P_Mokou:Passive_Char, IP_BattleStart_Ones, IP_DamageTake, IP_Hit, IP_Dead
    {
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg > 0)
            {
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
        }
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void FixedUpdate()
        {
            if (this.BChar.BuffFind("B_Mokou_0", false) == true)
            {
                this.Mokou_Rebirth = this.BChar.BuffReturn("B_Mokou_0", false).StackNum;
            }
            else
            {
                this.Mokou_Rebirth = 0;
            }
        }
        public void BattleStart(BattleSystem Ins)
        {
            this.Mokou_Rebirth = 0;
            this.Mokou_Rebirth_times = (this.BChar.Info.LV + 1) / 2;
            this.Mokou_First_3rd = true;
            BattleSystem.DelayInput(this.Start());
            MasterAudio.PlaySound("Mokou_Start", 2f, null, 0f, null, null, false, false);
        }
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false,
          bool NOEFFECT = false, BattleChar Target = null)
        {
            if (this.Mokou_Rebirth < this.Mokou_Rebirth_times && this.BChar.Info.Hp <= 0)
            {
                resist = true;
                if (this.Mokou_Rebirth == this.Mokou_Rebirth_times - 1 && Mokou_First_3rd == true)
                {
                    BattleSystem.DelayInput(this.Angry());
                    MasterAudio.PlaySound("Mokou_angry", 2f, null, 0f, null, null, false, false);
                    EX_ability.MokouRebirth(this.BChar, false);
                    new WaitForSecondsRealtime(1f);
                    bool bossBattle = BattleSystem.instance.BossBattle;
                    if (bossBattle)
                    {
                        MasterAudio.FadeBusToVolume("BGM", 0f, 0.5f, null, false, false);
                    }
                    else
                    {
                        MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);
                    }
                    PlaySoundResult PSR = MasterAudio.PlaySound("BGM_Mokou_Angry", 1f, null, 0f, null, null, false, false);
                    PSR.ActingVariation.SoundFinished += this.BGMback;
                    Mokou_First_3rd = false;
                }
                else
                {
                    EX_ability.MokouRebirth(this.BChar, true);
                }
            }
        }
        public void BGMback()
        {
            bool bossBattle = BattleSystem.instance.BossBattle;
            if (bossBattle)
            {
                MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            }
            else
            {
                MasterAudio.FadeBusToVolume("BattleBGM", 1f, 1f, null, false, false);
            }
        }
        public IEnumerator Start()
        {
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, "好吧，那就让战斗开始吧！", false);
            yield break;
        }
        public IEnumerator Angry()
        {
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, "你们惹老子生气了", false);
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, "做好觉悟吧！", false);
            yield break;
        }
        public void Dead()
        {
            MasterAudio.PlaySound("Mokou_Dead", 2f, null, 0f, null, null, false, false);
        }
        private int Mokou_Rebirth = 0;
        private int Mokou_Rebirth_times = 0;
        private bool Mokou_First_3rd = true;
    }
}
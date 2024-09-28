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
namespace Eirin
{
	/// <summary>
	/// 八意永琳
	/// Passive:
	/// 当八意永琳使用指向单体的治疗技能时，会为目标施加1层[月人/新月]：
	/// 使用指向单体的攻击技能时，消耗一层[月人/新月]，八意永琳会对目标进行一次[月人/乱箭]，视作追加攻击。这个伤害的50%会连锁治疗持有者。
	/// </summary>
    public class P_Eirin:Passive_Char, IP_SkillUse_Team_Target, IP_BattleStart_Ones, IP_SomeOneDead, IP_BattleEnd
    {
        public override void Init()
        {
            this.OnePassive = true;
            base.Init();
        }

        public void SkillUseTeam_Target(Skill skill, List<BattleChar> Targets)
        {
            if (this.BChar != null && Targets != null && Targets.Count == 1 && Targets[0].Info.Ally == this.BChar.Info.Ally
                && (skill.Master == Targets[0] || skill.IsHeal))
            {
                Targets[0].BuffAdd("B_Eirin_P", this.BChar, false, 0, false, -1, false);
            }
        }

        public void BattleStart(BattleSystem Ins)
        {
            this.moon = false;
        }

        public void SomeOneDead(BattleChar DeadChar)
        {
            if (DeadChar.Info.Ally && !this.moon)
            {
                BattleSystem.DelayInputAfter(this.Del());
            }
        }
        
        public IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();
            if (!BattleSystem.instance.AllyTeam.AliveChars_Vanish.Any((BattleChar x) => !this.NoCheckList.Contains(x.Info.KeyData)))
            {
                yield return this.PhoenixTalkEnd();
            }
            yield break;
        }
        
        public IEnumerator PhoenixTalkEnd()
        {
            yield return new WaitForFixedUpdate();
            this.moon = true;
            MasterAudio.PlaySound("HidePassive", 1f, null, 0f, null, null, false, false);
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("Eirin").localizationInfo.SystemLocalizationUpdate("BattleDia/EirinHide/Text1"), false);
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("Eirin").localizationInfo.SystemLocalizationUpdate("BattleDia/EirinHide/Text2"), false);
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("Eirin").localizationInfo.SystemLocalizationUpdate("BattleDia/EirinHide/Text3"), false);
            this.BChar.BuffAdd("B_Eirin_P_Hide", this.BChar, false, 0, false, -1, false);
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

        private bool moon;

        private readonly List<string> NoCheckList = new List<string>
        {
            GDEItemKeys.Character_AllyDoll,
            "Eirin"
        };
    }
}
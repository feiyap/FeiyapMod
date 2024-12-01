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
namespace KirisameMarisa
{
	/// <summary>
	/// 雾雨魔理沙
	/// Passive:
	/// <b>东洋的西洋魔术师</b> - 回合开始时，雾雨魔理沙获得1层[超绝偷感]：暴击率+100%，受到伤害时解除。
	/// <b><color=#0000CD>危险等级</color></b> - 雾雨魔理沙每次使用攻击技能时，获得1层<color=#0000CD>危险等级</color>；否则减少1层<color=#0000CD>危险等级</color>。每层<color=#0000CD>危险等级</color>提供+1速度，并会解锁技能的额外效果。最多拥有4层<color=#0000CD>危险等级</color>。
	/// </summary>
    public class P_KirisameMarisa:Passive_Char, IP_PlayerTurn, IP_SkillUseHand_Team, IP_BattleEnd, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            this.BChar.BuffAdd("B_KirisameMarisa_P_1", this.BChar, false, 0, false, -1, false);
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master != this.BChar)
            {
                return;
            }
            if (skill.IsDamage)
            {
                this.BChar.BuffAdd("B_KirisameMarisa_P", this.BChar, false, 0, false, -1, false);
            }
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char.HP <= 0)
            {
                if (this.BChar.BuffFind("B_KirisameMarisa_P"))
                {
                    this.BChar.BuffReturn("B_KirisameMarisa_P").SelfDestroy();
                }
            }
        }

        public void BattleEnd()
        {
            this.BGMEnd();
        }

        public void BGMEnd()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);
        }
    }
}
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
    /// 魔开「Open Universe」
    /// 如果自身已经拥有[危险空间]，则解除[危险空间]，抽取1个技能并恢复1点法力值。
    /// </summary>
    public class S_KirisameMarisa_7: SkillBase_KirisameMarisa
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            if (this.BChar.BuffFind("B_KirisameMarisa_7", false))
            {
                this.BChar.BuffRemove("B_KirisameMarisa_7", false);
                BattleSystem.instance.AllyTeam.Draw();
                BattleSystem.instance.AllyTeam.AP += 1;
                return;
            }
            
            this.BChar.BuffAdd("B_KirisameMarisa_7", this.BChar, false, 0, false, -1, false);
            return;
        }
    }
}
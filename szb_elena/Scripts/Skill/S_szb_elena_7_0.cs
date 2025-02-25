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
namespace szb_elena
{
    /// <summary>
    /// 萝蕾娜的圣水
    /// 抽取1个技能。
    /// </summary>
    public class S_szb_elena_7_0 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false))
            {
                if (!buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                {
                    buff.SelfDestroy();
                }
            }
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false))
            {
                if (!buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                {
                    buff.SelfDestroy();
                }
            }
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}
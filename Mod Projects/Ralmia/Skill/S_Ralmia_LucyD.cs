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
namespace Ralmia
{
	/// <summary>
	/// 创造物的扫描
	/// 从弃牌堆中随机选择2张技能到手牌。
	/// 如果选择的是创造物技能，费用变为0。
	/// </summary>
    public class S_Ralmia_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int j = 0; j < 2; j++)
            {
                base.SkillUseSingle(SkillD, Targets);
                list = new List<Skill>();
                list.AddRange(this.BChar.MyTeam.Skills_UsedDeck);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].MySkill.KeyID == GDEItemKeys.Skill_S_Lucy_26)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }
                if (list.Count != 0)
                {
                
                        BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
                
                }
            }
        }

        // Token: 0x06000D78 RID: 3448 RVA: 0x00082AE0 File Offset: 0x00080CE0
        public void Del(SkillButton Mybutton)
        {
            BattleTeam.DrawInput input = null;
            Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill, input);
            Mybutton.Myskill.APChange = -10;
            list.Remove(Mybutton.Myskill);
        }

        private List<Skill> list;
    }
}
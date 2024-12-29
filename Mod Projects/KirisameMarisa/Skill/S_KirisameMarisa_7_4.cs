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
    /// 魔十字「Grand Cross」
    /// 如果自身已经拥有[危险空间]，则解除[危险空间]，抽取1个技能并恢复1点法力值。
    /// </summary>
    public class S_KirisameMarisa_7_4: S_KirisameMarisa_7
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();
            list.AddRange(this.BChar.MyTeam.Skills_UsedDeck);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master != this.BChar)
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

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.ForceDrawF(Mybutton.Myskill);
        }
    }
}
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
namespace HinanawiTenshi
{
	/// <summary>
	/// 气符「天启气象之剑」
	/// 展示所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，选择并获得其中一个。
	/// <color=#97FFFF>天启4</color> - 下个回合开始时，展示所有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，选择并获得其中一个。
	/// </summary>
    public class S_Tenshi_4: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(4, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Skill> list = new List<Skill>();

            foreach (String str in tenkiSkillList)
            {
                list.Add(Skill.TempSkill(str, this.BChar, this.BChar.MyTeam));
            }

            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, true, true, false, true));

            if (CheckKishi(4, false))
            {
                this.BChar.BuffAdd("B_Tenshi_4", this.BChar);
            }
        }

        public void Del(SkillButton Mybutton)
        {
            this.BChar.ParticleOut(Mybutton.Myskill, this.BChar);
        }
    }
}
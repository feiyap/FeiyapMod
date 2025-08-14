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
namespace Phrolova
{
	/// <summary>
	/// 我或曾梦见
	/// 手中的自己的技能全部变为“红与黑的歌”。
	/// 进入濒死状态时，解除该增益。
	/// </summary>
    public class B_Phrolova_Rare_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 120;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (this.BChar.HP <= 0)
            {
                base.SelfDestroy(true);
                return;
            }

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill.MySkill.KeyID == "S_Phrolova_Rare_1_1" || skill.Master != this.BChar)
                {
                    continue;
                }

                if (skill.MyButton && skill.MyButton.transform)
                {
                    UnityEngine.Object obj = UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), skill.MyButton.transform);
                    UnityEngine.Object.Destroy(obj, 1f);
                }

                foreach (Skill_Extended skill_Extended in skill.AllExtendeds)
                {
                    foreach (string text in skill.MySkill.SkillExtended)
                    {
                        if (text.Contains(skill_Extended.Name))
                        {
                            skill_Extended.SelfDestroy();
                        }
                    }
                }

                GDESkillData gdeskillData = new GDESkillData("S_Phrolova_Rare_1_1");
                gdeskillData.KeyID = "S_Phrolova_Rare_1_1";
                gdeskillData.AutoDelete = skill.AutoDelete;
                gdeskillData.Except = skill.isExcept;

                skill.Init(gdeskillData, this.BChar, this.BChar.MyTeam);
                skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);

                if (gdeskillData.Effect_Target != null)
                {
                    skill.MySkill.Effect_Target = gdeskillData.Effect_Target;
                }

                if (gdeskillData.Effect_Self != null)
                {
                    skill.MySkill.Effect_Self = gdeskillData.Effect_Self;
                }

                skill.Image_Skill = gdeskillData.Image_0_Path;
                skill.Image_Button = gdeskillData.Image_1_Path;
                skill.Image_Basic = gdeskillData.Image_2_Path;

                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
            }
        }
    }
}
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
namespace FairyLancelot
{
	/// <summary>
	/// 无垢搏动
	/// </summary>
    public class S_FLancelot_Rare_2:Skill_Extended
    {
        public int flag = 0;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.HP = this.BChar.GetStat.maxhp;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_FLancelot_C_2") && flag == 0)
            {
                flag = 1;

                UnityEngine.Object obj = UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), this.MySkill.MyButton.transform);
                UnityEngine.Object.Destroy(obj, 1f);

                foreach (Skill_Extended skill_Extended in this.MySkill.AllExtendeds)
                {
                    foreach (string text in this.MySkill.MySkill.SkillExtended)
                    {
                        if (text.Contains(skill_Extended.Name))
                        {
                            skill_Extended.SelfDestroy();
                        }
                    }
                }

                Type type = Type.GetType("FairyLancelot.S_FLancelot_Rare_1");
                
                Skill_Extended extended = (Skill_Extended)Activator.CreateInstance(type);
                GDESkillData gdeskillData = new GDESkillData("S_FLancelot_Rare_1");
                gdeskillData.KeyID = "S_FLancelot_Rare_1";
                gdeskillData.AutoDelete = this.MySkill.AutoDelete;
                gdeskillData.Except = this.MySkill.isExcept;
                
                this.MySkill.Init(gdeskillData, this.BChar, this.BChar.MyTeam);

                if (gdeskillData.Effect_Target != null)
                {
                    this.MySkill.MySkill.Effect_Target = gdeskillData.Effect_Target;
                }

                if (gdeskillData.Effect_Self != null)
                {
                    this.MySkill.MySkill.Effect_Self = gdeskillData.Effect_Self;
                }

                this.MySkill.ExtendedAdd(extended);
                this.MySkill.Image_Skill = gdeskillData.Image_0_Path;
                this.MySkill.Image_Button = gdeskillData.Image_1_Path;
                this.MySkill.Image_Basic = gdeskillData.Image_2_Path;

                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
            }
        }
    }
}
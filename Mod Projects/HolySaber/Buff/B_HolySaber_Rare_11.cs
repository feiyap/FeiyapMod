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
namespace HolySaber
{
	/// <summary>
	/// 神谕启程
	/// 使抽到的可<color=#FFA500>进化</color>的技能<color=#FFA500>进化</color>。
	/// </summary>
    public class B_HolySaber_Rare_11:Buff, IP_Draw
    {
        public override void Init()
        {
            base.Init();
        }
        
        public IEnumerator Draw(Skill Drawskill, bool NotDraw)
        {
            if (Drawskill.ExtendedFind_DataName("SE_HolySaber_Extend") != null && Drawskill.ExtendedFind_DataName("SE_HolySaber_Extended") == null)
            {
                SkillChange(Drawskill, true);
            }
            yield break;
        }

        public void SkillChange(Skill target, bool isDecree = false)
        {
            UnityEngine.Object obj = UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), target.MyButton.transform);
            UnityEngine.Object.Destroy(obj, 1f);

            foreach (Skill_Extended skill_Extended in target.AllExtendeds)
            {
                foreach (string text in target.MySkill.SkillExtended)
                {
                    if (text.Contains(skill_Extended.Name))
                    {

                        skill_Extended.SelfDestroy();
                    }
                }
            }

            string targetID = target.MySkill.KeyID + "__Ex";

            Type type = Type.GetType("HolySaber." + targetID);

            SkillExtended_HolySaber extended = (SkillExtended_HolySaber)Activator.CreateInstance(type);
            GDESkillData gdeskillData = new GDESkillData(targetID);
            gdeskillData.KeyID = targetID;
            gdeskillData.AutoDelete = target.AutoDelete;
            gdeskillData.Except = target.isExcept;

            target.Init(gdeskillData, this.BChar, this.BChar.MyTeam);

            if (target.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            {
                target.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            }

            if (target.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
            {
                target.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            }

            if (gdeskillData.Effect_Target != null)
            {
                target.MySkill.Effect_Target = gdeskillData.Effect_Target;
            }

            if (gdeskillData.Effect_Self != null)
            {
                target.MySkill.Effect_Self = gdeskillData.Effect_Self;
            }

            target.ExtendedAdd(extended);
            target.Image_Skill = gdeskillData.Image_0_Path;
            target.Image_Button = gdeskillData.Image_1_Path;
            target.Image_Basic = gdeskillData.Image_2_Path;
            target.ExtendedAdd("SE_HolySaber_Extended");
            BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
        }

    }
}
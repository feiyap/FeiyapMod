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
	/// 圣辉女剑士
	/// </summary>
    public class SkillExtended_HolySaber:Skill_Extended
    {
        public void SkillChange(Skill target, bool isDecree = false)
        {
            UnityEngine.Object obj = UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), target.MyButton.transform);
            UnityEngine.Object.Destroy(obj, 1f);

            //判断是不是“圣女的号令”导致的进化，如果是，不播放单独进化音频
            if (!isDecree)
            {
                PlaySkillSound(target.MySkill.KeyID, 2);
            }

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

            //if (target.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            //{
            //    target.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            //}

            //if (target.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
            //{
            //    target.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            //}

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

        public void PlaySkillSound(string key, int type = 1)
        {
            switch (type)
            {
                //普通技能音效
                case 1:
                    MasterAudio.PlaySound(key, 1f, null, 0f, null, null, false, false);
                    break;
                //进化音效
                case 2:
                    MasterAudio.PlaySound(key + "_Ex", 1f, null, 0f, null, null, false, false);
                    break;
                //进化技能音效
                case 3:
                    MasterAudio.PlaySound(key, 1f, null, 0f, null, null, false, false);
                    break;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.ExtendedFind_DataName("SE_HolySaber_Extended") != null)
            {
                PlaySkillSound(this.MySkill.MySkill.KeyID, 3);
            }
            else
            {
                if (this.MySkill.MySkill.KeyID == "S_HolySaber_P_0")
                {
                    GDECharacter_SkinData skinData = CharacterSkinData.GetSkinData(this.BChar.Info.KeyData);
                    if (skinData.Key == "Wilbert")
                    {
                        PlaySkillSound("S_Welbert_P_0", 1);
                    }
                    else
                    {
                        PlaySkillSound(this.MySkill.MySkill.KeyID, 1);
                    }
                }
                else
                {
                    PlaySkillSound(this.MySkill.MySkill.KeyID, 1);
                }
            }
        }

        public bool CheckUsedDefSkills(int count)
        {
            return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse && skill.ExtendedFind_DataName("SE_HolySaber_Defend") != null, -1).Count >= count;
        }

        public bool CheckUsedExSkills(int count)
        {
            return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse && skill.ExtendedFind_DataName("SE_HolySaber_Extended") != null, -1).Count >= count;
        }
    }
}
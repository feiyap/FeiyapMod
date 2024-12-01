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
	/// 魔理沙基类
	/// </summary>
    public class SkillBase_KirisameMarisa:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_KirisameMarisa_P", false))
                {
                    buffCount_N = this.BChar.BuffReturn("B_KirisameMarisa_P", false).StackNum;
                }
                else
                {
                    buffCount_N = 0;
                }

                if (buffCount_N != buffCount_L && BattleSystem.instance != null && !this.MySkill.IsNowCounting)
                {
                    this.SkillChange(this.MySkill.MySkill.KeyID, buffCount_N);
                }

                if (this.BChar.BuffFind("B_KirisameMarisa_P", false))
                {
                    this.buffCount_L = this.BChar.BuffReturn("B_KirisameMarisa_P", false).StackNum;
                }
                else
                {
                    this.buffCount_L = 0;
                }
            }
        }

        public void SkillChange(string target)
        {
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

            Type type = Type.GetType("KirisameMarisa." + target);

            SkillBase_KirisameMarisa extended = (SkillBase_KirisameMarisa)Activator.CreateInstance(type);
            GDESkillData gdeskillData = new GDESkillData(target);
            gdeskillData.KeyID = target;
            gdeskillData.AutoDelete = this.MySkill.AutoDelete;
            gdeskillData.Except = this.MySkill.isExcept;

            this.MySkill.Init(gdeskillData, this.BChar, this.BChar.MyTeam);

            //if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            //{
            //    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            //}

            //if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
            //{
            //    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            //}

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

        public void SkillChange(string targetocname, int buffcount)
        {
            string target = "";

            string basestr = "";
            foreach (string skillname in this.MarisaCard)
            {
                if (this.MySkill.MySkill.KeyID.Contains(skillname))
                {
                    basestr = skillname;
                    break;
                }
            }

            string targetname;
            target = basestr;

            for (int i = 1; i <= buffcount; i++)
            {
                targetname = basestr + "_" + i;
                if (MarisaCard.Exists(t => t == targetname))
                {
                    target = targetname;
                }
            }

            if (target == "" || target == this.MySkill.MySkill.KeyID)
            {
                return;
            }
            else
            {
                if (!this.MySkill.BasicSkill && this.MySkill.MyButton && this.MySkill.MyButton.transform)
                {
                    UnityEngine.Object obj = UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), this.MySkill.MyButton.transform);
                    UnityEngine.Object.Destroy(obj, 1f);
                }
            }

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

            Type type = Type.GetType("KirisameMarisa." + target);

            SkillBase_KirisameMarisa extended = (SkillBase_KirisameMarisa)Activator.CreateInstance(type);

            GDESkillData gdeskillData = new GDESkillData(target);
            gdeskillData.KeyID = target;
            gdeskillData.AutoDelete = this.MySkill.AutoDelete;
            gdeskillData.Except = this.MySkill.isExcept;

            this.MySkill.Init(gdeskillData, this.BChar, this.BChar.MyTeam);

            //if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            //{
            //    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            //}

            //if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
            //{
            //    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            //}

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

        public bool NoUsedDeck = false;

        public List<string> MarisaCard = new List<string>
        {
            "S_KirisameMarisa_0",
            "S_KirisameMarisa_0_4",
            "S_KirisameMarisa_1",
            "S_KirisameMarisa_1_3",
            "S_KirisameMarisa_2",
            "S_KirisameMarisa_2_2",
            "S_KirisameMarisa_2_4",
            "S_KirisameMarisa_3",
            "S_KirisameMarisa_3_2",
            "S_KirisameMarisa_4",
            "S_KirisameMarisa_4_3",
            "S_KirisameMarisa_5",
            "S_KirisameMarisa_5_1",
            "S_KirisameMarisa_5_2",
            "S_KirisameMarisa_5_3",
            "S_KirisameMarisa_5_4",
            "S_KirisameMarisa_5_5",
            "S_KirisameMarisa_6",
            "S_KirisameMarisa_6_2",
            "S_KirisameMarisa_7",
            "S_KirisameMarisa_7_4",
            "S_KirisameMarisa_8",
            "S_KirisameMarisa_8_2",
            "S_KirisameMarisa_8_4",
            "S_KirisameMarisa_9",
            "S_KirisameMarisa_9_3"
        };

        public int CheckBuffNum()
        {
            int count = 0;

            count = this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.BUFF, false, false).Count;

            return count;
        }

        public int CheckDebuffNum(BattleChar target)
        {
            int count = 0;

            count = target.GetBuffs(BattleChar.GETBUFFTYPE.ALLDEBUFF, false, false).Count;

            return count;
        }
    }
}
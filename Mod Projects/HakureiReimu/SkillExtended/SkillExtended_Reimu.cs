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
namespace HakureiReimu
{
    public class SkillExtended_Reimu:Skill_Extended
    {
        public void SkillChange(string target)
        {
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

            Type type = Type.GetType("HakureiReimu." + target);

            SkillExtended_Reimu extended = (SkillExtended_Reimu)Activator.CreateInstance(type);

            GDESkillData gdeskillData = new GDESkillData(target);
            gdeskillData.KeyID = target;
            gdeskillData.AutoDelete = this.MySkill.MySkill.AutoDelete;

            this.MySkill.Init(gdeskillData, this.BChar, this.BChar.MyTeam);

            if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            }

            if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            }

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

            foreach (string skillname in this.ReimuCard)
            {
                string targetname = targetocname + "_" + buffcount;
                if (buffcount == 0)
                {
                    targetname = targetocname;
                }
                for (int i = 0; i < buffcount; i++)
                {
                    string previewname = targetocname + "_" + i;
                    if (skillname == previewname)
                    {
                        targetname = previewname;
                    }
                }
                
                if (skillname == targetname)
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

            Type type = Type.GetType("HakureiReimu." + target);

            SkillExtended_Reimu extended = (SkillExtended_Reimu)Activator.CreateInstance(type);

            GDESkillData gdeskillData = new GDESkillData(target);
            gdeskillData.KeyID = target;
            gdeskillData.AutoDelete = this.MySkill.MySkill.AutoDelete;

            this.MySkill.Init(gdeskillData, this.BChar, this.BChar.MyTeam);

            if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            }

            if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
            {
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            }

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
        
        public List<string> ReimuCard = new List<string>
        {
            "S_HakureiReimu_F_0",
            "S_HakureiReimu_F_0_1",
            "S_HakureiReimu_F_0_2",
            "S_HakureiReimu_F_0_3",
            "S_HakureiReimu_F_0_4",
            "S_HakureiReimu_F_0_5",
            "S_HakureiReimu_F_1",
            "S_HakureiReimu_F_1_2",
            "S_HakureiReimu_F_1_5",
            "S_HakureiReimu_F_2",
            "S_HakureiReimu_F_2_3",
            "S_HakureiReimu_F_3",
            "S_HakureiReimu_F_3_2",
            "S_HakureiReimu_F_4",
            "S_HakureiReimu_F_4_3",
            "S_HakureiReimu_F_4_5",
            "S_HakureiReimu_F_5",
            "S_HakureiReimu_F_5_2",
            "S_HakureiReimu_F_5_5",
            "S_HakureiReimu_F_6",
            "S_HakureiReimu_F_6_4",
            "S_HakureiReimu_F_7",
            "S_HakureiReimu_F_7_3",
            "S_HakureiReimu_F_8",
            "S_HakureiReimu_F_8_3",
            "S_HakureiReimu_F_9",
            "S_HakureiReimu_F_9_5"
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
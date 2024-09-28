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
namespace saber
{
    public class Saber_shanyao_base:Saber_jinsheng_ex, IP_SCUpdate
    {
        public override void Init()
        {
            base.Init();
        }

        // Token: 0x0600011D RID: 285 RVA: 0x00007CF8 File Offset: 0x00005EF8
        public void SCUpdate(BattleChar BuffMaster, Buff addedbuff)
        {
            bool flag = !this.MySkill.BasicSkill && !this.MySkill.isExcept && BattleSystem.instance != null && !this.MySkill.IsNowCounting;
            if (flag)
            {
                bool flag2 = this.SaberCard.Contains(this.MySkill.MySkill.KeyID);
                if (flag2)
                {
                    bool flag3 = this.MySkill.MySkill.KeyID == "Saber_shanyao" && addedbuff.StackNum >= 10;
                    if (flag3)
                    {
                        bool flag4 = BattleSystem.instance.AllyTeam.Skills.Contains(this.MySkill);
                        if (flag4)
                        {
                            UnityEngine.Object obj = UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), this.MySkill.MyButton.transform);
                            UnityEngine.Object.Destroy(obj, 1f);
                        }
                    }
                }
            }
        }
    }
}
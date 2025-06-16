using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
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
namespace Ralmia2
{
	/// <summary>
	/// 融合
	/// </summary>
    public class SkillExtended_Fusion: Skill_Extended
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BuffIcon != null && this.BuffIcon.GetComponent<Button>() == null)
            {
                Button button = this.BuffIcon.AddComponent<Button>();
                button.onClick.AddListener(new UnityAction(this.Call));
            }
        }

        public void Call()
        {
            foreach (Skill_Extended skill_Extended in this.MySkill.AllExtendeds)
            {
                if (skill_Extended.Name == base.Name && skill_Extended != this)
                {
                    skill_Extended.SelfDestroy();
                }
            }

            foreach (IP_Fusion ip_fusion in BattleSystem.instance.IReturn<IP_Fusion>())
            {
                if (ip_fusion != null)
                {
                    ip_fusion.FusionCall(this.MySkill);
                }
            }
        }
    }
}
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
	/// 圣女的号令
	/// <i><color=#FFA500>见识一下吧！这就是真实的我！</color></i>
	/// </summary>
    public class S_HolySaber_P_0: SkillExtended_HolySaber
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill != MySkill && skill.ExtendedFind_DataName("SE_HolySaber_Extend") != null && skill.ExtendedFind_DataName("SE_HolySaber_Extended") == null)
                {
                    SkillChange(skill, true);
                }
            }

            if (SaveManager.NowData.EnableSkins.Any((SkinData v) => v.skinKey != "Wilbert"))
            {
                GDEImageDatasData gdeimageDatasData = new GDEImageDatasData("HolySaberImage");
                AddressableLoadManager.LoadAsyncAction(gdeimageDatasData.Sprites_Path[1], AddressableLoadManager.ManageType.Character, this.BChar.UI.CharImage.GetComponent<Image>());
            }
        }
    }
}
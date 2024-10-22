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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 土著神「手长足长大人」
	/// 打出时，将手中最下方的1个技能放回牌库。那之后，抽取1个技能。
	/// <color=green>连击8</color> - 效果变为“打出时，将手中最下方的1个技能放回牌库。那之后，从牌库中选择1个技能抽取。”。
	/// <color=#008B45>旋回</color> - 展示牌堆最下方的3个技能，选择1个加入手中。使选择的技能获得迅速、致命。
	/// </summary>
    public class S_Suwako_5:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();
            list.AddRange(this.MySkill.Master.MyTeam.Skills);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == SkillD)
                {
                    list.RemoveAt(i);
                    break;
                }
            }
            if (list.Count >= 1)
            {
                //list[list.Count - 1].Delete(false);
                BattleSystem.DelayInputAfter(this.Return(list[list.Count - 1]));
            }
            BattleSystem.DelayInputAfter(this.Draw());
        }

        public IEnumerator Return(Skill skill)
        {
            yield return CustomMethods.I_SkillBackToDeck(skill);

            yield return null;
            yield break;
        }

        public IEnumerator Draw()
        {
            yield return this.MySkill.Master.MyTeam._Draw();

            yield return null;
            yield break;
        }
    }
}
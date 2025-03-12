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
	/// <color=green>连击4</color> - 效果变为“打出时，将手中最下方的1个技能放回牌库。那之后，从牌库中选择1个技能抽取。”。
	/// <color=#008B45>旋回</color> - 展示牌堆最下方的3个技能，选择1个加入手中。使选择的技能获得迅速、致命。
	/// </summary>
    public class S_Suwako_5: SkillExtend_Suwako, IP_SkillSelfToDeck
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckUsedSkills(4))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
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
            if (CheckUsedSkills(4))
            {
                BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(BattleSystem.instance.AllyTeam.Skills_Deck, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
            }
            else
            {
                BattleSystem.DelayInputAfter(this.Draw());
            }
        }

        public IEnumerator Return(Skill skill)
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(0, this.BChar.MyTeam.Skills_Deck.Count);
            
            yield return CustomMethods.I_SkillBackToDeck(skill, randomIndex, true);

            yield return null;
            yield break;
        }

        public IEnumerator Draw()
        {
            yield return this.MySkill.Master.MyTeam._Draw();

            yield return null;
            yield break;
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill);
            Skill_Extended se = new Skill_Extended();
            se.Fatal = true;
            se.NotCount = true;
            Mybutton.Myskill.ExtendedAdd(se);
        }

        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            List<Skill> list = new List<Skill>();
            List<Skill> list2 = new List<Skill>();
            list2.AddRange(BattleSystem.instance.AllyTeam.Skills_Deck);
            list2.Reverse();
            int num = 0;
            int num2 = 0;
            while (num2 < list2.Count && num < 3)
            {
                list.Add(list2[num2]);
                num++;
                num2++;
            }
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
        }
    }
}
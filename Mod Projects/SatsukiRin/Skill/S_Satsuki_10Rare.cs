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
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
namespace SatsukiRin
{
	/// <summary>
	/// 终焉「满溢着光的摇篮中」
	/// 幻灭X - 超额恢复X点体力值；复活所有阵亡的调查员，并使他们的体力恢复至X。X等于自身所有的[幻光]层数。
	/// </summary>
    public class S_Satsuki_10Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            //MasterAudio.PlaySound("S_Satsuki_10Rare");
            MasterAudio.PlaySound("S_Satsuki_10Rare", 1f, null, 0f, null, null, false, false);

            List<BattleChar> list = new List<BattleChar>();

            if (this.BChar.BuffFind("B_Satsuki_P", false))
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.Chars)
                {
                    if (battleChar.IsDead)
                    {
                        battleChar.IsDead = false;
                        battleChar.Heal(this.BChar, this.BChar.BuffReturn("B_Satsuki_P", false).StackNum, false, true, null);
                        list.Add(battleChar);
                    }
                    else
                    {
                        battleChar.Heal(this.BChar, this.BChar.BuffReturn("B_Satsuki_P", false).StackNum, false, true, null);
                    }
                }
                foreach (BattleChar battleChar in list)
                {
                    BattleSystem.DelayInput(Revive(battleChar));
                }
            }
            
            this.BChar.BuffReturn("B_Satsuki_P", false).SelfDestroy();
        }

        public override string DescExtended(string desc)
        {
            if (this.BChar.BuffFind("B_Satsuki_P", false))
            {
                return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.BuffReturn("B_Satsuki_P", false).StackNum)).ToString());
            }
            else
            {
                return base.DescExtended(desc).Replace("%a", 0.ToString());
            }
        }

        public IEnumerator Revive(BattleChar battleChar)
        {
            

            yield return new WaitForSecondsRealtime(0.2f);

            List<Skill> list = new List<Skill>();
            for (int i = 0; i < battleChar.Skills.Count; i++)
            {
                list.Add(battleChar.Skills[i].CloneSkill(false, null, battleChar.Skills[i].AllExtendeds, false));
            }
            foreach (Skill skill in list)
            {
                BattleSystem.DelayInput(this.DeckToUsedDeck(skill));
                BattleSystem.instance.AllyTeam.Skills_UsedDeck.Add(skill);
            }

            yield return new WaitForFixedUpdate();
            
            yield break;
        }

        public IEnumerator DeckToUsedDeck(Skill sk)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(BattleSystem.instance.ActWindow.Skillwin.DrawParticle, BattleSystem.instance.ActWindow.Skillwin.StartPos);
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.SetParent(BattleSystem.instance.MainUICanvas.transform);
            ShortcutExtensions.DOPath(gameObject.transform, Misc.GetQuadraticBezierPointsRight(gameObject.transform.position, BattleSystem.instance.ActWindow.Skillwin.WastePos.transform.position, UnityEngine.Random.Range(3f, 6f)), 0.25f, PathType.Linear, PathMode.Full3D, 10, null).SetEase(Ease.InOutSine);
            bool flag = sk.MySkill.User == "Lucy" || sk.MySkill.Rare;
            if (flag)
            {
                gameObject.GetComponent<CardAniParticle>().ColorChangeRed();
            }
            else
            {
                bool flag2 = sk.MySkill.Category.Key == GDEItemKeys.SkillCategory_DefultSkill || sk.MySkill.Category.Key == GDEItemKeys.SkillCategory_PublicSkill;
                if (flag2)
                {
                    gameObject.GetComponent<CardAniParticle>().ColorChangeWhite();
                }
                else
                {
                    gameObject.GetComponent<CardAniParticle>().ColorChangeYello();
                }
            }
            yield return new WaitForSeconds(0.04f);
            yield break;
        }
    }
}
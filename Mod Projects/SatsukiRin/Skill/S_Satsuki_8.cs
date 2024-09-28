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
	/// 终符「花鸟风月为彷徨之行」
	/// </summary>
    public class S_Satsuki_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            //MasterAudio.PlaySound("S_Satsuki_8");

            bool exist = false;

            if (this.BChar.BuffFind("B_Satsuki_P", false) && this.BChar.BuffReturn("B_Satsuki_P", false).StackNum >= 15)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.Chars)
                {
                    if (battleChar.IsDead)
                    {
                        exist = true;
                        MasterAudio.PlaySound("S_Satsuki_10Rare", 1f, null, 0f, null, null, false, false);
                        for (int i = 0; i < 15; i++)
                        {
                            this.BChar.BuffReturn("B_Satsuki_P", false).SelfStackDestroy();
                        }
                        BattleSystem.DelayInput(Revive(battleChar));
                        break;
                    }
                }
            }

            if (!exist)
            {
                for (int i = 0; i < 5; i++)
                {
                    this.BChar.BuffAdd("B_Satsuki_P", this.BChar, false, 0, false, -1, false);
                }
                BattleSystem.instance.AllyTeam.Draw();
                this.BChar.MyTeam.AP += 1;
            }
        }

        public IEnumerator Revive(BattleChar battleChar)
        {
            yield return new WaitForSecondsRealtime(0.2f);

            battleChar.IsDead = false;
            battleChar.Heal(this.BChar, 15, false, true, null);

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
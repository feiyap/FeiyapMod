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
namespace HouraisanKaguya
{
	/// <summary>
	/// 不死鸟狂想
	/// 复活所有队友。使所有队友体力恢复最大生命值的一半。
	/// </summary>
    public class S_FMokou_Revive:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<BattleChar> list = new List<BattleChar>();
            
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.Chars)
            {
                if (battleChar.IsDead)
                {
                    battleChar.IsDead = false;
                    battleChar.Heal(BattleSystem.instance.DummyChar, (float)((int)Misc.PerToNum((float)battleChar.Info.get_stat.maxhp, 40f)), false, true, null);
                    list.Add(battleChar);
                }
                else
                {
                    battleChar.Heal(BattleSystem.instance.DummyChar, (float)((int)Misc.PerToNum((float)battleChar.Info.get_stat.maxhp, 40f)), false, true, null);
                }
            }
            foreach (BattleChar battleChar in list)
            {
                BattleSystem.DelayInput(Revive(battleChar));
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
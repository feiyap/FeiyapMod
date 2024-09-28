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
namespace Mokou
{
	/// <summary>
	/// 蓬莱之躯
	/// 生命值无法降低到1以下。每当生命值降到1时，本回合内免疫伤害并将于下回合进入下一阶段。
	/// </summary>
    public class B_Kaguya_P:Buff, IP_TurnEnd, IP_PlayerTurn_1, IP_BattleStart_UIOnBefore, IP_Dead
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override string DescExtended()
        {
            string text = base.DescExtended();
            switch (this.Phase)
            {
                case 1:
                    text = text.Replace("&a", "1").Replace("&b", "神宝「耀眼的龙玉」").Replace("&c", "难题「龙颈之玉　-五色的弹丸-」");
                    break;
                case 2:
                    text = text.Replace("&a", "2").Replace("&b", "神宝「佛体的金刚石」").Replace("&c", "难题「佛御石之钵　-不碎的意志-」");
                    break;
                case 3:
                    text = text.Replace("&a", "3").Replace("&b", "神宝「火蜥蜴之盾」").Replace("&c", "难题「火鼠的皮衣　-不焦躁的内心-」");
                    break;
                case 4:
                    text = text.Replace("&a", "4").Replace("&b", "神宝「无限的生命之泉」").Replace("&c", "难题「燕的子安贝　-永命线-」");
                    break;
                case 5:
                    text = text.Replace("&a", "5").Replace("&b", "神宝「蓬莱的玉枝　-梦色之乡-」").Replace("&c", "难题「蓬莱的弹枝　-七色的弹幕-」");
                    break;
            }
            return text;
        }
        public void TurnEnd()
        {
            if (this.Phase > 0 && this.Phase < 5)
            {
                if (this.BChar.HP <= 1 && !this.PhaseEnd)
                {
                    this.PhaseEnd = true;
                    this.BChar.ParticleOut(Skill.TempSkill("SP_Kaguya_ChangePhase", this.BChar, this.BChar.MyTeam), this.BChar);
                    this.BChar.BuffAdd("B_Kaguya_P_1", this.BChar, false, 0, false, -1, false);
                    new WaitForSecondsRealtime(1f);
                    return;
                }
            }
            else
            {
                bool isDead = this.BChar.MyTeam.AliveChars.Count < this.BChar.MyTeam.Chars.Count;
                if (this.Phase == 5 && isDead == false)
                {
                    if (this.BChar.HP <= 1 && !this.PhaseEnd)
                    {
                        this.PhaseEnd = true;
                        if (EX_ability.ChackConundrum(this.BChar))
                        {
                            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                            {
                                battleChar.BuffAdd("B_Mokou_S_Achieve", this.BChar, false, 0, false, -1, false);
                            }
                        }
                        else
                        {
                            this.BChar.BuffAdd("B_Kaguya_S_Fail", this.BChar, false, 0, false, -1, false);
                        }
                        this.BChar.ParticleOut(Skill.TempSkill("SP_Kaguya_ChangePhase", this.BChar, this.BChar.MyTeam), this.BChar);
                        new WaitForSecondsRealtime(1f);
                        return;
                    }
                }
                if (this.Phase == 5 && isDead == true)
                {
                    if (this.BChar.HP <= 1 && !this.PhaseEnd)
                    {
                        this.PhaseEnd = true;
                        BattleSystem.DelayInput(this.NormalEnding());
                        new WaitForSecondsRealtime(1f);
                        return;
                    }
                }
            }
        }
        public IEnumerator NormalEnding()
        {
            if (Mokou_isTeam)
            {
                yield return BattleText.InstBattleText_Co(this.BChar, "诶呀，看来这次还是我赢下来了呢。", true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, "那么，就到此为止吧。", true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, "再会了，妹红。", true, 0, 0f);
            }
            else
            {
                yield return BattleText.InstBattleText_Co(this.BChar, "诶呀，看来我下手有点重了呢。", true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, "那么，这次就到此为止吧。", true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, "再会了，诸位。", true, 0, 0f);
            }
            this.BChar.Dead(false,false);
            yield break;
        }
        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            Mokou_isTeam = false;
            MasterAudio.StopBus("BGM");
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                if (battleAlly.Info.KeyData == "Mokou")
                {
                    Mokou_isTeam = true;
                }
            }
            BattleSystem.DelayInput(this.Start1());
        }
        public IEnumerator Start1()
        {
            List<Skill> skills = new List<Skill>
            {
                Skill.TempSkill("S_Kaguya_Difficulty_0", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam),
                Skill.TempSkill("S_Kaguya_Difficulty_1", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam),
            };
            if (Mokou_isTeam)
            {
                skills.Add(Skill.TempSkill("S_Kaguya_Difficulty_2", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam));
                foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
                {
                    if (battleAlly.Info.KeyData == "Mokou")
                    {
                        yield return BattleText.InstBattleText_Co(this.BChar, "啊啦啊啦，看看这位是谁啊", true, 0, 0f);
                        yield return BattleText.InstBattleTextAlly_Co(battleAlly, "真是好久不见了呢，辉夜", false);
                        yield return BattleText.InstBattleText_Co(this.BChar, "既然你也来了，就陪我一起大闹一场吧", true, 0, 0f);
                        yield return BattleText.InstBattleTextAlly_Co(battleAlly, "上一次的失败，就让我这一次讨回来！", false);
                    }
                }
            }
            else
            {
                yield return BattleText.InstBattleText_Co(this.BChar, "真是好久没有人来到这里了啊，", true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, "就让我久违的大闹一场吧。", true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, "到现在为止，已经使无数人败退的这五个难题。", true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, "你们能解开多少呢？", true, 0, 0f);
            }
            BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(skills, new SkillButton.SkillClickDel(this.Del), "撒，做出选择吧！", false, false, false, false, false));
            yield break;
        }
        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Kaguya_Difficulty_0")
            {
                BattleSystem.DelayInput(this.ChooseToFight());
            }
            else
            {
                if (Mybutton.Myskill.MySkill.KeyID == "S_Kaguya_Difficulty_1")
                {
                    BattleSystem.DelayInput(this.ChooseToLunatic());
                }
                else
                {
                    if (Mybutton.Myskill.MySkill.KeyID == "S_Kaguya_Difficulty_2")
                    {
                        BattleSystem.DelayInput(this.ChooseToMokou());
                    }
                }
            }
        }
        public void Dead()
        {
            if (this.Phase < 6)
            {
                BattleSystem.instance.Reward.Clear();
            }
            else
            {
                
            }
        }
        public void Turn1()
        {
            if (this.Phase < 6)
            {
                BattleSystem.DelayInput(this.ConundrumAdd());
            }
        }
        public IEnumerator ConundrumAdd()
        {
            yield return new WaitForFixedUpdate();
            BattleSystem.instance.AllyTeam.Add(Skill.TempSkill("S_Kaguya_" + Phase + "_S", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam), true);
            yield return null;
            yield break;
        }
        public IEnumerator ChooseToLunatic()
        {
            this.LunaticMode = true;
            this.BChar.BuffAdd("B_Kaguya_Lunatic", this.BChar, false, 0, false, -1, false);
            BattleSystem.DelayInput(this.ChooseToFight());
            yield return null;
            yield break;
        }
        public IEnumerator ChooseToFight()
        {
            this.BChar.BuffAdd("B_Kaguya_P_0", this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd("B_Kaguya_P_1", this.BChar, false, 0, false, -1, false);
            MasterAudio.SetBusVolumeByName("BGM", 1f);
            PlaySoundResult PSR = MasterAudio.PlaySound("BGM_Kaguya", 0.8f, null, 0f, null, null, false, false);
            PSR.ActingVariation.SoundFinished += this.BGMLoop;
            yield break;
        }
        public IEnumerator ChooseToMokou()
        {
            this.MokouMode = true;
            BattleSystem.DelayInput(this.ChooseToLunatic());
            yield return null;
            yield break;
        }
        public void BGMLoop()
        {
            PlaySoundResult playSoundResult = new PlaySoundResult();
            playSoundResult = MasterAudio.PlaySound("BGM_Kaguya", 0.8f, null, 0f, null, null, false, false);
            playSoundResult.ActingVariation.SoundFinished += this.BGMLoop;
        }
        public bool LunaticMode = false;
        public bool MokouMode = false;
        public int Phase = 1;
        public bool PhaseEnd = false;
        public bool Mokou_isTeam = false;
    }
}
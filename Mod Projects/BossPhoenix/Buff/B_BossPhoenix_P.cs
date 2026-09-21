using System.Collections;
using DarkTonic.MasterAudio;
using GameDataEditor;
using UnityEngine;

namespace BossPhoenix
{
    /// <summary>
    /// 耍赖皮
    /// 凤凰就算被打至1血也会耍性子赖着不死……
    /// 聪明的露西有没有办法哄好它呢？
    /// </summary>
    public class B_BossPhoenix_P : Buff, IP_HPChange, IP_BattleStart_Ones, IP_BattleStart_UIOnBefore
    {
        public bool Stubborn;
        public bool Soothed;
        public bool stubbornTalked;
        private bool hpLock;
        public string ImaginedKey = "";
        public int WrongGuesses;
        public int LostRiddleCount;

        public static B_BossPhoenix_P Get(BattleChar bchar)
        {
            if (bchar != null)
            {
                B_BossPhoenix_P p = bchar.BuffReturn(ModItemKeys.Buff_B_BossPhoenix_P, false) as B_BossPhoenix_P;
                if (p != null)
                {
                    return p;
                }
            }
            return BattleEvent_Phoenix.MainP;
        }

        public static bool IsStubborn(BattleChar bchar)
        {
            B_BossPhoenix_P p = Get(bchar);
            return p != null && p.Stubborn && !p.Soothed;
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.HIT_CC = 0f;
            this.PlusStat.HIT_DEBUFF = 0f;
            this.PlusStat.HIT_DOT = 0f;
        }

        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            BattleSystem.DelayInput(this.StartTalk());
            Ins.Reward.Add(ItemBase.GetItem(GDEItemKeys.Item_Consume_SkillBookCharacter_Rare));
            Ins.Reward.Add(ItemBase.GetItem(new GDESkillData(ModItemKeys.Skill_S_BossPhoenix_SmallWorld)));
        }

        public void BattleStart(BattleSystem Ins)
        {
            Ins.BattleExtended.Add(new BattleEvent_Phoenix());
            BattleEvent_Phoenix.Boss = this.BChar;
            BattleEvent_Phoenix.MainP = this;
            this.Stubborn = false;
            this.Soothed = false;
            this.stubbornTalked = false;
            this.LostRiddleCount = 0;
            this.ResetRiddle();
        }

        public IEnumerator StartTalk()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            yield return BattleText.InstBattleText_Co(this.BChar, PhoenixLoc.BattleStart1, true, 0, 0f);
            yield return BattleText.InstBattleText_Co(this.BChar, PhoenixLoc.BattleStart2, true, 0, 0f);
            yield return BattleText.InstBattleText_Co(this.BChar, PhoenixLoc.BattleStart3, true, 0, 0f);
            yield break;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (this.hpLock || Char != this.BChar || this.Soothed)
            {
                return;
            }
            if (this.BChar != null && this.BChar.HP <= 1)
            {
                this.SurviveAtOne();
            }
        }

        /// <summary>
        /// 夹到 1 血并进入耍赖皮。设 HP 会再进 HPChange，必须加锁避免闪退。
        /// </summary>
        public void SurviveAtOne()
        {
            if (this.Soothed || this.hpLock)
            {
                return;
            }
            this.hpLock = true;
            try
            {
                if (this.BChar != null)
                {
                    if (this.BChar.HP < 1)
                    {
                        this.BChar.HP = 1;
                    }
                    this.BChar.IsDead = false;
                }
                this.TriggerStubborn();
            }
            finally
            {
                this.hpLock = false;
            }
        }

        public void TriggerStubborn()
        {
            if (this.Soothed)
            {
                return;
            }
            bool first = !this.Stubborn;
            this.Stubborn = true;
            if (this.BChar != null)
            {
                this.BChar.IsDead = false;
            }
            if (!first)
            {
                return;
            }
            this.ResetRiddle();
            if (!this.stubbornTalked)
            {
                this.stubbornTalked = true;
                if (BattleSystem.instance != null)
                {
                    BattleSystem.DelayInput(this.Co_StubbornTalk());
                }
            }
        }

        private IEnumerator Co_StubbornTalk()
        {
            yield return BattleText.InstBattleText_Co(this.BChar, PhoenixLoc.Stubborn, true, 0, 0f);
            yield break;
        }

        public void ResetRiddle()
        {
            this.ImaginedKey = "";
            this.WrongGuesses = 0;
        }

        /// <summary>
        /// 登记本局猜谜失败。返回是否已累计失败到判负。
        /// </summary>
        public bool RegisterRiddleLoss()
        {
            this.LostRiddleCount++;
            return this.LostRiddleCount >= PhoenixSkillUtil.MaxRiddleLoss;
        }

        public bool HasBread()
        {
            return PartyInventory.InvenM.FindItem(GDEItemKeys.Item_Consume_Bread) > 0;
        }

        public void EnsureImagined()
        {
            if (this.Stubborn && !this.Soothed)
            {
                // 想象原版找面包 / 扔面包，猜对再发很急版
                this.ImaginedKey = this.HasBread()
                    ? PhoenixSkillUtil.VanillaThrowBread
                    : PhoenixSkillUtil.VanillaFindBread;
                return;
            }

            if (!string.IsNullOrEmpty(this.ImaginedKey))
            {
                return;
            }

            this.ImaginedKey = PhoenixSkillUtil.PickRandomImaginedKey();
        }

        public string RewardKeyForGuess()
        {
            if (this.Stubborn && !this.Soothed)
            {
                if (this.ImaginedKey == PhoenixSkillUtil.VanillaFindBread)
                {
                    return ModItemKeys.Skill_S_BossPhoenix_FindBread;
                }
                if (this.ImaginedKey == PhoenixSkillUtil.VanillaThrowBread)
                {
                    return ModItemKeys.Skill_S_BossPhoenix_ThrowBread;
                }
            }
            return this.ImaginedKey;
        }

        public void SootheAndDefeat()
        {
            this.Soothed = true;
            this.Stubborn = false;
            BattleSystem.DelayInput(this.Co_Soothe());
        }

        private IEnumerator Co_Soothe()
        {
            yield return BattleText.InstBattleText_Co(this.BChar, PhoenixLoc.Soothe, true, 0, 0f);
            if (this.BChar != null && !this.BChar.IsDead)
            {
                this.BChar.Dead();
            }
            yield break;
        }
    }
}

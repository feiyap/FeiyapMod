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
        public string ImaginedKey = "";
        public int WrongGuesses;
        public int LostRiddleCount;

        public static B_BossPhoenix_P Get(BattleChar bchar)
        {
            if (bchar == null)
            {
                return BattleEvent_Phoenix.MainP;
            }
            return bchar.BuffReturn(ModItemKeys.Buff_B_BossPhoenix_P, false) as B_BossPhoenix_P;
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

            yield return BattleText.InstBattleText_Co(this.BChar, ModLocalization.BattleStart1, true, 0, 0f);
            yield return BattleText.InstBattleText_Co(this.BChar, ModLocalization.BattleStart2, true, 0, 0f);
            yield return BattleText.InstBattleText_Co(this.BChar, ModLocalization.BattleStart3, true, 0, 0f);
            yield break;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char != this.BChar || this.Soothed)
            {
                return;
            }
            if (this.BChar.HP <= 1)
            {
                this.BChar.HP = 1;
                this.BChar.IsDead = false;
                this.TriggerStubborn();
            }
        }

        public void TriggerStubborn()
        {
            if (this.Soothed)
            {
                return;
            }
            this.Stubborn = true;
            if (this.BChar.HP < 1)
            {
                this.BChar.HP = 1;
            }
            this.BChar.IsDead = false;
            this.ResetRiddle();
            if (!this.stubbornTalked)
            {
                this.stubbornTalked = true;
                BattleSystem.DelayInput(this.Co_StubbornTalk());
            }
        }

        private IEnumerator Co_StubbornTalk()
        {
            yield return BattleText.InstBattleText_Co(this.BChar, ModLocalization.Stubborn, true, 0, 0f);
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
            if (!string.IsNullOrEmpty(this.ImaginedKey))
            {
                if (this.Stubborn && !this.Soothed)
                {
                    this.ImaginedKey = this.HasBread() ? GDEItemKeys.Skill_S_Phoenix_Draw_0 : GDEItemKeys.Skill_S_Phoenix_Draw_1;
                }
                return;
            }

            if (this.Stubborn && !this.Soothed)
            {
                this.ImaginedKey = this.HasBread() ? GDEItemKeys.Skill_S_Phoenix_Draw_0 : GDEItemKeys.Skill_S_Phoenix_Draw_1;
                return;
            }

            this.ImaginedKey = PhoenixSkillUtil.PickRandomImaginedKey();
        }

        public string RewardKeyForGuess()
        {
            if (this.Stubborn && !this.Soothed)
            {
                if (this.ImaginedKey == GDEItemKeys.Skill_S_Phoenix_Draw_1)
                {
                    return ModItemKeys.Skill_S_BossPhoenix_FindBread;
                }
                if (this.ImaginedKey == GDEItemKeys.Skill_S_Phoenix_Draw_0)
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
            yield return BattleText.InstBattleText_Co(this.BChar, ModLocalization.Soothe, true, 0, 0f);
            if (this.BChar != null && !this.BChar.IsDead)
            {
                this.BChar.Dead();
            }
            yield break;
        }
    }
}

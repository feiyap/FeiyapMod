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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天人之体
	/// 受到任何不小于2回合的减益效果时，该效果持续时间降低1回合。
	/// 受到单次超过100的伤害时，该伤害以对数降低。每次触发这个效果时，自身获得5个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// 当自身没有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>时，受到的伤害降低90%。
	/// </summary>
    public class Boss_B_Tenshi_P:Buff, IP_BuffAddAfter, IP_DamageTakeChange, IP_BattleStart_Ones, IP_BattleStart_UIOnBefore, IP_HPZero, IP_Dead
    {
        //处理战斗事件
        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            BattleSystem.DelayInput(this.Start1());
            BattleSystem.instance.Reward.Add(ItemBase.GetItem("R_Tenshi_0"));
        }

        //开场对话
        public IEnumerator Start1()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            BattleAlly reimu = new BattleAlly();
            bool isReimu = false;
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                if (battleAlly.Info.KeyData == "HakureiReimu")
                {
                    reimu = battleAlly;
                    isReimu = true;
                }
            }

            if (isReimu)
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text1"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(reimu, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text2"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text3"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text4"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(reimu, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text5"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text6"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(reimu, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text7"), false);
                yield return BattleText.InstBattleTextAlly_Co(reimu, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text8"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text9"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text10"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text11"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(reimu, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text12"), false);
                yield return BattleText.InstBattleTextAlly_Co(reimu, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi_Reimu/Text13"), false);
            }
            else
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text1"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text2"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text3"), true, 0, 0f);
            }

            MasterAudio.PlaySound("Boss_Tenshi_BGM", 1f, null, 0f, null, null, false, false);

            yield break;
        }

        public int Phase = 1;

        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Debuff && 
                (addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_Debuff || addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_DOT || addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_CrowdControl) && 
                stackBuff.RemainTime > 1)
            {
                stackBuff.RemainTime--;
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            int m = 25;
            int s = 100;
            if (Dmg >= s)
            {
                Dmg = (int)(m * Math.Log((Dmg - s) / m + 1) + s);
                if (!Preview)
                {
                    AddTenki(this.BChar, 5);
                }
            }

            if (!CheckTenki(true))
            {
                Dmg = (int)(Dmg * 0.1);
            }

            return Dmg;
        }

        public void BattleStart(BattleSystem Ins)
        {
            Ins.BattleExtended.Add(new BattleEvent_Tenshi());
            BattleEvent_Tenshi.Boss = this.BChar;
            BattleEvent_Tenshi.MainP = this;
            Phase = 1;
        }

        //被秒杀
        public void HPZero()
        {
            BattleSystem.DelayInput(this.HP0Dia());
        }

        //被秒杀对话
        public IEnumerator HP0Dia()
        {
            yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text4"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Tenshi/Text5"), true, 0, 0f);
        }

        public void Dead()
        {
            UnlockWindow.Unlock("Unlock_HinanawiTenshi", SaveManager.NowData.unlockList.UnlockCharacter, "HinanawiTenshi", true, true);
        }

        public void AddTenki(BattleChar bc, int count = 0)
        {
            for (int i = 0; i < count; i++)
            {
                List<String> tempList = new List<string> { };
                foreach (String str in tenkiList)
                {
                    if (!bc.BuffFind(str))
                    {
                        tempList.Add(str);
                    }
                }

                if (tempList.Count <= 0)
                {
                    return;
                }

                System.Random rand = new System.Random();
                int randomIndex = rand.Next(tempList.Count);
                string randomObject = tempList[randomIndex];

                bc.BuffAdd(randomObject, this.BChar, false, 0, false, 12);
            }
        }

        public bool CheckTenki(bool isPreview)
        {
            foreach (String str in tenkiList)
            {
                if (this.BChar.BuffFind(str))
                {
                    if (!isPreview)
                    {
                        this.BChar.BuffReturn(str).SelfDestroy();
                    }
                    return true;
                }
            }

            return false;
        }

        static public List<String> tenkiList = new List<string>
        {
            "B_Tenki_1",
            "B_Tenki_2",
            "B_Tenki_3",
            "B_Tenki_4",
            "B_Tenki_5",
            "B_Tenki_6",
            "B_Tenki_7",
            "B_Tenki_8",
            "B_Tenki_9",
            "B_Tenki_10",
            "B_Tenki_11",
            "B_Tenki_12",
            "B_Tenki_13",
            "B_Tenki_14",
            "B_Tenki_15",
            "B_Tenki_16",
            "B_Tenki_17",
            "B_Tenki_18",
            "B_Tenki_19",
            "B_Tenki_20"
        };
    }
}
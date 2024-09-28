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
namespace HouraisanKaguya
{
	/// <summary>
	/// 藤原妹红被动
	/// </summary>
    public class B_FMokou_P:Buff, IP_BattleStart_UIOnBefore, IP_Dead, IP_PlayerTurn, IP_Hit
    {
        public bool Kaguya_isTeam = false;
        public bool Mokou_isTeam = false;

        //处理战斗事件
        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            Ins.BattleExtended.Add(new BattleEvent_FMokou());
            BattleEvent_FMokou.reviveTimes = 0;
            BattleEvent_FMokou.flameTimes = 0;
            BattleEvent_FMokou.xufuCount = 0;
            BattleEvent_FMokou.onFire = false;
            BattleEvent_FMokou.battleend = false;

            MasterAudio.StopBus("BGM");
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                bool isKaguya = battleAlly.Info.KeyData == "HouraisanKaguya";
                if (isKaguya)
                {
                    this.Kaguya_isTeam = true;
                }
                bool isMokou = battleAlly.Info.KeyData == "Mokou";
                if (isMokou)
                {
                    this.Mokou_isTeam = true;
                }
            }
            BattleSystem.DelayInput(this.Start1());
        }

        //开场对话
        public IEnumerator Start1()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            BattleAlly kaguya = new BattleAlly();
            BattleAlly mokou = new BattleAlly();
            BattleAlly first = new BattleAlly();
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                if (battleAlly.Info.KeyData == "HouraisanKaguya")
                {
                    kaguya = battleAlly;
                }
                if (battleAlly.Info.KeyData == "Mokou")
                {
                    mokou = battleAlly;
                }
            }

            if (Kaguya_isTeam && Mokou_isTeam)
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText1"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(kaguya, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText2"), false);
                yield return BattleText.InstBattleTextAlly_Co(mokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText3"), false);
                yield return BattleText.InstBattleTextAlly_Co(kaguya, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText4"), false);
                yield return BattleText.InstBattleTextAlly_Co(mokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText5"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText6"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText7"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(kaguya, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText8"), false);
                yield return BattleText.InstBattleTextAlly_Co(mokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KMText9"), false);
            }
            else if (Kaguya_isTeam)
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KText1"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(kaguya, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KText2"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KText3"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KText4"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(kaguya, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KText5"), false);
                yield return BattleText.InstBattleTextAlly_Co(kaguya, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/KText6"), false);
            }
            else if (Mokou_isTeam)
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/MText1"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(mokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/MText2"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/MText3"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(mokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/MText4"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/MText5"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(mokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/MText6"), false);
            }
            else
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/Text1"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/Text2"), true, 0, 0f);
                yield return BattleText.InstBattleTextAlly_Co(BattleSystem.instance.AllyList[0], ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/Text3"), false);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/Text4"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/Text5"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleStart/Text6"), true, 0, 0f);
            }

            MasterAudio.PlaySound("FMokou-S0", 1f, null, 0f, null, null, false, false);

            yield break;
        }

        //死亡重生
        public void Dead()
        {
            if (BattleEvent_FMokou.battleend)
            {
                BattleEvent_FMokou.reviveTimes = 0;
                BattleEvent_FMokou.flameTimes = 0;
                BattleEvent_FMokou.xufuCount = 0;
                BattleEvent_FMokou.onFire = false;
                BattleEvent_FMokou.battleend = false;
                return;
            }
            if (this.BChar.BuffFind("B_FMokou_P_0"))
            {
                if (BattleEvent_FMokou.reviveTimes >= 10)
                {
                    return;
                }

                int prop = (int)Math.Pow(2, this.BChar.BuffReturn("B_FMokou_P_0").StackNum - 1);
                int ran = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 1, 100);
                if (ran > prop)
                {
                    BattleChar newMokou = BattleSystem.instance.CreatEnemy("Boss_Mokou", new Vector3(0f, 0f, 1.2f), true, false);
                    BattleEvent_FMokou.reviveTimes++;
                    BattleEvent_FMokou.flameTimes++;
                    BattleEvent_FMokou.xufuCount++;
                    for (int i = 0; i < BattleEvent_FMokou.reviveTimes; i++)
                    {
                        newMokou.BuffAdd("B_FMokou_P_1", newMokou);
                    }
                    for (int i = 0; i < BattleEvent_FMokou.flameTimes; i++)
                    {
                        newMokou.BuffAdd("B_FMokou_P_0", newMokou);
                    }
                    newMokou.Heal(newMokou, (float)newMokou.Info.get_stat.maxhp, false, true, null);

                    BattleSystem.DelayInput(B_FMokou_P.Del());

                    switch (BattleEvent_FMokou.reviveTimes)
                    {
                        case 1:
                            BattleSystem.DelayInputAfter(this.Start2(newMokou));
                            break;
                        case 2:
                        case 3:
                            newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);
                            break;
                        case 4:
                            BattleSystem.DelayInputAfter(this.Start3(newMokou));
                            break;
                        case 5:
                        case 6:
                            newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);
                            newMokou.BuffAdd("B_FMokou_Stage_2", newMokou);
                            break;
                        case 7:
                            BattleSystem.DelayInputAfter(this.Start4(newMokou));
                            break;
                        case 8:
                        case 9:
                            newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);
                            newMokou.BuffAdd("B_FMokou_Stage_2", newMokou);
                            newMokou.BuffAdd("B_FMokou_Stage_3", newMokou);
                            break;
                        case 10:
                            BattleSystem.DelayInputAfter(this.Start5(newMokou));
                            break;
                    }

                    if (BattleEvent_FMokou.xufuCount >= 2)
                    {
                        BattleSystem.DelayInputAfter(this.Xufu(newMokou));
                    }
                }
                else
                {
                    BattleChar newMokou = BattleSystem.instance.CreatEnemy("Boss_Mokou", new Vector3(0f, 0f, 1.2f), true, false);
                    BattleEvent_FMokou.battleend = true;
                    BattleSystem.DelayInputAfter(this.BattleEnd(newMokou));
                }
            }
            else
            {
                BattleChar newMokou = BattleSystem.instance.CreatEnemy("Boss_Mokou", new Vector3(0f, 0f, 1.2f), true, false);
                BattleEvent_FMokou.reviveTimes++;
                BattleEvent_FMokou.flameTimes++;
                BattleEvent_FMokou.xufuCount++;
                for (int i = 0; i < BattleEvent_FMokou.reviveTimes; i++)
                {
                    newMokou.BuffAdd("B_FMokou_P_1", newMokou);
                }
                for (int i = 0; i < BattleEvent_FMokou.flameTimes; i++)
                {
                    newMokou.BuffAdd("B_FMokou_P_0", newMokou);
                }
                newMokou.Heal(newMokou, (float)newMokou.Info.get_stat.maxhp, false, true, null);

                BattleSystem.DelayInputAfter(B_FMokou_P.Del());

                List<BattleChar> list = new List<BattleChar>();
                Skill skill = Skill.TempSkill("S_FMokou_3", newMokou, newMokou.MyTeam);
                List<BattleChar> list2 = new List<BattleChar>();
                Skill skill2 = Skill.TempSkill("S_FMokou_4", newMokou, newMokou.MyTeam);

                switch (BattleEvent_FMokou.reviveTimes)
                {
                    case 1:
                        BattleSystem.DelayInputAfter(this.Start2(newMokou));
                        break;
                    case 2:
                    case 3:
                        newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);

                        list.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill));
                        BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);

                        list2.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill2));
                        BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill2, list2, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);
                        break;
                    case 4:
                        BattleSystem.DelayInputAfter(this.Start3(newMokou));
                        break;
                    case 5:
                    case 6:
                        newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);
                        newMokou.BuffAdd("B_FMokou_Stage_2", newMokou);

                        list.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill));
                        BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);
                        
                        list2.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill2));
                        BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill2, list2, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);
                        break;
                    case 7:
                        BattleSystem.DelayInputAfter(this.Start4(newMokou));
                        break;
                    case 8:
                    case 9:
                        newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);
                        newMokou.BuffAdd("B_FMokou_Stage_2", newMokou);
                        newMokou.BuffAdd("B_FMokou_Stage_3", newMokou);

                        list.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill));
                        BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);
                        
                        list2.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill2));
                        BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill2, list2, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);
                        break;
                    case 10:
                        BattleSystem.DelayInputAfter(this.Start5(newMokou));
                        break;
                }

                if (BattleEvent_FMokou.xufuCount >= 2)
                {
                    BattleSystem.DelayInputAfter(this.Xufu(newMokou));
                }
            }
        }

        //复活对话处理
        public static IEnumerator Del()
        {
            BattleSystem.instance.AutoPosCalculate(0);
            
            yield break;
        }

        //第一阶段对话
        public IEnumerator Start2(BattleChar newMokou)
        {
            if (!newMokou)
            {
                yield break;
            }
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage1/Text1"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage1/Text2"), true, 0, 0f);

            MasterAudio.PlaySound("FMokou-S1", 1f, null, 0f, null, null, false, false);
            newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);

            List<BattleChar> list = new List<BattleChar>();
            Skill skill = Skill.TempSkill("S_FMokou_3", newMokou, newMokou.MyTeam);
            list.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);

            List<BattleChar> list2 = new List<BattleChar>();
            Skill skill2 = Skill.TempSkill("S_FMokou_4", newMokou, newMokou.MyTeam);
            list2.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill2));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill2, list2, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);

            yield break;
        }

        //第二阶段对话
        public IEnumerator Start3(BattleChar newMokou)
        {
            if (!newMokou)
            {
                yield break;
            }
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage2/Text1"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage2/Text2"), true, 0, 0f);

            MasterAudio.PlaySound("FMokou-S2", 1f, null, 0f, null, null, false, false);
            newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);
            newMokou.BuffAdd("B_FMokou_Stage_2", newMokou);

            BattleSystem.instance.Reward.Add(ItemBase.GetItem("Equip_FMokou_Spell"));

            List<BattleChar> list = new List<BattleChar>();
            Skill skill = Skill.TempSkill("S_FMokou_3", newMokou, newMokou.MyTeam);
            list.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);

            List<BattleChar> list2 = new List<BattleChar>();
            Skill skill2 = Skill.TempSkill("S_FMokou_4", newMokou, newMokou.MyTeam);
            list2.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill2));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill2, list2, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);

            yield break;
        }

        //第三阶段对话
        public IEnumerator Start4(BattleChar newMokou)
        {
            if (!newMokou)
            {
                yield break;
            }
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage3/Text1"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage3/Text2"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage3/Text3"), true, 0, 0f);

            MasterAudio.PlaySound("FMokou-S3", 1f, null, 0f, null, null, false, false);
            newMokou.BuffAdd("B_FMokou_Stage_1", newMokou);
            newMokou.BuffAdd("B_FMokou_Stage_2", newMokou);
            newMokou.BuffAdd("B_FMokou_Stage_3", newMokou);

            BattleSystem.instance.Reward.Add(ItemBase.GetItem("Item_FMokou_Revive"));

            List<BattleChar> list = new List<BattleChar>();
            Skill skill = Skill.TempSkill("S_FMokou_3", newMokou, newMokou.MyTeam);
            list.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);

            List<BattleChar> list2 = new List<BattleChar>();
            Skill skill2 = Skill.TempSkill("S_FMokou_4", newMokou, newMokou.MyTeam);
            list2.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill2));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill2, list2, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);

            yield break;
        }

        //第四阶段对话
        public IEnumerator Start5(BattleChar newMokou)
        {
            if (!newMokou)
            {
                yield break;
            }
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage4/Text1"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage4/Text2"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouStage4/Text3"), true, 0, 0f);

            MasterAudio.PlaySound("FMokou-S4", 1f, null, 0f, null, null, false, false);
            newMokou.BuffAdd("B_FMokou_Stage_4", newMokou);

            BattleSystem.instance.Reward.Add(ItemBase.GetItem("Skill_FMokou_Reward"));

            List<BattleChar> list = new List<BattleChar>();
            Skill skill = Skill.TempSkill("S_FMokou_3", newMokou, newMokou.MyTeam);
            list.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);

            List<BattleChar> list2 = new List<BattleChar>();
            Skill skill2 = Skill.TempSkill("S_FMokou_4", newMokou, newMokou.MyTeam);
            list2.AddRange((newMokou as BattleEnemy).Ai.TargetSelect(skill2));
            BattleSystem.instance.EnemyCastEnqueue(newMokou as BattleEnemy, skill2, list2, BattleSystem.instance.AllyTeam.TurnActionNum + 3, false);

            yield break;
        }

        //战斗结束对话
        public IEnumerator BattleEnd(BattleChar newMokou)
        {
            if (!newMokou)
            {
                yield break;
            }
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");

            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleEnd/Text1"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleEnd/Text2"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleEnd/Text3"), true, 0, 0f);
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouBattleEnd/Text4"), true, 0, 0f);

            newMokou.Dead();
            //newMokou.Damage(newMokou, newMokou.Info.get_stat.maxhp, true, true);

            yield break;
        }

        //触发徐福时空
        public IEnumerator Xufu(BattleChar newMokou)
        {
            if (!newMokou)
            {
                yield break;
            }
            yield return BattleText.InstBattleText_Co(newMokou, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouXufu/Text1"), true, 0, 0f);

            BattleEvent_FMokou.flameTimes--;
            Skill skill = Skill.TempSkill("S_FMokou_Xufu", newMokou, newMokou.MyTeam);
            this.BChar.ParticleOut(skill, newMokou);
            newMokou.BuffReturn("B_FMokou_P_0").SelfStackDestroy();
            BattleEvent_FMokou.xufuCount = 0;

            yield break;
        }

        //回合开始时，清空徐福时空计数
        public void Turn()
        {
            BattleEvent_FMokou.xufuCount = 0;
        }

        //受到“咒符「无差别放火之符」”的伤害时
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (SP.SkillData.MySkill.KeyID == "S_Mokou_7")
            {
                //BattleSystem.DelayInput(this.OnFire());
            }
        }

        //咒符「无差别放火之符」
        public IEnumerator OnFire()
        {
            if (!BattleEvent_FMokou.onFire)
            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouOnFire/Text1"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouOnFire/Text2"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FMokouOnFire/Text3"), true, 0, 0f);
                BattleEvent_FMokou.onFire = true;
            }

            Skill skill = Skill.TempSkill("S_FMokou_7", this.BChar, this.BChar.MyTeam);
            skill.NotCount = true;
            skill.AP = 0;
            skill.Counting = 1;
            yield return BattleSystem.instance.ForceAction(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);

            yield break;
        }

        //凤翼天翔
        
    }
}
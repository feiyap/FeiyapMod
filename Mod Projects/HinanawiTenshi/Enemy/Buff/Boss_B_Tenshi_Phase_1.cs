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
	/// 灵想「镇守大地之石」
	/// 回合开始时，自身获得5个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// 受到伤害时，将1个随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>转移至伤害来源。
	/// 当同时拥有20个<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>时，天子将发动「全人类的绯想天」，并进入天人姿态。
	/// </summary>
    public class Boss_B_Tenshi_Phase_1: Buff, IP_PlayerTurn, IP_Hit, IP_BuffAddAfter
    {
        public void Turn()
        {
            AddTenki(this.BChar, 5);
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg > 0)
            {
                string str = CheckTenki2();
                if (str != "")
                {
                    SP.SkillData.Master.BuffAdd(str, SP.SkillData.Master);
                }
            }
        }

        public string CheckTenki2()
        {
            foreach (String str in Boss_B_Tenshi_P.tenkiList)
            {
                if (this.BChar.BuffFind(str))
                {
                    this.BChar.BuffReturn(str).SelfDestroy();

                    return str;
                }
            }

            return "";
        }

        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            int count = 0;
            foreach (String str in Boss_B_Tenshi_P.tenkiList)
            {
                if (this.BChar.BuffFind(str))
                {
                    count++;
                }
            }
            if (count >= 20)
            {
                //进入惩罚阶段
                BattleSystem.DelayInput(this.Phase2());

                BattleEvent_Tenshi.MainP.Phase = 2;
                this.SelfDestroy();
                this.BChar.BuffAdd("Boss_B_Tenshi_Phase_2", this.BChar);

                foreach (String str in Boss_B_Tenshi_P.tenkiList)
                {
                    if (this.BChar.BuffFind(str))
                    {
                        this.BChar.BuffReturn(str).SelfDestroy();
                        this.BChar.BuffAdd(str, this.BChar, false, 0, false, 999);
                    }
                }
            }
        }

        public IEnumerator Phase2()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text1"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text2"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text3"), true, 0, 0f);
            }

            for (int i = 0; i < 99; i++)
            {
                this.BChar.BuffAdd(GDEItemKeys.Buff_B_Blockdebuff, this.BChar, true);
            }

            MasterAudio.PlaySound("S_Tenshi_Rare_4", 1f, null, 0f, null, null, false, false);

            BattleSystem.instance.Reward.Add(ItemBase.GetItem("E_Tenshi_0"));

            yield break;
        }

        public void AddTenki(BattleChar bc, int count = 0)
        {
            for (int i = 0; i < count; i++)
            {
                List<String> tempList = new List<string> { };
                foreach (String str in Boss_B_Tenshi_P.tenkiList)
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
    }
}
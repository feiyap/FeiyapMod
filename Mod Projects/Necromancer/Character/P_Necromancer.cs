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
using ChronoArkMod.ModData;
using TileTypes;
namespace Necromancer
{
    /// <summary>
    /// ???
    /// Passive:
    /// </summary>
    public class P_Necromancer:Passive_Char, IP_BattleStart_Ones, IP_SkillUse_BasicSkill, IP_DamageTake, IP_HPChange,IP_PlayerTurn
    {
        private GDEImageDatasData temp = new GDEImageDatasData("NecromancerImage");
        private bool aAndB = true;
        private bool flag = false;
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            aAndB = true;
            BChar.BuffAdd("B_Necromancer_9", BChar,false,800);
            flag = true;
        }

        private void InitBasicSkill()
        {
            Skill skill;
            /*
            if (aAndB)
            {
                skill = Skill.TempSkill("S_P_Necromancer_2", BChar, BChar.MyTeam);
            }
            else
            {
                skill = Skill.TempSkill("S_P_Necromancer_5", BChar, BChar.MyTeam);
            }
            */
            skill = Skill.TempSkill("S_P_Necromancer_2", BChar, BChar.MyTeam);
            (BChar as BattleAlly).MyBasicSkill.buttonData.NotAvailable = false;
            (BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
            (BChar as BattleAlly).MyBasicSkill.CoolDownNum = 0;
            (BChar as BattleAlly).MyBasicSkill.InActive = false;
            if ((BChar as BattleAlly).MyBasicSkill.buttonData.MySkill.KeyID == "S_P_Necromancer_2")
            {
                if (!aAndB)
                {
                    Skill skill1 = Skill.TempSkill("S_P_Necromancer_5", BChar, BChar.MyTeam);
                    (BChar as BattleAlly).MyBasicSkill.SkillInput(skill1);
                }
            }
            (BChar as BattleAlly).MyBasicSkill.CoolDownNum = 0;
            (BChar as BattleAlly).MyBasicSkill.InActive = false;

        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (NODEF == true && Dmg > 0 && !BChar.BuffFind("B_Necromancer_1"))
            {
                BChar.BuffAdd("B_Necromancer_0", BChar);
            }
            if (BChar.BuffFind("B_Necromancer_0"))
            {
                if (BChar.BuffReturn("B_Necromancer_0").StackNum >= 3)
                {
                    EnterFroge();
                }
            }
        }
        public override void FixedUpdate()
        {
            try
            {
                if (BChar.BuffFind("B_Necromancer_1"))
                {
                    (BChar as BattleAlly).MyBasicSkill.buttonData.NotAvailable = false;
                }
                else
                {
                    (BChar as BattleAlly).MyBasicSkill.buttonData.NotAvailable = true;
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }

        private void EnterFroge()
        {
            //BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), ""));
            if (BChar.Info.KeyData == ModItemKeys.Character_Necromancer)
            {
                AddressableLoadManager.LoadAsyncAction(temp.Sprites_Path[3], AddressableLoadManager.ManageType.Character, BChar.UI.CharImage.GetComponent<Image>());
            }
            if (BChar.HP > 0)
            {
                System.Random random = new System.Random();
                switch (random.Next(0, 3))
                {
                    case 0:
                        //BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), "我亲手把腿骨插进了自己的脊椎中，这一切…只为了…"));
                        BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_P_1")));
                        break;
                    case 1:
                        //BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), "在这黑暗之中等待你我的只有无尽的苦痛。"));
                        BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_P_2")));
                        break;
                    default:
                        break;
                }
                //BattleSystem.DelayInputAfter(this.Draw());
            }
            if (BChar.BuffFind("B_Necromancer_9"))
            {
                (BChar.BuffReturn("B_Necromancer_9") as B_Necromancer_9).EnterFroge();
            }
            BChar.BuffAdd("B_Necromancer_1", BChar);
            BChar.BuffAdd("B_Necromancer_2", BChar);
            if ((BChar as BattleAlly).MyBasicSkill.buttonData.MySkill.KeyID == "S_P_Necromancer_2")
            {
                if (!aAndB)
                {
                    Skill skill = Skill.TempSkill("S_P_Necromancer_5", BChar, BChar.MyTeam);
                    (BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
                }
            }
            aAndB = !aAndB;
            (BChar as BattleAlly).MyBasicSkill.CoolDownNum = 0;
            (BChar as BattleAlly).MyBasicSkill.InActive = false;

            //AddressableLoadManager.LoadAsyncAction(temp.Sprites_Path[0], AddressableLoadManager.ManageType.Character, BuffIconScript.Icon);
        }

        public void SkillUseBasicSkill(Skill skill)
        {
            if (skill.Master != BChar)
            {
                return;
            }
            InitBasicSkill();
            if (BChar.Info.KeyData == ModItemKeys.Character_Necromancer)
            {
                AddressableLoadManager.LoadAsyncAction(temp.Sprites_Path[1], AddressableLoadManager.ManageType.Character, BChar.UI.CharImage.GetComponent<Image>());
            }
            System.Random random = new System.Random();
            switch (random.Next(0, 3))
            {
                case 0:
                    //BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), "所求之物……"));
                    BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_P_3")));
                    break;
                case 1:
                    //BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), "我…这么多年以来，什么…都没有做到……"));
                    BattleSystem.instance.StartCoroutine(BattleText.InstBattleTextAlly_Co(this.BChar.GetTopPos(), ModManager.getModInfo("Necromancer").localizationInfo.SystemLocalizationUpdate("B_Necromancer_P_4")));
                    break;
                default:
                    break;
            }
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (!Healed && BChar.HP <= 0)
            {
                EnterFroge();
            }
        }
        public IEnumerator Draw()
        {
            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => skill.Master == BChar);
            if (skill2 == null)
            {
                skill2 = BattleSystem.instance.AllyTeam.Skills_UsedDeck.Find((Skill skill) => skill.Master == BChar);
            }
            if (skill2 != null)
            {
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
            }
            yield return null;
            yield break;
        }

        public void Turn()
        {
            if (! flag)
            {
                return;
            }
            flag = false;
            BChar.BuffAdd("B_Necromancer_4", BChar, false, 0, false, 2);
            BChar.BuffAdd("B_Necromancer_4", BChar, false, 0, false, 2);
            BChar.BuffAdd("B_Necromancer_4", BChar, false, 0, false, 2);
        }
        /*
public void SKillUseHand_Team(Skill skill)
{
   if (skill.IsHeal)
   {
       if (!BChar.BuffFind("B_Necromancer_4") || BChar.BuffReturn("B_Necromancer_4").StackNum < 3)
           BChar.BuffAdd("B_Necromancer_4", BChar);
   }
}
*/
    }
}
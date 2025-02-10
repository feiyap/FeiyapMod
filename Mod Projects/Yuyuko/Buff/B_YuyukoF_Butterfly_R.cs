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
namespace Yuyuko
{
	/// <summary>
	/// <color=#FF69B4>人魂蝶</color>
	/// &effect
	/// </summary>
    public class B_YuyukoF_Butterfly_R:Buff
    {
        public int effect = 0;

        public override void Init()
        {
            base.Init();

            this.PlusStat.IgnoreTaunt_EnemySelf = false;
            if (effect == 0)
            {
                this.PlusStat.IgnoreTaunt_EnemySelf = true;
            }
        }

        public void ButterflyChange()
        {
            string key = BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_R;

            if (key == "S_YuyukoF_Rare_1")
            {
                effect = 10;
            }
            // 提取字符串末尾的数字
            else if (int.TryParse(key.Substring(key.Length - 1), out int effect))
            {
                // effect 已经被赋值为对应的值
            }
            else
            {
                // 处理未找到的情况
                effect = -1; // 或者其他默认值
            }

            //switch (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M)
            //{
            //    case "S_YuyukoF_0":
            //        {
            //            effect = 0;
            //        }
            //        break;
            //    case "S_YuyukoF_1":
            //        {
            //            effect = 1;
            //        }
            //        break;
            //}
        }

        public void Awake()
        {
            if (effect == 2)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().ghost += 8;
            }
            if (effect == 3)
            {
                List<Skill> list = new List<Skill>();
                list.AddRange(BattleSystem.instance.AllyTeam.Skills);

                BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true);
            }
            if (effect == 7)
            {
                BattleSystem.instance.AllyTeam.AP++;
            }
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Except();
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            if (effect == 2)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().ghost += 8;
            }
            if (effect == 5)
            {
                this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_Rest, this.Usestate_F, false, 100);
            }
            if (effect == 6)
            {
                Skill tmpSkill = Skill.TempSkill("S_YuyukoF_6", this.Usestate_F, this.Usestate_F.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (effect == 1)
            {
                if (!NODEF)
                {
                    BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, Dmg, this.Usestate_F);
                    return 0;
                }
            }

            return Dmg;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&effect", ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate(BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_R + "_2/Text"));
        }
    }
}
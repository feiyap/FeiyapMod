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
	/// <color=#4876FF>幽冥蝶</color>
	/// &effect
	/// </summary>
    public class B_YuyukoF_Butterfly_M:Buff, IP_ButterflyChange, IP_DamageTakeChange, IP_Awake, IP_ButterflyReturn
    {
        public int effect = -1;

        public override void Init()
        {
            base.Init();
        }

        public void ButterflyChange()
        {
            string key = BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M;

            if (key == "S_YuyukoF_Rare_1")
            {
                effect = 10;
            }
            // 提取字符串末尾的数字
            else if (int.TryParse(key.Substring(key.Length - 1), out int xx))
            {
                // effect 已经被赋值为对应的值
                effect = xx;
            }
            else
            {
                // 处理未找到的情况
                effect = -1; // 或者其他默认值
            }
            
            if (effect == 2)
            {
                P_YuyukoF.DeadRevive(this.Usestate_F, 1);
            }
            if (effect == 3)
            {
                List<Skill> list = new List<Skill>();
                list.AddRange(BattleSystem.instance.AllyTeam.Skills);

                BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
            }
            if (effect == 5)
            {
                P_YuyukoF.DeadRevive(this.Usestate_F, 2);
            }
            if (effect == 7)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
        }

        public void Awake()
        {
            
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Except();
            this.Usestate_F.MyTeam.Draw();
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
        }

        public void ButterflyReturn()
        {
            if (effect == 2)
            {
                P_YuyukoF.DeadRevive(this.Usestate_F, 1);
            }
            if (effect == 4)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, (int)(this.Usestate_F.GetStat.atk * 1.21f), this.Usestate_F);
            }
            if (effect == 6)
            {
                Skill tmpSkill = Skill.TempSkill("S_YuyukoF_6", this.Usestate_F, this.Usestate_F.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }

            this.SelfDestroy();
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M = "";
        }

        public override void TurnUpdate()
        {
            base.TurnUpdate();

            if (effect == 0)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, this.BChar.Info.OriginStat.maxhp * 10 / 100, this.Usestate_F);
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (effect == 1)
            {
                if (!NODEF && !Preview)
                {
                    BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, Dmg, this.Usestate_F);
                    return 0;
                }
            }

            return Dmg;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&effect", ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate(BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M + "_1/Text"))
                                      .Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1.21f)).ToString())
                                      .Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}
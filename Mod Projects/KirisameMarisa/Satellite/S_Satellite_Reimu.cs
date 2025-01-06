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
namespace KirisameMarisa
{
	/// <summary>
	/// 超时空「我们的幻想乡！」
	/// *「梦想天生」+星符「Satellite Illusion」*
	/// 从正在开启的所有《东方project》系列的mod角色的稀有技能中，随机生成1个，并为其选择持有者。
	/// 重复释放，直到手牌达到上限为止。
	/// </summary>
    public class S_Satellite_Reimu:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("S_Satellite_Reimu", 1f, null, 0f, null, null, false, false);

            List<GDESkillData> list = new List<GDESkillData>();
            using (List<GDESkillData>.Enumerator enumerator = PlayData.ALLRARESKILLLIST.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    GDESkillData i = enumerator.Current;
                    if (TouhouChara.Find((string a) => a == i.User) != null && i.Category.Key != GDEItemKeys.SkillCategory_LucySkill && i.Category.Key != GDEItemKeys.SkillCategory_DefultSkill && !i.NoDrop && !i.Lock)
                    {
                        list.Add(i);
                    }
                }
            }

            for (int i = 0; i < 10 - BattleSystem.instance.AllyTeam.Skills.Count; i++)
            {
                List<Skill> list2 = new List<Skill>();
                GDESkillData tempGDE = list.Random(this.BChar.GetRandomClass().Main);
                foreach (BattleChar battleChar in this.BChar.MyTeam.AliveChars)
                {
                    Skill item = Skill.TempSkill(tempGDE.KeyID, battleChar, battleChar.MyTeam);
                    list2.Add(item);
                }

                BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list2, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Master.MyTeam.Add(Mybutton.Myskill, true);
        }

        public static List<string> TouhouChara = new List<string>
        {
            "HakureiReimu",
            "RemiliaScarlet",
            "IzayoiSakuya",
            "SatsukiRin",
            "FlandreScarlet",
            "Reisen",
            "Eirin",
            "HouraisanKaguya",
            "Inaba",
            "KochiyaSanae",
            "ShameimaruAya",
            "YasakaKanano",
            "MoriyaSuwako",
            "Sunmeitian",
            "Mokou",
            "Youmu",
            "Cirno",
            "Daiyousei",
            "HoanMeirin",
            "TouhouAlice",
            "Kogasa",
            "Qinxin",
            "CuteDog",
            "Kasen",
            "Utuho",
            "Rin",
            "Touhou_LilyWhite",
            "Touhou_LilyBlack",
            "Kurumi",
            "Marisa",
            "Patchouli",
            "Koishi"
        };
    }
}
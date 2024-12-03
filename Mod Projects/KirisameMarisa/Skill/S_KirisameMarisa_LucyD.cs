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
	/// 魔废「Deep Ecological Bomb」
	/// 抽取1个技能。依据当前速度：
	/// 大于0：额外抽取1个技能，恢复1点法力值。
	/// 等于0：额外抽取1个技能。
	/// 小于0：恢复3点法力值。
	/// </summary>
    public class S_KirisameMarisa_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            List<string> list = new List<string>();
            GDEDataManager.GetAllDataKeysBySchema(GDESchemaKeys.Buff, out list);
            int buffcount = 0;
            for (int i = 0; i < 200; i++)
            {
                GDEBuffData gdebuffData = new GDEBuffData(RandomManager.Random<string>(list, BattleRandom.GetRandomClass(this.BChar).Main));
                bool flag = !gdebuffData.Hide && gdebuffData.Debuff && gdebuffData.LifeTime > 0;
                if (flag)
                {
                    Targets[0].BuffAdd(gdebuffData.Key, BattleSystem.instance.AllyList[0], false, 120, false, -1, false);
                    buffcount++;
                    if (buffcount >= 2)
                    {
                        break;
                    }
                }
            }
        }
    }
}
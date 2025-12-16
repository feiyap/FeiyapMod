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
namespace Morichika
{
    /// <summary>
    /// 常客
    /// 每次从&user处获得增益时，都会额外获得 1 个随机增益效果（不会出现持续时间为∞的增益）。
    /// </summary>
    public class B_Morichika_Rare_2 : Buff, IP_BuffAdd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffUser == this.Usestate_F && BuffTaker == this.BChar && addedbuff.BuffData.Key == "B_Morichika_P")
            {
                List<string> list = new List<string>();
                GDEDataManager.GetAllDataKeysBySchema(GDESchemaKeys.Buff, out list);
                for (int i = 0; i < 200; i++)
                {
                    GDEBuffData gdebuffData = new GDEBuffData(RandomManager.Random<string>(list, BattleRandom.GetRandomClass(this.BChar).Main));
                    bool flag = !gdebuffData.Hide && !gdebuffData.Debuff && gdebuffData.LifeTime > 0;
                    if (flag)
                    {
                        this.BChar.BuffAdd(gdebuffData.Key, this.BChar, false, 120, false, -1, false);
                        break;
                    }
                }
            }
        }

        public override string DescExtended()
        {
            string username = "";

            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&user", username);
        }
    }
}
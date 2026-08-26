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

namespace Snake
{
    /// <summary>
    /// 贪吃蛇硬币
    /// 使用后打开一局贪吃蛇游戏。游戏结束后，获得“得分 x 100”的金币。
    /// </summary>
    public class Item_Snake : UseitemBase
    {
        public override bool Use()
        {
            if (SnakeGameUI.IsOpen)
            {
                return false;
            }

            return SnakeGameUI.Open();
        }
    }
}

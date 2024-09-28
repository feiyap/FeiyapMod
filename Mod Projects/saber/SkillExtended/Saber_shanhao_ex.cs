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
namespace saber
{
    public class Saber_shanhao_ex:Skill_Extended,IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public void Turn() 
        {
         
        }
        public override bool Terms()
        {
            return this.Flag;
        }
        public void TurnEnd()
        {
            this.Flag = false;
        }
        public bool Flag;
    }
}
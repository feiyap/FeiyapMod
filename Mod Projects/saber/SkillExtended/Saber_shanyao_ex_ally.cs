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
    public class Saber_shanyao_ex_ally : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            BuffTag buffTag = new BuffTag();
            buffTag.BuffData = new GDEBuffData(ModItemKeys.Buff_Saber_xingguang_A);
            buffTag.User = this.BChar;
            this.TargetBuff = new List<BuffTag>();
            this.TargetBuff.Add(buffTag);             
        }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal) 
        {
            this.BChar.BuffAdd(ModItemKeys.Buff_Saber_jinsheng, this.BChar, false, 0, false, -1, false);
        }
    }
}
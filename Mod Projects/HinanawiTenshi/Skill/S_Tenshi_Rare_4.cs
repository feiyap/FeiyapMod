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
	/// ＊大气圈尽在吾之手中＊
	/// <color=#97FFFF>天启10</color> - 获得所有天气增益，并且天气增益持续时间变为永久。
	/// <color=#696969><i>在第一颗星的下方，神给予了无二的启示。
	/// 面对再三再四造下罪业的人类， 要予以宽恕而非制裁。
	/// 她颔首，并向神发誓将献上自己的五识。
	/// 这个世界是神所创造出的巨大双六棋盘，而她是背负着七丈光芒的一颗渺小棋子。
	/// 当八灾与试炼降临之际，闪烁的九曜星将予以指引，
	/// 克服旅途中的一切苦难后，她最终可得十全之权能。</i></color>
	/// </summary>
    public class S_Tenshi_Rare_4: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(10, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckKishi(10, false))
            {
                BattleSystem.DelayInputAfter(this.Del());
            }
        }

        public IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();

            yield return this.TalkEnd();

            yield break;
        }

        public IEnumerator TalkEnd()
        {
            yield return new WaitForFixedUpdate();

            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("S_Tenshi_Rare_4", 1f, null, 0f, null, null, false, false);

            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text1"), false);
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text2"), false);
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("HinanawiTenshi").localizationInfo.SystemLocalizationUpdate("BattleDia/S_Tenshi_Rare_4/Text3"), false);

            foreach (String str in tenkiList)
            {
                yield return this.BChar.BuffAdd(str, this.BChar, false, 0, false, 99);
            }
            
            yield break;
        }
    }
}
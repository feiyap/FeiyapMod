using System;
using System.Collections.Generic;
using ChronoArkMod.ModData;
using ChronoArkMod.Template;

namespace HakureiReimu
{
    public class ReimuCharacter : CustomCharacterGDE<ReimuDialogue_Def>
    {
        public override ModGDEInfo.LoadingType GetLoadingType()
        {
            return 0;
        }

        public override void SetValue()
        {
            base.Dialogue_NomalGiftTalk = Dia_Normal.DialogueTreePath_Gift_Normal;
            base.Dialogue_GoodGiftTalks = new List<string>
            {
                Dia_Sake.DialogueTreePath_Gift_Sake,
                Dia_Cake.DialogueTreePath_Gift_Cake,
                Dia_FishingRod.DialogueTreePath_Gift_FishingRod,
                Dia_Mugwort.DialogueTreePath_Gift_Mugwort
            };
            base.Dialogue_FriendShipLVTalks = new List<string>
            {
                Dia_Reimu_Lv1.DialogueTreePath_Reimu_Lv1,
                Dia_Reimu_Lv2.DialogueTreePath_Reimu_Lv2,
                Dia_Reimu_Lv3.DialogueTreePath_Reimu_Lv3
            };
        }

        public override string Key()
        {
            return "HakureiReimu";
        }
    }
}

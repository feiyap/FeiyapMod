using System;
using System.Collections.Generic;
using ChronoArkMod.ModData;
using ChronoArkMod.Template;

namespace KirisameMarisa
{
    public class MarisaCharacter : CustomCharacterGDE<MarisaDialogue_Def>
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
                Dia_DVD.DialogueTreePath_Gift_DVD,
                Dia_Gun.DialogueTreePath_Gift_Gun,
                Dia_Mugwort.DialogueTreePath_Gift_Mugwort
            };
            base.Dialogue_FriendShipLVTalks = new List<string>
            {
                Dia_Marisa_Lv1.DialogueTreePath_Marisa_Lv1,
                Dia_Marisa_Lv2.DialogueTreePath_Marisa_Lv2,
                Dia_Marisa_Lv3.DialogueTreePath_Marisa_Lv3
            };
        }

        public override string Key()
        {
            return "KirisameMarisa";
        }
    }
}

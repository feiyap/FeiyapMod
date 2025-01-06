using System;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace KirisameMarisa
{
    public class Dia_Normal
    {
        public static string DialogueTreePath_Gift_Normal
        {
            get
            {
                if (Extensions.IsNullOrEmpty(Dia_Normal._DialogueTreePath_Normal))
                {
                    ModInfo modInfo = ModManager.getModInfo("KirisameMarisa");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_Normal.Gift_Normal>();
                    Dia_Normal._DialogueTreePath_Normal = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_Normal._DialogueTreePath_Normal;
            }
        }

        public static string _DialogueTreePath_Normal;

        public class Gift_Normal : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Normal.Gift_Normal_Node_1);
                }
            }

            public override DialogueParameter SetDialogueParameter(GameObject gameObject)
            {
                return new DialogueParameter
                {
                    AutoPlay = true,
                    UIOffDialogue = true,
                    StoryDialogue = true
                };
            }
        }

        public class Gift_Normal_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_Normal/001"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Mairsa_Shock.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Normal.Gift_Normal_Node_2);
                }
            }
        }

        public class Gift_Normal_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_Normal/002"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Normal.Gift_Normal_Node_3);
                }
            }
        }

        public class Gift_Normal_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_Normal/003"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_RedSmallHappy.png")
                };
            }
        }
    }
}

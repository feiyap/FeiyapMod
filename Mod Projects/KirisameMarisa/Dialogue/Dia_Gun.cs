using System;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace KirisameMarisa
{
    public class Dia_Gun
    {
        public static string DialogueTreePath_Gift_Gun
        {
            get
            {
                bool flag = Extensions.IsNullOrEmpty(Dia_Gun._DialogueTreePath_Gun);
                if (flag)
                {
                    ModInfo modInfo = ModManager.getModInfo("KirisameMarisa");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_Gun.Gift_Gun>();
                    Dia_Gun._DialogueTreePath_Gun = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_Gun._DialogueTreePath_Gun;
            }
        }

        public static string _DialogueTreePath_Gun;

        public class Gift_Gun : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Gun.Gift_Gun_Node_1);
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

        public class Gift_Gun_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_Gun/001"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Mairsa_Shock.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Gun.Gift_Gun_Node_2);
                }
            }
        }

        public class Gift_Gun_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_Gun/002"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Gun.Gift_Gun_Node_3);
                }
            }
        }

        public class Gift_Gun_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_Gun/003"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Gun.Gift_Gun_Node_4);
                }
            }
        }

        public class Gift_Gun_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_Gun/004"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }
        }
    }
}

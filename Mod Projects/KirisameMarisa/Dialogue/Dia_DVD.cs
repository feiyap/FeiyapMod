using System;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace KirisameMarisa
{
    public class Dia_DVD
    {
        public static string DialogueTreePath_Gift_DVD
        {
            get
            {
                bool flag = Extensions.IsNullOrEmpty(Dia_DVD._DialogueTreePath_DVD);
                if (flag)
                {
                    ModInfo modInfo = ModManager.getModInfo("KirisameMarisa");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_DVD.Gift_DVD>();
                    Dia_DVD._DialogueTreePath_DVD = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_DVD._DialogueTreePath_DVD;
            }
        }

        public static string _DialogueTreePath_DVD;

        public class Gift_DVD : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_DVD.Gift_DVD_Node_1);
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

        public class Gift_DVD_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_DVD/001"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_DVD.Gift_DVD_Node_2);
                }
            }
        }

        public class Gift_DVD_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_DVD/002"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Happy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_DVD.Gift_DVD_Node_3);
                }
            }
        }

        public class Gift_DVD_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_DVD/003"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Han.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_DVD.Gift_DVD_Node_4);
                }
            }
        }

        public class Gift_DVD_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Gift_DVD/004"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }
        }
    }
}

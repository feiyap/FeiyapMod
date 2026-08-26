using System;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace HakureiReimu
{
    public class Dia_City
    {
        public static string DialogueTreePath_HakureiReimu_Ark
        {
            get
            {
                if (Extensions.IsNullOrEmpty(Dia_City._DialogueTreePath_HakureiReimu_Ark))
                {
                    ModInfo modInfo = ModManager.getModInfo("HakureiReimu");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_City.HakureiReimu_Ark>();
                    Dia_City._DialogueTreePath_HakureiReimu_Ark = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_City._DialogueTreePath_HakureiReimu_Ark;
            }
        }

        public static string _DialogueTreePath_HakureiReimu_Ark;

        public class HakureiReimu_Ark : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.HakureiReimu_Ark_Node_1);
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

        public class HakureiReimu_Ark_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/HakureiReimu_Ark/001"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.HakureiReimu_Ark_Node_2);
                }
            }
        }

        public class HakureiReimu_Ark_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/HakureiReimu_Ark/002"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.HakureiReimu_Ark_Node_3);
                }
            }
        }

        public class HakureiReimu_Ark_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/HakureiReimu_Ark/003"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Happy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.HakureiReimu_Ark_Node_4);
                }
            }
        }

        public class HakureiReimu_Ark_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/HakureiReimu_Ark/004"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.HakureiReimu_Ark_Node_5);
                }
            }
        }

        public class HakureiReimu_Ark_Node_5 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/HakureiReimu_Ark/005"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Smile.png")
                };
            }
        }
    }
}

using System;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace HakureiReimu
{
    public class Dia_Sake
    {
        public static string DialogueTreePath_Gift_Sake
        {
            get
            {
                bool flag = Extensions.IsNullOrEmpty(Dia_Sake._DialogueTreePath_Sake);
                if (flag)
                {
                    ModInfo modInfo = ModManager.getModInfo("HakureiReimu");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_Sake.Gift_Sake>();
                    Dia_Sake._DialogueTreePath_Sake = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_Sake._DialogueTreePath_Sake;
            }
        }

        public static string _DialogueTreePath_Sake;

        public class Gift_Sake : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Sake.Gift_Sake_Node_1);
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

        public class Gift_Sake_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Gift_Sake/001"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Sake.Gift_Sake_Node_2);
                }
            }
        }

        public class Gift_Sake_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Gift_Sake/002"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Happy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Sake.Gift_Sake_Node_3);
                }
            }
        }

        public class Gift_Sake_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Gift_Sake/003"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Sake.Gift_Sake_Node_4);
                }
            }
        }
        
        public class Gift_Sake_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("HakureiReimu").localizationInfo.DialogueLocalizeUpdate("Dialogue/Reimu_Gift_Sake/004"),
                    Standing_Path = ModManager.getModInfo("HakureiReimu").assetInfo.ImageFromAsset("reimu_character", "Assets/HakureiReimu/Reimu_Happy.png")
                };
            }
        }
    }
}

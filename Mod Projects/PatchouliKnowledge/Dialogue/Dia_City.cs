using System;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace PatchouliKnowledge
{
    public class Dia_City
    {
        public static string DialogueTreePath_Patchouli_Ark
        {
            get
            {
                if (Extensions.IsNullOrEmpty(Dia_City._DialogueTreePath_Patchouli_Ark))
                {
                    ModInfo modInfo = ModManager.getModInfo("PatchouliKnowledge");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_City.Patchouli_Ark>();
                    Dia_City._DialogueTreePath_Patchouli_Ark = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_City._DialogueTreePath_Patchouli_Ark;
            }
        }

        public static string _DialogueTreePath_Patchouli_Ark;

        public class Patchouli_Ark : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.Patchouli_Ark_Node_1);
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

        public class Patchouli_Ark_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("PatchouliKnowledge").localizationInfo.DialogueLocalizeUpdate("Dialogue/Patchouli_Ark/001"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.Patchouli_Ark_Node_2);
                }
            }
        }

        public class Patchouli_Ark_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("PatchouliKnowledge").localizationInfo.DialogueLocalizeUpdate("Dialogue/Patchouli_Ark/002"),
                    Standing_Path = ModManager.getModInfo("PatchouliKnowledge").assetInfo.ImageFromAsset("patchoulispine", "Assets/Patchouli/Standing/Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.Patchouli_Ark_Node_3);
                }
            }
        }

        public class Patchouli_Ark_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("PatchouliKnowledge").localizationInfo.DialogueLocalizeUpdate("Dialogue/Patchouli_Ark/003"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_City.Patchouli_Ark_Node_4);
                }
            }
        }

        public class Patchouli_Ark_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("PatchouliKnowledge").localizationInfo.DialogueLocalizeUpdate("Dialogue/Patchouli_Ark/004"),
                    Standing_Path = ModManager.getModInfo("PatchouliKnowledge").assetInfo.ImageFromAsset("patchoulispine", "Assets/Patchouli/Standing/Normal.png")
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using ChronoArkMod;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using Dialogical;
using UnityEngine;

namespace KirisameMarisa
{
    public class Dia_Marisa_Lv1
    {
        public static string DialogueTreePath_Marisa_Lv1
        {
            get
            {
                bool flag = Extensions.IsNullOrEmpty(Dia_Marisa_Lv1._DialogueTreePath_Marisa_Lv1);
                if (flag)
                {
                    ModInfo modInfo = ModManager.getModInfo("KirisameMarisa");
                    DialogueTree dialogueTree = DialogueCreator.CreateDialogueTree<Dia_Marisa_Lv1.Marisa_Lv1>();
                    Dia_Marisa_Lv1._DialogueTreePath_Marisa_Lv1 = modInfo.assetInfo.ConstructObjectByCode<DialogueTree>(dialogueTree);
                }
                return Dia_Marisa_Lv1._DialogueTreePath_Marisa_Lv1;
            }
        }

        public static string _DialogueTreePath_Marisa_Lv1;

        public class Marisa_Lv1 : DialogueCreator
        {
            public override Type FirstNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_1);
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

        public class Marisa_Lv1_Node_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/001"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_2);
                }
            }
        }

        public class Marisa_Lv1_Node_2 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/002"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_3);
                }
            }
        }

        public class Marisa_Lv1_Node_3 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/003"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_4);
                }
            }
        }

        public class Marisa_Lv1_Node_4 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/004"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_5);
                }
            }
        }

        public class Marisa_Lv1_Node_5 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/005"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Smile.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_6);
                }
            }
        }

        public class Marisa_Lv1_Node_6 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/006"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_7);
                }
            }
        }

        public class Marisa_Lv1_Node_7 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/007"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Happy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_8);
                }
            }
        }

        public class Marisa_Lv1_Node_8 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/008"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_9);
                }
            }
        }

        public class Marisa_Lv1_Node_9 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/009"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_10);
                }
            }
        }

        public class Marisa_Lv1_Node_10 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/010"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Normal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_11);
                }
            }
        }

        public class Marisa_Lv1_Node_11 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/011"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_12);
                }
            }
        }

        public class Marisa_Lv1_Node_12 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/012"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override IEnumerable<Type> OptionCreatorTypes
            {
                get
                {
                    return new List<Type>
                    {
                        typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_12_1),
                        typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_12_2)
                    };
                }
            }
        }

        public class Marisa_Lv1_Node_12_1 : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/012_Option1")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_12_1_1);
                }
            }
        }

        public class Marisa_Lv1_Node_12_1_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/012_1_1"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_13);
                }
            }
        }

        public class Marisa_Lv1_Node_12_2 : DialogueNodeOptionCreator
        {
            public override DialogueNodeOptionParameter SetDialogueNodeOptionParameter()
            {
                return new DialogueNodeOptionParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/012_Option2")
                };
            }

            public override Type TargetDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_12_2_1);
                }
            }
        }

        public class Marisa_Lv1_Node_12_2_1 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/012_2_1"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_Emm.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_13);
                }
            }
        }

        public class Marisa_Lv1_Node_13 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/013"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_14);
                }
            }
        }

        public class Marisa_Lv1_Node_14 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/014"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_15);
                }
            }
        }

        public class Marisa_Lv1_Node_15 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/015"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_16);
                }
            }
        }

        public class Marisa_Lv1_Node_16 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/016"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_17);
                }
            }
        }

        public class Marisa_Lv1_Node_17 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/017"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_RedNormal.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_18);
                }
            }
        }

        public class Marisa_Lv1_Node_18 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/018"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_19);
                }
            }
        }

        public class Marisa_Lv1_Node_19 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/019"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_RedHurt.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_20);
                }
            }
        }

        public class Marisa_Lv1_Node_20 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/020"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_21);
                }
            }
        }

        public class Marisa_Lv1_Node_21 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/021"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Mairsa_RedSmallHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_22);
                }
            }
        }

        public class Marisa_Lv1_Node_22 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/022"),
                    Standing_Path = ""
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_23);
                }
            }
        }

        public class Marisa_Lv1_Node_23 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/023"),
                    Standing_Path = ModManager.getModInfo("KirisameMarisa").assetInfo.ImageFromAsset("marisa_character", "Assets/KirisameMarisa/Marisa_BigHappy.png")
                };
            }

            public override Type NextDialogueNodeCreatorType
            {
                get
                {
                    return typeof(Dia_Marisa_Lv1.Marisa_Lv1_Node_24);
                }
            }
        }

        public class Marisa_Lv1_Node_24 : DialogueNodeCreator
        {
            public override DialogueNodeParameter SetDialogueNodeParameter()
            {
                return new DialogueNodeParameter
                {
                    Text = ModManager.getModInfo("KirisameMarisa").localizationInfo.DialogueLocalizeUpdate("Dialogue/Marisa_Lv1/024"),
                    Standing_Path = ""
                };
            }
        }
    }
}

using System;
using ChronoArkMod;
using ChronoArkMod.ModData;

namespace BossPhoenix
{
    public class BossPhoenix_ModDefinition : ModDefinition
    {
        public override Type ModItemKeysType
        {
            get
            {
                return typeof(ModItemKeys);
            }
        }
    }
}

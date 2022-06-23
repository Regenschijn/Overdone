using IL.Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Norse {
    public class VikingShield1 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Set's Was Septre" );
            Tooltip.SetDefault( "LMB: melee boink. RMB: Heavy havoc" );
        }

        public override void SetDefaults() {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
        }
       
        

    }
}

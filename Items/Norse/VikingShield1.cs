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
            item.width = 30;
            item.height = 32;
            item.accessory = true;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
        }
       
        

    }
}

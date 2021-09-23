using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Overdone.Buffs {
    class IrishFierceness : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault( "Irish Fierceness" );
            Description.SetDefault( "Deal 10% more damage" );
            canBeCleared = true;
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;

        }

        public override void Update( Player player, ref int buffIndex ) {
            player.allDamage += 0.2f;
        }
    }
}

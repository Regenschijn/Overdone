using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;

namespace Overdone.Buffs {
    class IrishFierceness : ModBuff {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Irish Fierceness" );
            Description.SetDefault( "Deal 20% more damage" );
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update( Player player, ref int buffIndex ) {
            player.GetDamage(DamageClass.Generic) += 0.2f;
        }
    }
}

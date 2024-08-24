using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Overdone.NPCs;
using Overdone.Players;

namespace Overdone.Buffs {
    public class Doom : ModBuff {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "Doom" );
            // Description.SetDefault( "You are marked for death" );

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
        }

        public override void Update( NPC npc, ref int buffIndex ) {
            if ( npc.HasBuff( Type ) ) {
                npc.GetGlobalNPC<OverdoneGlobalNPC>().doom = true;
            }
            if ( npc.GetGlobalNPC<OverdoneGlobalNPC>().doom && npc.buffTime[buffIndex] % 600 == 0 ) {
                npc.StrikeNPC( 50, 0f, 0, false, false, false );
            }
        }

        public override void Update( Player player, ref int buffIndex ) {
            if ( player.HasBuff( Type ) ) {
                player.GetModPlayer<OverdonePlayer>().doom = true;
            }
            if ( player.GetModPlayer<OverdonePlayer>().doom && player.buffTime[buffIndex] % 600 == 0 ) {
                player.statLife -= 50;
            }
        }

    }
}
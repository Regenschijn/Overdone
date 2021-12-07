using Terraria;
using Terraria.ModLoader;

namespace Overdone.Buffs
{
    public class ChariotMount : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Chariot");
            Description.SetDefault("Ride to your glory or doom!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.mount.SetMount(ModContent.MountType<Mounts.Chariot>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}
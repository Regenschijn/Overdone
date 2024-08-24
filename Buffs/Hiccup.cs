using Terraria;
using Terraria.ModLoader;

namespace Overdone.Buffs
{
    public class Hiccup : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hiccup");
            // Description.SetDefault("Your hiccups cause you to stumble.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (Main.rand.Next(180, 300) == 1) // 3 to 5 seconds between hiccups
            {
                npc.velocity.X += Main.rand.NextFloat(-2f, 2f); // random knockback in X direction
                npc.velocity.Y -= Main.rand.NextFloat(1f, 3f); // random knockback in Y direction
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.Next(180, 300) == 1) // 3 to 5 seconds between hiccups
            {
                player.velocity.X += Main.rand.NextFloat(-2f, 2f); // random knockback in X direction
                player.velocity.Y -= Main.rand.NextFloat(1f, 3f); // random knockback in Y direction
            }
        }
    }
}

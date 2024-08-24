using Overdone.Mounts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Chariots
{
    public class Chariot1 : ModItem
    {
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("This is a chariot.");
        }

        public override void SetDefaults() {
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 30000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item79;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<Chariot>();
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }
    }
}
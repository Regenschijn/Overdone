using Overdone.Mounts;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Chariots
{
    public class Chariot1 : ModItem
    {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("This is a chariot.");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 30000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item79;
            item.noMelee = true;
            item.mountType = ModContent.MountType<Chariot>();
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }
    }
}
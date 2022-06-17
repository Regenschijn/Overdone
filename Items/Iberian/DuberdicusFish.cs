using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Iberian {
    public class DuberdicusFish : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Leavings of Duberdicus" );
            Tooltip.SetDefault( "LMB: Swing whatever is left of the fish RMB: Rain fish out of the sky" );
        }

        public override void SetDefaults() {
            UseCombo = true;
            item.melee = true;
            item.magic = false;
            item.width = 60;
            item.height = 60;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Blue;
            item.noMelee = false;
            item.noUseGraphic = false;
            base.SetDefaults();
        }
        protected override void SetLeftClickMode() {
            item.damage = 33;
            item.mana = 0;
            item.melee = true;
            item.magic = false;
            item.noMelee = false;

            item.shootSpeed = 15f;
            item.useTime = 18;
            item.useAnimation = 18;
            
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item5;

            item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            item.damage = 44;
            item.mana = 10;
            item.magic = true;
            item.melee = false;
            item.noMelee = true;
            
            item.shootSpeed = 10f;
            item.useTime = 36;
            item.useAnimation = 36;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<Fish1>();
            
            item.autoReuse = true;
        }
  
        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
            return false;
        }
        
        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
            Vector2 mousePosition = Main.MouseWorld;
            player.itemLocation.Y = player.Center.Y + 60f;
            player.itemLocation.X = mousePosition.X;
            return true;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override Mythology Mythology => Mythology.Iberian;
        protected override GodDomain GodDomain => GodDomain.War;
    }
}
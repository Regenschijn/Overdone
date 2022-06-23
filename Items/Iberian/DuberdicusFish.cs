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
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.magic = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Item.width = 60;
            Item.height = 60;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            base.SetDefaults();
        }
        protected override void SetLeftClickMode() {
            Item.damage = 33;
            Item.mana = 0;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.magic = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Item.noMelee = false;

            Item.shootSpeed = 15f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item5;

            Item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            Item.damage = 44;
            Item.mana = 10;
            Item.DamageType = DamageClass.Magic;
            Item.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Item.noMelee = true;
            
            Item.shootSpeed = 10f;
            Item.useTime = 36;
            Item.useAnimation = 36;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1f;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Fish1>();
            
            Item.autoReuse = true;
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
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override Mythology Mythology => Mythology.Iberian;
        protected override GodDomain GodDomain => GodDomain.War;
    }
}
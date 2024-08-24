using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Mesopotamian {
    public class Imhullu : ModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "Imhullu, the weapon used by the sky god Marduk " );
            // Tooltip.SetDefault( "LMB: Stab. RMB: Elemental Attack." );
        }

        public override void SetDefaults() {
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Orange;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.autoReuse = true;
            SetStabMode();
        }

        private void SetStabMode() {
            Item.damage = 13;
            Item.mana = 0;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1f;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileID.Arkhalis;
            Item.noMelee = false;
            Item.reuseDelay = 25;
        }

        private void SetThrowMode() {
            Item.damage = 13;
            Item.mana = 20;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item42;          
            Item.shoot = ProjectileID.SandnadoFriendly;
            Item.shootSpeed = 4f;
            Item.noMelee = true;
            Item.reuseDelay = 50;
        }

        public override bool AltFunctionUse( Player player ) => true;
        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) { // Throw mode
                SetThrowMode();
            } else { // Stab mode
                SetStabMode();
            }
            return true;
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }
    }
}
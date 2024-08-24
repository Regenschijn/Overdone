using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Iberian {
    public class SpearOfOlyndicus : DoubleUseOverdoneModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "The Spear Of Olyndicus" );
            // Tooltip.SetDefault( "LMB: Stab. RMB: Throw." );
        }

        public override void SetDefaults() {
            UseCombo = true;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            base.SetDefaults();
        }
        
        public override bool CanUseItem(Player player) {
            base.CanUseItem( player );
            if (IsUsingLeftClick)
                return player.ownedProjectileCounts[Item.shoot] < 1;
            return true;
        }

        protected override void SetLeftClickMode() {
            Item.damage = 25;
            Item.mana = 0;
            Item.DamageType = DamageClass.Melee;

            Item.shootSpeed = 4f;
            Item.useTime = 40;
            Item.useAnimation = 40;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<SpearOfOlyndicusProjectile>();
            
            Item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            Item.damage = 13;
            Item.mana = 1;
            Item.DamageType = DamageClass.Throwing;

            Item.shootSpeed = 15f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item5;
            Item.shoot = ModContent.ProjectileType<SpearOfOlyndicusThrownProjectile>();

            Item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
            ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
            ref int damage, ref float knockBack ) {            
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
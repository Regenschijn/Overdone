using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Iberian {
    public class SpearOfOlyndicus : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "The Spear Of Olyndicus" );
            Tooltip.SetDefault( "LMB: Stab. RMB: Throw." );
        }

        public override void SetDefaults() {
            UseCombo = true;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Blue;
            item.noMelee = true;
            item.noUseGraphic = true;
            base.SetDefaults();
        }
        
        public override bool CanUseItem(Player player) {
            base.CanUseItem( player );
            if (IsUsingLeftClick)
                return player.ownedProjectileCounts[item.shoot] < 1;
            return true;
        }

        protected override void SetLeftClickMode() {
            item.damage = 25;
            item.mana = 0;
            item.thrown = false;
            
            item.shootSpeed = 4f;
            item.useTime = 40;
            item.useAnimation = 40;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<SpearOfOlyndicusProjectile>();
            
            item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            item.damage = 13;
            item.mana = 1;
            item.thrown = true;

            item.shootSpeed = 15f;
            item.useTime = 18;
            item.useAnimation = 18;
            
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item5;
            item.shoot = ModContent.ProjectileType<SpearOfOlyndicusThrownProjectile>();

            item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {            
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
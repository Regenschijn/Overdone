using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Mesopotamian {
    public class Imhullu2 : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Imhullu Restored " );
            Tooltip.SetDefault( "LMB: Spin. RMB: Shoot Imhullu" );
        }

        public override void SetDefaults() {
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( gold: 5 );
            item.rare = ItemRarityID.Orange;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ImhulluSpin>();
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.damage = 26;
            item.mana = 0;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.reuseDelay = 25;
        }


        protected override void SetRightClickMode() {
            item.damage = 20;
            item.mana = 20;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item42;
            item.shootSpeed = 4f;
            item.noMelee = true;
            item.reuseDelay = 50;
        }

        public override bool CanUseItem( Player player ) {
            base.CanUseItem( player );

            if (IsUsingLeftClick)
                return player.ownedProjectileCounts[ModContent.ProjectileType<ImhulluSpin>()] <= 0;
            return true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {            
            Projectile.NewProjectile( player.Center, new Vector2(), ModContent.ProjectileType<ImhulluSpin>(), damage, 0f, player.whoAmI, 0f, 0f );
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
            Projectile.NewProjectile( player.Center, new Vector2( 0f, 0f ), ModContent.ProjectileType<ImhulluSpin>(), 0, 0f, player.whoAmI, 0f, 0f );
            return false;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset() => new Vector2( -5, -4 );



        public override void UseStyle( Player player ) {
            base.UseStyle( player );
        }

        protected override Mythology Mythology => Mythology.Mesopotamian;
        protected override GodDomain GodDomain => GodDomain.Weather | GodDomain.Thunder;
    }
}
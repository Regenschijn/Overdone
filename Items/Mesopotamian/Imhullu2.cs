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
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( gold: 5 );
            Item.rare = ItemRarityID.Orange;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ImhulluSpin>();
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 26;
            Item.mana = 0;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = true;
            Item.reuseDelay = 25;
        }


        protected override void SetRightClickMode() {
            Item.damage = 20;
            Item.mana = 20;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item42;
            Item.shootSpeed = 4f;
            Item.noMelee = true;
            Item.reuseDelay = 50;
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
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        public override Vector2? HoldoutOffset() => new Vector2( -5, -4 );



        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            base.UseStyle( player );
        }

        protected override Mythology Mythology => Mythology.Mesopotamian;
        protected override GodDomain GodDomain => GodDomain.Weather | GodDomain.Thunder;
    }
}
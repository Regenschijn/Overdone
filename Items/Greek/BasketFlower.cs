using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Projectiles;

namespace Overdone.Items.Greek {
    public class BasketFlower : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Demeters Basket" );
            Tooltip.SetDefault( "LMB: Shoot \n RMB: Sow explosive seeds" );
        }

        public override void SetDefaults() {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( gold: 14 );
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.noUseGraphic = false;
            Item.shoot = ModContent.ProjectileType<BasketBlast>();
            Item.DamageType = DamageClass.Melee;
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 44;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 12f;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<BasketBlast>();
            Item.reuseDelay = 20;
            ComboBuildPerHit = 1;
        }

        protected override void SetRightClickMode() {
            Item.damage = 33;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<BasketSeed>();
            ComboBuildPerHit = 1;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
  
                Vector2 newVelocity = velocity.RotatedByRandom( MathHelper.ToRadians( 15 ) );
                newVelocity *= 1f - Main.rand.NextFloat( 0.3f );
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<BasketSeed>(), damage, knockBack, player.whoAmI, 0f, 0f );
            return false;
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Earth;
    }
}
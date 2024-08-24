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

namespace Overdone.Items.Roman {
    public class Invictus : DoubleUseOverdoneModItem {

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "Invictus" );
            // Tooltip.SetDefault( "Burn your foes with Sol's bright wrath! \n LMB: Shoot fireballs that cost mana. Burns enemies. \n RMB: Shoots firebolts that cost combo instead and gains attack for every 25 combo. \n damage while wet or in water is halved" );
        }

        public override void SetDefaults() {
            Item.damage = 24;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 15;
            Item.value = 10000;
            Item.crit = 7;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 10f;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 25;
            Item.mana = 5;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 32f;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Invictus>();
            
        }

        protected override void SetRightClickMode() {
            Item.damage = (int) (20 + (ComboManager.Combo / 25f));
            Item.mana = 0;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 2f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.reuseDelay = 0;
            Item.shoot = ModContent.ProjectileType<InvictusBolt>();
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 1 ) ) {
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + Main.rand.Next( -30, 30 ) / 150f,
                    velocity.Y + Main.rand.Next( -30, 30 ) / 150f, ModContent.ProjectileType<Projectiles.InvictusBolt>(),
                    damage, knockBack, player.whoAmI, 0f, 0f );
            }

            return false;
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override Mythology Mythology => Mythology.Roman;
        protected override GodDomain GodDomain => GodDomain.Water;
    }
}
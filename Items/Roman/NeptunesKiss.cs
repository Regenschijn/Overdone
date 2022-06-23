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
    public class NeptunesKiss : DoubleUseDodoModItem {
        private int _counter;        

        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Neptunes Kiss" );
            Tooltip.SetDefault( "Neptunes Trident \n LMB: Stabs. Every 5th hit is a quick smack. \n RMB: Shoot Neptunes Kiss \n every something, something happens" );
        }

        public override void SetDefaults() {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 15;
            Item.value = 10000;
            Item.crit = 7;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 8f;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 10;
            Item.mana = 0;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 10;
            Item.autoReuse = true;
            Item.noMelee = false;
            Item.crit = (int) (7 + (ComboManager.Combo / 25f));
        }

        protected override void SetRightClickMode() {
            Item.damage = 13;
            Item.mana = 10;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.reuseDelay = 37;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {            
            _counter++;
            if ( _counter < 5 )
                return false;

            for ( var i = 0; i < 3; i++ ) {
                Item.damage = damage + 25;
                Item.useStyle = ItemUseStyleID.Swing;
            }
            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {

            Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + Main.rand.Next( -30, 30 ) / 150f, velocity.Y + Main.rand.Next( -30, 30 ) / 150f, ModContent.ProjectileType<AquaKiss>(), damage, knockBack, player.whoAmI, 0f, 0f );

            return true;
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
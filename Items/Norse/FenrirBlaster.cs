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

namespace Overdone.Items.Norse {
    public class FenrirBlaster : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Fenrirs Spirit Gun" );
            Tooltip.SetDefault( "LMB: Shoot something regular unimplemented \n RMB: Shoot different spirit wolves" );
        }

        public override void SetDefaults() {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 30;
            Item.value = Item.sellPrice( gold: 14 );
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.noUseGraphic = false;
            Item.shoot = ModContent.ProjectileType<SpiritBlastWolfBlue>();
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 13;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<SpiritBlastWolfGreenYellow>();
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item124;
            Item.shootSpeed = 10;
            Item.autoReuse = true;
            Item.noMelee = true;
            ComboBuildPerHit = 1;
        }

        protected override void SetRightClickMode() {
            Item.damage = 13;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item67;
            Item.shootSpeed = 20f;
            Item.noMelee = true;
            Item.autoReuse = true;
            ComboBuildPerHit = 1;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 3 ) ) return false;
            var rand = Main.rand.Next( 3 );
            switch ( rand ) {
                case 0:
                    Projectile.NewProjectile( player.GetSource_FromAI(), player.Center, velocity, ModContent.ProjectileType<SpiritBlastWolfRed>(), damage, 0f, player.whoAmI ); ;
                    break;
                case 1:
                    Projectile.NewProjectile( player.GetSource_FromAI(), player.Center, velocity, ModContent.ProjectileType<SpiritBlastWolfGreenYellow>(), damage, 0f, player.whoAmI ); ;
                    break;
                case 2:
                    Projectile.NewProjectile( player.GetSource_FromAI(), player.Center, velocity, ModContent.ProjectileType<SpiritBlastWolfBlue>(), damage, 0f, player.whoAmI ); ;
                    break;
            }
            return false;
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override Mythology Mythology => Mythology.Norse;
        protected override GodDomain GodDomain => GodDomain.Hunting;
    }
}
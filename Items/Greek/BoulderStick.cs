using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Combo;

namespace Overdone.Items.Greek {
    public class BoulderStick : DoubleUseOverdoneModItem {

        public override void SetStaticDefaults() {
            // Tooltip.SetDefault( "Sisyphus' problems on a stick\nLMB: Smack. RMB: Shoot boulders" );
        }

        public override void SetDefaults() {
            Item.damage = 13;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightRed;
            Item.crit = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 10f;
            Item.shoot = ProjectileID.Boulder;
            Item.DamageType = DamageClass.Melee;
            
            base.SetDefaults();
        }      
             
        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override void SetLeftClickMode() {
            Item.noMelee = false;
            Item.mana = 1;
            Item.DamageType = DamageClass.Magic;
            Item.useAnimation = 40;
            Item.useTime = 40;
            ComboBuildPerHit = 3;
        }

        protected override void SetRightClickMode() {
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.mana = 0;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.useTime = 30;
            Item.useAnimation = 30;
            ComboBuildPerHit = 0;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 10 ) ) return false;
            player.itemRotation = -20f * player.direction;
            player.itemLocation.Y = player.Center.Y;
            player.itemLocation.X = player.Center.X;
            Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 20f * player.direction, position.Y - 46, velocity.X * 1.85f, velocity.Y * 1.85f, ProjectileID.Boulder, (int)((double)damage * 1.5), 10f, player.whoAmI, 0f, 0f );
            SoundEngine.PlaySound( SoundID.Item45, player.position );
            return false;
        }
        protected override Mythology Mythology => Mythology.Greek;

        protected override GodDomain GodDomain => GodDomain.Demi;
    }
}
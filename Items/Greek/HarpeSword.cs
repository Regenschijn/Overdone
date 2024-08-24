using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Greek
{
    public class HarpeSword : DoubleUseOverdoneModItem
    {
        private int _counter;
        const double CritBase = 7;
        public override void SetStaticDefaults() 
        {
            // Tooltip.SetDefault("Used to decapitate Medusa \n LMB: Swing. Each 7th hit triggers a medusa ray. \n RMB: Use 10 favor to lob a medusa head. \n Passive: For every 10 combo, gain 1% crit chance.");
        }

        public override void SetDefaults() 
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 15;
            Item.value = 10000;
            Item.crit = (int) CritBase;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 8f;                 
            base.SetDefaults();
        }        

        protected override void SetLeftClickMode() {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = false;
            Item.mana = 0;
            Item.crit = (int) (CritBase + (ComboManager.Combo / 25d));
        }

        protected override void SetRightClickMode() {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.mana = 8;            
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            _counter++;
            if ( _counter < 7 ) return false;
            
            for ( var i = 0; i < 3; i++ ) {
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + (float) Main.rand.Next( -230, 230 ) / 100f, velocity.Y + (float) Main.rand.Next( -230, 230 ) / 100f, ProjectileID.MedusaHead, damage, knockBack, (player).whoAmI, 0f, 0f );
            }
            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 10 ) ) return false;
            
            Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, velocity.X * 1.85f, velocity.Y * 1.85f, ModContent.ProjectileType<HarpeSwordHead>(), (int) (damage * 1.5f), 10f, player.whoAmI, 0f, 0f );
            SoundEngine.PlaySound( SoundID.Item45, player.position );
            return false;
        }
        public override void AddRecipes() 
        {
            var recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }


        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Agriculture | GodDomain.Creation;
    }
}
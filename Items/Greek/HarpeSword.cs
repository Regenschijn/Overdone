using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Projectiles;
using Overdone.Combo;

namespace Overdone.Items
{
    public class HarpeSword : DoubleUseDodoModItem
    {
        private int _counter;

        public override void SetStaticDefaults() 
        {
            Tooltip.SetDefault("Used to decapitate Medusa \n LMB: Swing. Each 7th hit triggers a medusa ray. \n RMB: Use 10 favor to lob a medusa head. \n Passive: For every 10 combo, gain 1% crit chance.");
        }

        public override void SetDefaults() 
        {
            item.damage = 17;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 15;
            item.value = 10000;
            item.crit = 7;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 8f;                 
            base.SetDefaults();
        }        

        protected override void SetLeftClickMode() {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = false;
            item.mana = 0;
            item.crit = (int) (7 + (ComboManager.Combo / 5));
        }

        protected override void SetRightClickMode() {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
            item.mana = 8;            
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            _counter++;
            if ( _counter < 7 ) return false;
            
            for ( var i = 0; i < 3; i++ ) {
                Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float) Main.rand.Next( -230, 230 ) / 100f, speedY + (float) Main.rand.Next( -230, 230 ) / 100f, ProjectileID.MedusaHead, damage, knockBack, (player).whoAmI, 0f, 0f );
            }
            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 10 ) ) return false;
            
            Projectile.NewProjectile( position.X, position.Y, speedX * 1.85f, speedY * 1.85f, ModContent.ProjectileType<HarpeSwordHead>(), (int) (damage * 1.5f), 10f, player.whoAmI, 0f, 0f );
            Main.PlaySound( SoundID.Item45, player.position );
            return false;
        }
        public override void AddRecipes() 
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Agriculture | GodDomain.Creation;
    }
}
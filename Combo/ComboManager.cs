using Terraria;

namespace Overdone.Combo {
    public static class ComboManager {
        public static long Combo { get; private set; }

        public static void Add( int amount ) {
            Combo += amount;
            Main.NewText( $"COMBO {Combo}", 255, 0, 0 );
        }

        public static bool UseCombo( int price ) {
            if ( Combo < price ) return false;
            Combo -= price;
            return true;
        }
    }
}
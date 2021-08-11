using System;

namespace Overdone.Base {
    [Flags]
    public enum GodDomain {
        War = 1 << 0,
        Thunder = 1 << 1,
        Weather = 1 << 2,
        Agriculture = 1 << 3,
        Healing = 1 << 4,
        Afterlife = 1 << 5,
        Water = 1 << 6,
        Festive = 1 << 7,
        Hunting = 1 << 8,
        Love = 1 << 9,
        Earth = 1 << 10,
        Sun = 1 << 11,
        Moon = 1 << 12,
        Creation = 1 << 13,
        Crafts = 1 << 14,
        Wisdom = 1 << 15,
        Demi = 1 << 16,
    }
}
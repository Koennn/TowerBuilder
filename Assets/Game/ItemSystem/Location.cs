using System;

namespace Game.ItemSystem {
    [Serializable]
    public class Location {
        public int X;
        public int Y;

        public Location() { }

        public Location(int x, int y) {
            X = x;
            Y = y;
        }
    }
}
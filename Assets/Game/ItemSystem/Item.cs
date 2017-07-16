using UnityEngine;

namespace Game.ItemSystem {
    public class Item : MonoBehaviour {
        public string Name;
        public Sprite Texture;
        [Range(0, 10)] public short Strength;
    }
}
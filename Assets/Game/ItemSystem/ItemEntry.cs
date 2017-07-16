using System;
using UnityEngine;

namespace Game.ItemSystem {
    public class ItemEntry : MonoBehaviour {
        public string Name;
        public Sprite Texture;
        [Range(0, 10)] public short Strength;
        public ItemType Type;

        public Item CreateInstance() {
            var rawObject = new GameObject(Name + "-" + GetHashCode());
            switch (Type) {
                case ItemType.Build:
                    var buildItem = rawObject.AddComponent<BuildItem>();
                    buildItem.Name = Name;
                    buildItem.Texture = Texture;
                    buildItem.Strength = Strength;
                    return buildItem;
                case ItemType.Upgrade:
                    var upgradeItem = rawObject.AddComponent<UpgradeItem>();
                    upgradeItem.Name = Name;
                    upgradeItem.Texture = Texture;
                    upgradeItem.Strength = Strength;
                    return upgradeItem;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
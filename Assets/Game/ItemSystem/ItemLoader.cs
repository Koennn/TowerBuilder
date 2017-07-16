using System;
using UnityEngine;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.ItemSystem {
    public class ItemLoader : MonoBehaviour {
        public static Dictionary<string, ItemEntry> BuildItems = new Dictionary<string, ItemEntry>();
        public static Dictionary<string, ItemEntry> UpgradeItems = new Dictionary<string, ItemEntry>();

        public bool DebugMode;
        public string CallbackScene;
        public Text ProgressText;
        
        private void Awake() {
            if (transform.childCount < 1) {
                throw new Exception("Error while loading: unable to find \'Items\' load child!");
            }
            var itemsObject = transform.Find("Items").gameObject;
            if (itemsObject == null) {
                throw new Exception("Error while loading: unable to find \'Items\' load child!");
            }
            
            Debug.Log("Loading items...");

            var items = itemsObject.GetComponents<ItemEntry>();
            foreach (var item in items) {
                switch (item.Type) {
                    case ItemType.Build:
                        BuildItems[item.Name] = item;
                        break;
                    case ItemType.Upgrade:
                        UpgradeItems[item.Name] = item;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if (DebugMode) {
                    Debug.Log("[DEBUG]: Loaded item \'" + item.Name + "\'.");
                }
            }
            
            Debug.Log("Succesfully loaded items.");
            
            var operation = SceneManager.LoadSceneAsync(CallbackScene);
            ProgressText.text = operation.progress.ToString(CultureInfo.CurrentCulture);
        }
    }
}
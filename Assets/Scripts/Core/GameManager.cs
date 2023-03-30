using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backpack.Data;
using Backpack.UI;

namespace Backpack.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance => s_Instance;
        private static GameManager s_Instance;

        void Awake()
        {
            if (s_Instance != null && s_Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            s_Instance = this;
            DontDestroyOnLoad(this);
        }

        const int ITEM_SLOT_COUNT = 60;
        const int ITEM_COUNT = 10;
        const float ITEM_WIDTH = 45f, ITEM_HEIGHT = 45f, PADDING = 10f;
        public List<GameObject> itemSlotList;

        void Start()
        {
            SpawnItemSlots(ITEM_SLOT_COUNT);
            BackpackPanel.Instance.gameObject.SetActive(false);
        }

        void SpawnItemSlots(int itemCount)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Images");
            int classLength = System.Enum.GetValues(typeof(ItemClass)).Length;

            GameObject itemBackground = GameObject.Find("Backpack/Background/Items/ItemList");
            RectTransform backgroundRect = itemBackground.GetComponent<RectTransform>();

            int slotsPerRow = Mathf.FloorToInt(backgroundRect.rect.width / (ITEM_WIDTH + PADDING));

            for (int i = 0; i < itemCount; i++)
            {
                // random generate item slot object
                GameObject itemSlotGO = Instantiate(Resources.Load<GameObject>("Prefabs/ItemSlot"));
                itemSlotGO.transform.SetParent(GameObject.Find("Backpack/Background/Items/ItemList/Viewport/Content").transform, false);

                Vector2 position = new Vector2(PADDING + (i % slotsPerRow) * (ITEM_WIDTH + PADDING),
                                               - PADDING - (i / slotsPerRow) * (ITEM_HEIGHT + PADDING));
                itemSlotGO.GetComponent<RectTransform>().anchoredPosition = position;

                // initialize item slot UI
                ItemSlot itemSlot = itemSlotGO.GetComponent<ItemSlot>();

                // 1. initialize random count to slot
                itemSlot.m_Count = Random.Range(1, ITEM_COUNT);

                // 2. initialize random item to slot
                itemSlot.m_Item = SpawnItem(sprites, classLength, itemSlot, i);
                
                // add into the list
                itemSlotList.Add(itemSlotGO);
            }
        }

        Item SpawnItem(Sprite[] sprites, int classLength, ItemSlot itemSlot, int num)
        {
            ItemClass randomClass = (ItemClass)Random.Range(0, classLength);
            Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
            float randomEffectParam = Random.Range(ITEM_COUNT, ITEM_SLOT_COUNT);
            string randomText = $" Class: {randomClass}";

            Item.ItemEffect randomEffect = null;
            if (randomClass == ItemClass.HP)
            {
                randomEffect = Player.Instance.m_Health.Heal;
                randomText += $" Effect: Heal {randomEffectParam} Points";
            }
            else if (randomClass == ItemClass.UP)
            {
                randomEffect = Player.Instance.m_Health.HealthLimitUpgrade;
                randomText += $" Effect: Increase HP limit by {randomEffectParam} Points";
            }

            return new Item($"Item {num}", randomClass, randomSprite, randomEffectParam,
                                       randomText, randomEffect, itemSlot);
        }
    }
}

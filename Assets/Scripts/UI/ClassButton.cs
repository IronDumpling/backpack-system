using UnityEngine;
using System.Collections;
using Backpack.Data;
using System;
using Backpack.Core;

namespace Backpack.UI
{
	public class ClassButton : MonoBehaviour
	{
        private ItemClass m_Class;

        public void Start()
        {
            string className = transform.GetChild(0).gameObject.GetComponent<TMPro.TMP_Text>().text;
            if (!Enum.TryParse<ItemClass>(className, out m_Class))
                Debug.LogError($"Incorrect Class Type for class {className}");
        }

        public void FilterItems()
		{
            foreach (var itemSlot in GameManager.Instance.itemSlotList)
            {
                itemSlot.SetActive(true);
                if (itemSlot.GetComponent<ItemSlot>().m_Item.m_Class != m_Class) itemSlot.SetActive(false);
            }
        }
	}
}


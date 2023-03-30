using System.Collections;
using System.Collections.Generic;
using Backpack.Core;
using UnityEngine;

namespace Backpack.UI
{
    public class BackpackPanel : MonoBehaviour
    {
        public static BackpackPanel Instance => s_Instance;
        private static BackpackPanel s_Instance;
        private GameObject infoCard;

        private void Awake()
        {
            if (s_Instance != null && s_Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            s_Instance = this;

            infoCard = GameObject.Find("Backpack/Background/Information/InfoCard");

            if (infoCard == null)
            {
                Debug.LogError("Could not find Information Card");
                return;
            }
            else
            {
                infoCard.SetActive(false);
            }
        }
    }
}

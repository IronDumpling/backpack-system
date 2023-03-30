using UnityEngine;
using UnityEngine.Events;
using Backpack.UI;

namespace Backpack.Core
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance => s_Instance;
        private static EventManager s_Instance;

        private void Awake()
        {
            if(s_Instance != null && s_Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            s_Instance = this;
            DontDestroyOnLoad(this);
        }

        // Event lists
        public UnityEvent ClosePanelEvent;
        public UnityEvent OpenPanelEvent;

        public void ClosePanel()
        {
            BackpackPanel.Instance.gameObject.SetActive(false);
        }

        public void OpenPanel()
        {
            BackpackPanel.Instance.gameObject.SetActive(true);
        }
    }
}
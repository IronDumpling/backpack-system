using UnityEngine;
using UnityEngine.Events;
using Backpack.UI;

namespace Backpack.Core
{
    public class InputManager : MonoBehaviour
    {
        public KeyCode panelKey = KeyCode.B;

        private void Update()
        {
            if (Input.GetKeyDown(panelKey))
            {
                if (BackpackPanel.Instance.gameObject.activeSelf)
                {
                    EventManager.Instance.ClosePanelEvent.Invoke();
                }
                else
                {
                    EventManager.Instance.OpenPanelEvent.Invoke();
                }
            }
        }
    }
}


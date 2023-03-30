using UnityEngine;
using UnityEngine.UI;

namespace Backpack.UI
{
    public class OpenButton : MonoBehaviour
    {
        private Button openButton;

        // Use this for initialization
        void Awake()
        {
            openButton = GetComponent<Button>();
        }
    }
}

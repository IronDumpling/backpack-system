using UnityEngine;
using UnityEngine.UI;

namespace Backpack.UI
{
	public class CloseButton : MonoBehaviour
	{
		private Button closeButton;

		// Use this for initialization
		void Awake()
		{
			closeButton = GetComponent<Button>();
		}
	}
}


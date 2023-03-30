using UnityEngine;
using UnityEngine.UI;
using Backpack.Data;

public class ItemSlot : MonoBehaviour
{
    private int _count;
    public int m_Count
    {
        get { return _count; }
        set
        {
            _count = value;
            transform.GetChild(1).gameObject.GetComponent<TMPro.TMP_Text>().text = $"{_count}";
        }
    }

    private Item _item;
    public Item m_Item
    {
        get { return _item; }
        set
        {
            _item = value;
            transform.GetChild(0).gameObject.GetComponent<Image>().sprite = m_Item.m_Thumbnail;
        }
    }

    public ItemSlot(Item item, int count)
    {
        m_Item = item;
        m_Count = count;
    }

    public void Use()
    {
        m_Count--;
        if (m_Count < 0) gameObject.SetActive(false);
    }

    public void ShowInfoCard()
    {

        GameObject infoCard = GameObject.Find("Backpack/Background/Information/InfoCard");

        if(infoCard == null)
        {
            Debug.LogError("Could not find Information Card");
            return;
        }

        if (!infoCard.activeSelf) infoCard.SetActive(true);
        infoCard.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = m_Item.m_Thumbnail;
        infoCard.transform.GetChild(1).gameObject.GetComponent<TMPro.TMP_Text>().text = m_Item.m_Name + m_Item.m_Text;
        infoCard.transform.GetChild(2).gameObject.GetComponent<Button>().onClick = m_Item.m_UseButton;
    }
}

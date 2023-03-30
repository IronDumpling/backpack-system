using UnityEngine;
using UnityEngine.UI;

namespace Backpack.Data
{
    public enum ItemClass
    {
        HP, UP, C, D
    }

    public class Item
    {
        public string m_Name;
        public ItemClass m_Class;
        public Sprite m_Thumbnail;
        public string m_Text;
        public ItemSlot m_ItemSlot;

        // effect
        public delegate void ItemEffect(float param);
        public ItemEffect m_Effect;
        public Button.ButtonClickedEvent m_UseButton;
        public float m_EffectParam;

        // Constructor
        public Item(string name, ItemClass _class, Sprite image, float effectParam, 
                    string text, ItemEffect effect, ItemSlot itemSlot)
        {
            m_Name = name;
            m_Class = _class;
            m_Thumbnail = image;
            m_EffectParam = effectParam;
            m_Text = text;
            m_Effect = effect;
            m_ItemSlot = itemSlot;

            m_UseButton = new Button.ButtonClickedEvent();
            m_UseButton.AddListener(() =>
            {
                if(m_Effect != null) m_Effect(m_EffectParam);
                m_ItemSlot.Use();
            });
        }
    }
}


using UnityEngine;
using UnityEngine.UI;

namespace Backpack.Data
{
    public class Health
    {
        private float _currHealth = 1;
        public float m_CurrHealth
        {
            get { return _currHealth; }
            private set
            {
                _currHealth = value;
                if (_currHealth > m_HealthLimit) _currHealth = m_HealthLimit;
                if(_healthLimit != 0) OnHealthChanged(_currHealth/m_HealthLimit);
            }
        }

        private float _healthLimit = 1;
        public float m_HealthLimit
        {
            get { return _healthLimit; }
            private set
            {
                _healthLimit = value;
                if (_healthLimit != 0) OnHealthChanged(m_CurrHealth/_healthLimit);
            }
        }

        GameObject m_HealthBar;

        public Health(float health, GameObject healthBar)
        {
            m_HealthBar = healthBar;
            m_HealthLimit = health;
            m_CurrHealth = health / 2f;
        }

        // Heal
        public void Heal(float param = 10f)
        {
            m_CurrHealth += param;
        }

        // Health Limit Upgrade
        public void HealthLimitUpgrade(float param = 10f)
        {
            m_HealthLimit += param;
        }

        private void OnHealthChanged(float normalizedHealth)
        {
            // Update the fill amount of the image
            m_HealthBar.transform.GetChild(0).GetComponent<Image>().fillAmount = normalizedHealth;
            m_HealthBar.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = $"HP {m_CurrHealth}/{m_HealthLimit}";
        }
    }
}

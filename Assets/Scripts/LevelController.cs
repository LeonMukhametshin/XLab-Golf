using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stomeSpawner;

        private float m_time;

        private void Start()
        {
            m_time = m_spawnRate;
        }

        private void Update()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                m_stomeSpawner.Spawn();
                m_time = 0;
            }
        }
    }
}

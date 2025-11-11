using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private float m_minAngelX;
        [SerializeField] private float m_maxAngelX;
        [SerializeField, Min(0)] private float m_speed;

        private void FixedUpdate()
        {
            var angels = transform.localEulerAngles;

            if(Input.GetKey(KeyCode.RightArrow))
            {
                angels.x = Rotate(angels.x, m_minAngelX);
            }
            else
            {
                angels.x = Rotate(angels.x, m_maxAngelX);
            }

            transform.localEulerAngles = angels;
        }

        private float Rotate(float angelX, float target)
            => Mathf.MoveTowardsAngle(angelX, target, Time.deltaTime * m_speed);
    }
}

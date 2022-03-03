using UnityEngine;

namespace Characters
{
    public class Player : CharacterBase
    {
        protected override void Start()
        {
            SetSpeed(10.0f);
            base.Start();
        }

        protected override void Update()
        {
            RotateTowardsMousePosition();

            base.Update();
        }

        protected override void Move()
        {
            var horizontalAxis = Input.GetAxis("Horizontal");
            var verticalAxis = Input.GetAxis("Vertical");

            CharacterRigidbody.AddForce(Vector3.right * (horizontalAxis * Speed));
            CharacterRigidbody.AddForce(Vector3.forward * (verticalAxis * Speed));
        }

        protected override void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBullet();
            }
        }

        private void RotateTowardsMousePosition()
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main!.WorldToViewportPoint(transform.position);

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //Get the angle between the points
            var angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            transform.rotation = Quaternion.Euler(new Vector3(0f, -(angle + 90), 0f));
        }

        private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}
using UnityEngine;

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

        Rigidbody.AddForce(Vector3.right * (horizontalAxis * Speed));
        Rigidbody.AddForce(Vector3.forward * (verticalAxis * Speed));
    }

    protected override void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        if (!ObjectPooler.SharedInstance) return;

        var pooledObject = ObjectPooler.SharedInstance.GetPooledObject();
        pooledObject.transform.position = transform.position + new Vector3(0, 1.0f, 0);

        pooledObject.GetComponent<Bullet>().SetOwner(this);

        pooledObject.SetActive(true);
    }

    private void RotateTowardsMousePosition()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main!.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        var angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
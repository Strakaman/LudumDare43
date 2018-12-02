using UnityEngine;

public class BloodBall : ISpell
{
	/*public override int cooldown
	{
		get
		{
			return cooldown;
		}

		set
		{
			cooldown = value;
		}
	}*/

	//public int cooldown = 10;
	public int damage = 10;

	public GameObject BloodProjectile;

	void Start()
	{
		cooldown = 5;
	}

	public override void Execute()
	{

		Vector3 spawnPosition = transform.position + new Vector3(0f, 1.5f, -1f);

		GameObject createProjectile = Instantiate(BloodProjectile, spawnPosition, Quaternion.identity);
		
		createProjectile.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -5f);
	}


	/*
   public void ShootProjectile(Vector3 velocity)
    {
        GetComponent<Rigidbody>().velocity = velocity;
    }*/
}

// CODE DELETED FROM SPELLBOOK.CS IN CASE WE WANT TO SAVE IT

/*
public GameObject BloodBallPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            BloodBall();
        }
	}

    void BloodBall()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 1.5f, 0);
        GameObject createdObj =  Instantiate(BloodBallPrefab, spawnPosition,Quaternion.identity);
        createdObj.GetComponent<BloodBall>().ShootProjectile(new Vector3(5, 0, 5));
    }
*/
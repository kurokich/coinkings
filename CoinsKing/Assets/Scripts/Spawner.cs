using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject[] prefab;
    public GameObject[] coins;
    public GameObject CoinText;
    public GameObject CoinSet;
    public GameObject coinLimitter;
    public int m;
	private GameObject clone;
	private bool meatStop;
	private int stopCount;
	private int growCount;
	
	void Start()
	{
		meatStop = true;
		stopCount = 0;

        coins[0].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[1].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[2].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        coins[4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        StartCoroutine(FuncCoroutine());
    }
	
	void Update ()
	{
     	if (Input.GetButtonDown ("Fire1"))
		{
			if(GlobalVariables.currentCount > 0){
			#if false				
				Vector3 mous = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,Mathf.Abs(Camera.mainCamera.transform.position.z));
				Vector3 wposi = Camera.mainCamera.ScreenToWorldPoint(mous);
				Vector3 offset = new Vector3 (wposi.x,  0.6f, -0.1f  - Random.value * 0.2f);
				Instantiate (prefab, offset, Quaternion.identity);
				 Score.score--;
			#endif
		
				RaycastHit hit;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray,out hit,1000)){
					Vector3 offset = new Vector3 (hit.point.x,  0.6f,  2.6f);
					if(CoinText.GetComponent<CoinManager>().CoinMount > 0 && m >= 0){
						//int rand2 = Random.Range(1,prefab.Length);
                        GameObject go = (GameObject)Instantiate (prefab[CoinSet.GetComponent<CoinSet>().touched],new Vector3(0.0f,0.0f,0.0f),Quaternion.identity);
                        go.transform.parent = transform.parent;
                        go.transform.position = new Vector3(hit.point.x,hit.point.y+0.5f,hit.point.z);
                        go.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        go.transform.localScale = new Vector3(10.0f, 10.0f, 30.0f);
                        CoinText.GetComponent<CoinManager>().CoinChange(-1);
                        m--;
                        setCoin(m);
                        stopCount = 0;
					}
				}
			}
		}

		if(!meatStop){
			stopCount++;
			//Debug.Log(stopCount);
			if(stopCount > 48){
				growCount++;
				int tt = growCount % 6;
				if(GlobalVariables.currentCount == GlobalVariables.maxCount)meatStop = true;
			}
		} 
	}

    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            if (m < 4)
            {
                m++;
                Debug.Log(m);
                setCoin(m);
            }
            yield return new WaitForSeconds(1);
        }
    }
    //爆発スキル
    public void Add_Explode()
    {
        GameObject go = (GameObject)Instantiate(prefab[3], new Vector3(0.0f, 1.0f, 5.0f), Quaternion.identity);
        int rand = Random.Range(1,prefab.Length);
        go.transform.parent = transform.parent;
        go.transform.position = new Vector3(0.0f, 0.5f , 0.7f);
        go.transform.rotation = Quaternion.Euler(-90, 0, 0);
        go.transform.localScale = new Vector3(10.0f, 10.0f, 30.0f);
    }

    private void setCoin(int t)
    {
        if (t >= 4)
        {
            coins[4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        else
        {
            coins[4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        if (t >= 3)
        {
            coins[3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        else
        {
            coins[3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        if (t >= 2)
        {
            coins[2].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        else
        {
            coins[2].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        if (t >= 1)
        {
            coins[1].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        else
        {
            coins[1].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
        if (t >= 0)
        {
            coins[0].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1.0f);
        }
        else
        {
            coins[0].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.0f);
        }
    }
}
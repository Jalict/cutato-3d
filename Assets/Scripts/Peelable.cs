using UnityEngine;
using System.Collections;

public class Peelable : MonoBehaviour {
    public float amountOfSkinLeft; // 0 = All Skin Peeled, 1 = No Skin Peeled

	//Textures
	public Texture2D Tex0;
	public Texture2D Tex1;
	public Texture2D Tex2;
	public Texture2D Tex3;
	public Texture2D Tex4;

	void Start () 
    {
        amountOfSkinLeft = 1;
	}

    void Update()
    {
        CheckSkinState();
    }

    private void CheckSkinState()
    {
        if (amountOfSkinLeft >= 1f)
            GetComponent<Renderer>().material.SetTexture("_MainTex", Tex0);
        else if (amountOfSkinLeft >= 0.75f)
            GetComponent<Renderer>().material.SetTexture("_MainTex", Tex1);
        else if (amountOfSkinLeft >= 0.50f)
            GetComponent<Renderer>().material.SetTexture("_MainTex", Tex2);
        else if (amountOfSkinLeft >= 0.25f)
            GetComponent<Renderer>().material.SetTexture("_MainTex", Tex3);
        else
            GetComponent<Renderer>().material.SetTexture("_MainTex", Tex4);
    }

    public bool isPeeled()
    {
        return amountOfSkinLeft <= 0;
    }

    public void Peel()
    {
        if (!isPeeled())
        {
            amountOfSkinLeft -= 3f * Time.deltaTime;

            StartCoroutine("StartPeelingEmitter");
        }
    }

    public IEnumerator StartPeelingEmitter()
    {
        GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(2);

        GetComponent<ParticleSystem>().Stop();
    }

    public void DontKillMe()
    {
        DontDestroyOnLoad(this);
    }
}

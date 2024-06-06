using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Hud : MonoBehaviour {
    public float hp;
    public float stamina;
    public int dmg;
    public int celnosc;
    public int punkty;
    public GameObject zycie;
    public GameObject stamin;
    public GameObject score;
    public GameObject bonus1;
    public Sprite bonus2;
    public float czasBonusu;
    public bool bonus;
    public string jakiBonus;
    public GameObject czlowiek;
    public GameObject ragdol;
    public GameObject Gameover;
    public float timerEnd;
    public bool ogluszenie;
    float czasOgluszenia = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(ogluszenie == true)
        {
            if (czasOgluszenia > 0)
            {
                czasOgluszenia -= Time.deltaTime;
                Camera.main.GetComponent<Blur>().enabled = true;
                Camera.main.GetComponent<ColorCorrectionCurves>().enabled = true;
            }
            else
            {
                Camera.main.GetComponent<Blur>().enabled = false;
                Camera.main.GetComponent<ColorCorrectionCurves>().enabled =false;
                ogluszenie = false;
                czasOgluszenia = 10;
            }
        }
        zycie.GetComponent<Image>().fillAmount = hp / 100;
        stamin.GetComponent<Image>().fillAmount = stamina / 100;
        score.GetComponent<Text>().text = punkty + "$";
        if(hp <= 0)
        {
            timerEnd += Time.deltaTime;
            Gameover.active = true;
            czlowiek.active = false;
            ragdol.active = true;
            transform.GetComponent<Poruszanie>().poruszanie = true;
            transform.GetComponent<Strzelanie>().enabled = false;
            if(timerEnd > 10)
            {
                Application.LoadLevel(0);
            }
        }
        if(bonus == true && czasBonusu > 0)
        {
            if (jakiBonus == "Stamina")
            {
                czasBonusu -= Time.deltaTime;
                bonus1.GetComponent<Image>().sprite = bonus2;
                bonus1.active = true;
                
            }
        }
        else
        {
            bonus = false;
            bonus1.active = false;
        }
        if(czasBonusu <= 0)
        {
            jakiBonus = "";
        }
    }
    public void AtakZombie(int obrazenia)
    {
        hp -= obrazenia;
    }
}

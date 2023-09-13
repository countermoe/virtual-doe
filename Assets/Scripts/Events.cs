using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public bool UIup;
    public bool canSwitch;
    public GameObject GameUI;
    public GameObject TextUI;
    
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    private string posterOne =
        "Fought for throughout the latter half of the 1980s, agreed upon by campus faculty in 1989, " +
        "and launched with its first courses in 1991, the American Cultures (AC) Requirement was a milestone " +
        "in higher education. According to Ling-Chi Wang, emeritus professor of Asian American Studies and one " +
        "of the requirement’s strongest advocates, the AC program was \"one of the most important " +
        "curriculum-reform projects in the history of this campus...\" Beyond bringing new information and " +
        "perspectives to students, \"... American Cultures challenges each discipline to raise questions that " +
        "they had never raised before, and in the process, they have uncovered unknown aspects of their disciplines.\"\n\nThe " +
        "American Cultures Requirement remains unique in the nation in its approach. The courses students must pass " +
        "to fulfill a one-class graduation requirement cover all instructional fields, as adaptations of " +
        "existing courses or newly designed ones. All incorporate in the curriculum a comparative analysis of " +
        "the experiences of US racial and ethnic groups, drawn from at least three of the following: " +
        "African Americans, Indigenous peoples of the United States, Asian Americans, Chicano/Latino Americans, " +
        "and European Americans. For many UC Berkeley departments, this framework offers a new " +
        "approach to course design that responds directly to a problem encountered in numerous " +
        "disciplines: how better to present the diversity of American experience to the " +
        "diversity of students now enrolled at the university.";

    private string posterTwo =
        "<b>Political uprisings and the demographic transformation of higher education</b>\n\n" +
        "\"While civil rights leaders pressed colleges to admit more black students, the big push came after the " +
        "assassination of Dr. King on April 4, 1968, followed by uprisings in more than 100 cities and student strikes. " +
        "I don’t see how you can understand it apart from the upheavals on campus, racial upheavals in the larger " +
        "society, the general upheavals around the world.\"\n\n" +
        "Professor Jerome Karabel,\n50 Years of Affirmative Action: What Went Right and What It Got Wrong,\nNYT, 3/30/2019.\n\n" +
        "In the 1960s, institutions of higher education saw a rapid influx of students of color at what were " +
        "traditionally white colleges and universities in the US Before 1965, " +
        "the majority of Black students in the country were enrolled at Traditionally Black Colleges and Universities.\n\n" +
        "The increase in enrollment was primarily due to several landmark legislations, including the 1965 Higher " +
        "Education Act (HEA) and the 1965 Immigration and Nationality Act (INA).\n\n" +
        "The HEA greatly expanded financial aid to college students, allowing more students of color to attend more " +
        "colleges and universities. The INA increased the possibility of immigration from Asian-origin countries to " +
        "the United States, enabling more students of Asian descent to enroll in institutions of higher learning. " +
        "Traditionally white colleges and universities also began accepting more African American students in " +
        "response to political activism, especially following the assassination of Dr. Martin Luther King Jr.";


    // Start is called before the first frame update
    void Start()
    {
        UIup = false;
        canSwitch = true;
        GameUI = GameObject.Find("GameUI");
        TextUI = GameObject.Find("TextUI");
        
        GameUI.SetActive(true);
        TextUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canSwitch && UIup)
        {
            closeUI();
        }
    }

    public void closeUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameUI.SetActive(true);
        TextUI.SetActive(false);

        UIup = false;
        StartCoroutine(wait(0.5f));
    }

    public void ShowUI(int poster)
    {
        if (!UIup)
        {
            UIup = true;
            GameUI.SetActive(false);
            
            TextUI.SetActive(true);
            GameObject text = GameObject.Find("PosterText");
            Scrollbar scrollV = GameObject.Find("Scrollbar Vertical").GetComponent<Scrollbar>();
            RectTransform content = GameObject.Find("Content").GetComponent<RectTransform>();
            Image image = GameObject.Find("Poster Image").GetComponent<Image>();

            TextMeshProUGUI tmp = text.GetComponent<TextMeshProUGUI>();
            
            switch(poster)
            {
                case 1:
                    content.sizeDelta = new Vector2(0, 2000);
                    tmp.text = posterOne;
                    image.sprite = sprite1;
                    image.rectTransform.sizeDelta = new Vector2(650, 600);
                    break;
                case 2:
                    content.sizeDelta = new Vector2(0, 1500);
                    tmp.text = posterTwo;
                    break;
                default:
                    tmp.text = "Not yet implemented";
                    break;
            }
            scrollV.value = 1;
            
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(wait(0.5f));
        }
    }
    
    IEnumerator wait(float sec)
    {
        canSwitch = false;
        yield return new WaitForSeconds(sec);
        canSwitch = true;
    }
}

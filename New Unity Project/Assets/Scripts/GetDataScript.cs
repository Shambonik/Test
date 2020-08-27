using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.UI;


public class GetDataScript : MonoBehaviour
{
    private string url = "http://127.0.0.1:5000/api/User";
    private HttpClient httpClient = new HttpClient();
    private int i = 0;
    public GameObject button;
    public Vector2 buttonPosition;

    // Start is called before the first frame update
    async void Start()
    {
        await post();
    }

    // Update is called once per frame
    void Update()
    {
        //if(i==0) 
    }

    async Task post()
    {
        try
        {
            var data = new { androidID = 123, nickname = "New player 2" };
            var response = await httpClient.PostAsync(url, new StringContent(data.ToString(), Encoding.UTF8, "application/json"));
            if (response.Content != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.Log(responseContent);
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseContent);
                GetComponent<Text>().text = myDeserializedClass.nickname;
                foreach (Unit un in myDeserializedClass.units)
                {
                    GameObject go = Instantiate(button, transform.parent);
                    go.transform.position = buttonPosition;
                    go.transform.GetChild(0).GetComponent<Text>().text = un.title + "\nxp " + un.xp + "\ngold " + un.gold;
                    buttonPosition.x += 130;
                }
            }
        }
        catch (System.Exception e)
        {
            await post();
        }
    }
    
    private class Unit
    {
        public int id { get; set; }
        public string title { get; set; }
        public string modelID { get; set; }
        public int gold { get; set; }
        public int xp { get; set; }
    }

    private class Root
    {
        public string id { get; set; }
        public string androidID { get; set; }
        public string nickname { get; set; }
        public List<Unit> units { get; set; }
    }
}

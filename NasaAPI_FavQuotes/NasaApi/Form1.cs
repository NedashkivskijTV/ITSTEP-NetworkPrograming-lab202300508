using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace NasaApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPictureByAPI();
            GetQuoteByAPI();
        }

        private void GetPictureByAPI()
        {
            string pictureUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&camera=fhaz&api_key=fsYfGW9pccZ6SgFHGo8MRZByP45dvsW6uRV1qM5e";

            using(WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString(pictureUrl);
                JObject jObject = JObject.Parse(json);
                string imageUrl = jObject.GetValue("photos").ToString();
                List<Photo> photosList = JsonSerializer.Deserialize<List<Photo>>(imageUrl);
                //tbQuote.Text = photosList[0].img_src;
                pbPicture.Load(photosList[0].img_src);
            }
        }

        private void GetQuoteByAPI()
        {
            string quote = "https://favqs.com/api/qotd";

            using(WebClient webC = new WebClient())
            {
                string json = webC.DownloadString(quote);
                JObject jsonObject = JObject.Parse(json);
                string quoteOfDay = jsonObject["quote"]["body"].ToString();
                string author = jsonObject["quote"]["author"].ToString();
                tbQuote.Text = quoteOfDay;
                tbQuote.Text += "\r\n" + author;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Newtonsoft.Json;
using System.Net.Http;
using System.Xml.Linq;
using Windows.UI.Popups;
using Windows.Networking.Connectivity;

namespace App1.ViewModel
{
    public class Navbar
    {
        public Navbar(string x)
        {
            kategorija = x;
        }

        public string kategorija;
        public string Kategorija
        {
            get { return kategorija; }
            set { kategorija = value; }
        }
    }

    public class Fakultet
    {
        private string naziv, telefon, sajt, email, adresa, dekan, tekst, smerovi, zvanja, uslovi_upisa;
        private int id;
        private string logo;
        private ObservableCollection<string> images;

        public ObservableCollection<string> Images
        {
            get { return images; }
            set { images = value; }
        }
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        public string Sajt
        {
            get { return sajt; }
            set { sajt = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }
        public string Dekan
        {
            get { return dekan; }
            set { dekan = value; }
        }
        public string Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        public string Smerovi
        {
            get { return smerovi; }
            set { smerovi = value; }
        }
        public string Zvanja
        {
            get { return zvanja; }
            set { zvanja = value; }
        }
        public string Uslovi_upisa
        {
            get { return uslovi_upisa; }
            set { uslovi_upisa = value; }
        }
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        public Fakultet(string naziv, string telefon, string sajt, string email, string adresa, string dekan, string tekst, string smerovi, string zvanja, string uslovi_upisa, string[] slike, int id)
        {
            this.naziv = naziv;
            this.telefon = telefon;
            this.sajt = sajt;
            this.email = email;
            this.adresa = adresa;
            this.dekan = dekan;
            this.tekst = tekst;
            this.smerovi = smerovi;
            this.zvanja = zvanja;
            this.uslovi_upisa = uslovi_upisa;
            this.id = id;
            images = new ObservableCollection<string>();
            if (slike.Length > 0)
            {
                this.logo = slike[0];
                for (int i = 1; i < slike.Length; i++)
                {
                    images.Add(slike[i]);
                }
            }

        }

        public Fakultet(string naziv, string telefon, string sajt, string adresa)
        {
            this.naziv = naziv;
            this.telefon = telefon;
            this.sajt = sajt;
            this.adresa = adresa;
            Images = new ObservableCollection<string>();
            email = "";
            dekan = "";
            tekst = "";
            smerovi = "";
            zvanja = "";
            uslovi_upisa = "";
            logo = "";
        }
    }

    public class Dom
    {
        private string naziv, adresa, telefon, opis, prevoz;
        private string web;
        private int id;
        private ObservableCollection<string> images;


        public ObservableCollection<string> Images
        {
            get { return images; }
            set { images = value; }
        }


        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public string Web
        {
            get { return web; }
            set { web = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public string Prevoz
        {
            get { return prevoz; }
            set { Prevoz = value; }
        }

        public Dom(string naziv, string adresa, string telefon, string web, string opis, string prevoz, string[] tempImages, int id)
        {
            this.naziv = naziv;
            images = new ObservableCollection<string>();
            this.adresa = adresa;
            this.telefon = telefon;
            this.web = web;
            this.opis = opis;
            this.prevoz = prevoz;
            this.id = id;
            for (int i = 0; i < tempImages.Length; i++)
            {
                images.Add(tempImages[i]);
            }
        }
    }

    public class Menza
    {

        private string naziv, radnoVreme, telefon, poslovodja, opis, adresa;
        private int id;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public string RadnoVreme
        {
            get { return radnoVreme; }
            set { radnoVreme = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public string Poslovodja
        {
            get { return poslovodja; }
            set { poslovodja = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public Menza(string naziv, int id, string radnoVreme, string telefon, string poslovodja, string opis, string adresa)
        {
            this.naziv = naziv;
            this.id = id;
            this.radnoVreme = radnoVreme;
            this.telefon = telefon;
            this.poslovodja = poslovodja;
            this.opis = opis;
            this.adresa = adresa;
        }

    }

    public class Vest
    {
        private string naslov, url, datum, kategorija;

        public string Kategorija
        {
            get { return kategorija; }
            set { kategorija = value; }
        }

        public string Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Naslov
        {
            get { return naslov; }
            set { naslov = value; }
        }

        public Vest(string naslov, string url, string datum, string kategorija)
        {
            this.naslov = naslov;
            this.url = url;
            this.datum = datum;
            this.kategorija = kategorija;
        }

        public Vest()
        {
            // TODO: Complete member initialization
        }

    }

    public class Data
    {
        public Data()
        {
            load(1);
        }

        static string json;
        static bool prviPut = false;
        static StorageFile file;
        static StorageFolder storageFolder = KnownFolders.PicturesLibrary;

        #region observableColls
        private ObservableCollection<Navbar> navbar = new ObservableCollection<Navbar>();
        public ObservableCollection<Navbar> Navbar
        {
            get { return navbar; }
            set { navbar = value; }
        }

        private static ObservableCollection<Fakultet> fakulteti = new ObservableCollection<Fakultet>();
        public static ObservableCollection<Fakultet> Fakulteti
        {
            get { return fakulteti; }
            set { fakulteti = value; }
        }

        private static ObservableCollection<Dom> domovi = new ObservableCollection<Dom>();
        public static ObservableCollection<Dom> Domovi
        {
            get { return domovi; }
            set { domovi = value; }
        }

        private static ObservableCollection<Menza> menze = new ObservableCollection<Menza>();
        public static ObservableCollection<Menza> Menze
        {
            get { return menze; }
            set { menze = value; }
        }

        private static ObservableCollection<Vest> vesti = new ObservableCollection<Vest>();
        public static ObservableCollection<Vest> Vesti
        {
            get { return vesti; }
            set { vesti = value; }
        }
        private static ObservableCollection<Vest> vesti1 = new ObservableCollection<Vest>();
        public static ObservableCollection<Vest> Vesti1
        {
            get { return vesti1; }
            set { vesti1 = value; }
        }
        #endregion

        public static async void load(int x)
        {
            fakulteti.Clear();
            domovi.Clear();
            menze.Clear();

            #region navbar
            /*
            string[] x = { "Domovi", "Fakulteti", "Menze", "Recnik za brucose", "Informacije" };
            for (int i = 0; i < x.Length; i++)
            {
                navbar.Add(new Navbar(x[i]));
            }
            */
            #endregion

            try
            {
                file = await storageFolder.GetFileAsync("data123.json");
                json = await Windows.Storage.FileIO.ReadTextAsync(file);

                MessageDialog m = new MessageDialog("asd");
                //await m.ShowAsync();
            }
            catch (Exception e)
            {
                prviPut = true;
            }

            if (prviPut)
            {
                Uri dataUri = new Uri("ms-appx:///ViewModel/aaa.txt");
                StorageFile file2 = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                json = await FileIO.ReadTextAsync(file2);

                StorageFile file3 = await storageFolder.CreateFileAsync("data123.json", CreationCollisionOption.ReplaceExisting);
                await Windows.Storage.FileIO.WriteTextAsync(file3, json);
            }

            //if (prviPut)
            //{
            //    //MessageDialog m = new MessageDialog("asd");
            //    //await m.ShowAsync();
            //}

            HttpClient client = new HttpClient();

            #region fakulteti

            JsonObject jsonObject = JsonObject.Parse(json);
            JsonArray jsonArray = jsonObject["fakulteti"].GetArray();
            int i1 = 0;
            foreach (JsonValue fakultetiValue in jsonArray)
            {
                JsonObject fakultetObject = fakultetiValue.GetObject();

                string[] slike = new string[20];
                JsonArray jsonArrayImages = fakultetObject["Images"].GetArray();
                int j1 = 0;
                foreach (JsonValue slika in jsonArrayImages)
                {
                    slike[j1] = slika.GetString();
                    j1++;
                }
                string[] slike1 = new string[j1];
                for (int i = 0; i < slike1.Length; i++)
                {
                    slike1[i] = slike[i];
                }

                fakulteti.Add(new Fakultet(fakultetObject["Naziv"].GetString(), fakultetObject["Telefon"].GetString(), fakultetObject["Sajt"].GetString(), fakultetObject["Email"].GetString(), fakultetObject["Adresa"].GetString(), fakultetObject["Dekan"].GetString(), fakultetObject["Tekst"].GetString(), fakultetObject["Smerovi"].GetString(), fakultetObject["Zvanja"].GetString(), fakultetObject["Uslovi_upisa"].GetString(), slike1, i1));
                i1++;
            }

            sortiraj();

            #endregion

            #region domovi

            JsonArray domoviArray = jsonObject["domovi"].GetArray();

            int temp2 = 0;
            foreach (JsonValue domValue in domoviArray)
            {
                JsonObject domObject = domValue.GetObject();

                string[] slike = new string[20];
                JsonArray jsonArrayImages = domObject["Images"].GetArray();
                int j1 = 0;
                foreach (JsonValue slika in jsonArrayImages)
                {
                    slike[j1] = slika.GetString();
                    j1++;
                }
                string[] slike1 = new string[j1];
                for (int i = 0; i < slike1.Length; i++)
                {
                    slike1[i] = slike[i];
                }

                JsonObject menzaObject = domValue.GetObject();
                domovi.Add(new Dom(menzaObject["Naziv"].GetString(), menzaObject["Adresa"].GetString(), menzaObject["Telefon"].GetString(), menzaObject["Web"].GetString(), menzaObject["Opis"].GetString(), menzaObject["Prevoz"].GetString(), slike1, temp2));
                temp2++;
            }


            #endregion

            #region menze

            JsonArray menzaArray = jsonObject["menze"].GetArray();

            int temp = 0;
            foreach (JsonValue menzaValue in menzaArray)
            {
                JsonObject menzaObject = menzaValue.GetObject();
                menze.Add(new Menza(menzaObject["naziv"].GetString(), temp, menzaObject["radnoVreme"].GetString(), menzaObject["telefon"].GetString(), menzaObject["poslovodja"].GetString(), menzaObject["opis"].GetString(), menzaObject["adresa"].GetString()));
                temp++;
            }

            /*
            JObject o = JObject.Parse(asd);
            int temp = 0;
            foreach (var menzaValue in o["menze"])
            {
                Menza m = JsonConvert.DeserializeObject<Menza>(menzaValue.ToString());
                //m.Id = temp;
                menze.Add(m);
                temp++;
            }
            */

            #endregion

            if (x == 1)
            {
                #region vesti

                try
                {
                    string[] rss_linkovi = { "http://rss.infostud.com/najstudent/30", "http://rss.infostud.com/najstudent/10", "http://rss.infostud.com/najstudent/34", "http://rss.infostud.com/najstudent/7", "http://rss.infostud.com/najstudent/23", "http://rss.infostud.com/najstudent/33", "http://rss.infostud.com/najstudent/22" };
                    for (int i = 0; i < rss_linkovi.Length; i++)
                    {
                        string kategorijaVesti = "";
                        if (i == 0) kategorijaVesti = "Studentske vesti";
                        else if (i == 1) kategorijaVesti = "Stipendije";
                        else if (i == 2) kategorijaVesti = "Studije";
                        else if (i == 3) kategorijaVesti = "Programi za studente";
                        else if (i == 4) kategorijaVesti = "Prakse";
                        else if (i == 5) kategorijaVesti = "Nagradni konkursi";
                        else kategorijaVesti = "Saveti";
                        var a1 = await client.GetByteArrayAsync(rss_linkovi[i]);
                        string rss = Encoding.UTF8.GetString(a1, 0, a1.Length);
                        XElement xmlVesti = XElement.Parse(rss);
                        var vestii = xmlVesti.Descendants("item");
                        foreach (var item in vestii)
                        {
                            try
                            {
                                Vesti.Add(new Vest() { Naslov = item.Element("title").Value, Datum = item.Element("pubDate").Value.Substring(0, item.Element("pubDate").Value.Length - 15), Url = item.Element("link").Value, Kategorija = kategorijaVesti });
                            }
                            catch { }
                        }
                    }
                    prilagodi("Studentske vesti");
                }
                catch { }

                #endregion
            }

        }

        public static List<string> GetSearchSuggestions(string s)
        {
            List<string> l = new List<string>();
            foreach (Fakultet f in Fakulteti)
            {
                if (f.Naziv.ToLower().Contains(s.ToLower())) l.Add(f.Naziv);
            }
            return l;
        }

        public static void sortiraj()
        {
            for (int i = 0; i < Fakulteti.Count - 1; i++)
            {
                for (int j = i + 1; j < Fakulteti.Count; j++)
                {
                    if (Fakulteti[i].Naziv[0] > Fakulteti[j].Naziv[0])
                    {
                        Fakultet pom = Fakulteti[i];
                        Fakulteti[i] = Fakulteti[j];
                        fakulteti[j] = pom;
                    }
                }
            }
        }

        public static void prilagodi(string s)
        {
            Vesti1.Clear();
            foreach (Vest v in Vesti)
            {
                if (v.Kategorija == s) Vesti1.Add(v);
            }
        }

        public static async Task update()
        {
            HttpClient client = new HttpClient();
            if (isConnectedToNetwork)
            {
                string proveri = await client.GetStringAsync("https://raw.github.com/markostakic/31/master/aaa1.txt");
                if (proveri == "")
                {
                    string asd = await client.GetStringAsync("https://raw.github.com/markostakic/31/master/aaa.json");
                    if (!asd.Equals(json))
                    {
                        StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
                        StorageFile file = await storageFolder.CreateFileAsync("data123.json", CreationCollisionOption.ReplaceExisting);
                        await Windows.Storage.FileIO.WriteTextAsync(file, asd);

                        MessageDialog m = new MessageDialog("Success!");
                        await m.ShowAsync();
                        load(0);
                    }
                    else
                    {
                        MessageDialog m = new MessageDialog("Nema promena");
                        await m.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog m = new MessageDialog("Nema promena");
                    await m.ShowAsync();
                }
            }
            else
            {
                MessageDialog m = new MessageDialog("Nema pristupa internetu");
                await m.ShowAsync();
            }
        }

        public static bool isConnectedToNetwork
        {
            get
            {
                var profile = NetworkInformation.GetInternetConnectionProfile();
                if (profile != null)
                {
                    var interfaceType = profile.NetworkAdapter.IanaInterfaceType;
                    return interfaceType == 71 || interfaceType == 6;
                }
                return false;
            }
        }
    }
}

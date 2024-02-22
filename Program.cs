using Lab4_5;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;

var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://star-wars-characters.p.rapidapi.com/46DYBV/star_wars_characters"),
    Headers =
    {
        { "X-RapidAPI-Key", "051606a134msh4b860df37205ba3p1cf21fjsn14affe616766" },
        { "X-RapidAPI-Host", "star-wars-characters.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    JsonNode data = JsonObject.Parse(body);

    List<Person> arr = GetData(data);
    string option = ""; 
    while (option.ToLower() != "q")
    {
        Console.WriteLine("1. ID");
        Console.WriteLine("2. Name");
        Console.WriteLine("3. Gender"); 
        Console.WriteLine("4. Eye Color");
        Console.WriteLine("5. Homeworld");
        Console.WriteLine("6. Birth Year");
        Console.WriteLine("7. Hair Color");
        Console.WriteLine("8. Skin Color");
        Console.WriteLine("Q: Close");
        option = Console.ReadLine();
        if (option.ToLower() != "q")
        {
            string field = "";
            switch (option)
            {
                case "1":
                    field = "id";
                    Console.WriteLine("Type the ID you want to search for.");
                    break;
                case "2":
                    field = "name";
                    Console.WriteLine("Type the Name you want to search for.");
                    break;
                case "3":
                    field = "gender";
                    Console.WriteLine("Type the Gender you want to search for.");
                    break;
                case "4":
                    field = "eye_color";
                    Console.WriteLine("Type the Eye Color you want to search for.");
                    break;
                case "5":
                    field = "homeworld";
                    Console.WriteLine("Type the Homeworld you want to search for.");
                    break;
                case "6":
                    field = "birth_year";
                    Console.WriteLine("Type the Birth Year you want to search for.");
                    break;
                case "7":
                    field = "hair_color";
                    Console.WriteLine("Type the Hair Color you want to search for.");
                    break;
                case "8":
                    field = "skin_color";
                    Console.WriteLine("Type the Skin Color you want to search for.");
                    break;
            }
            option = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].IsEqual(option, field) == true)
                {
                    count++;
                    Console.WriteLine(arr[i].ToString());
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No Data Found");
            }    
        }
    }
}
List<Person> GetData(JsonNode data)
{
    List<Person> people = new List<Person>();
    for (int i = 0; i < data.AsArray().Count; i++)
    {
        try
        {
            string value = data[i].ToString().Replace("{", "");
            value = value.Replace("}", "");
            string[] arr = value.Split(','); 
            int id = int.Parse(arr[0].Split(":")[1]); 
            double mass = 0;
            if (arr[1].Contains("NA") == false && arr[1].Contains("null") == false)
            {
                string val = arr[1].Split(":")[1];
                val = (val.Replace('"', ' '));
                mass = double.Parse(val.Trim());
            }

            string name = arr[2].Split(":")[1];
            string gender = arr[3].Split(":")[1];
            int height = int.Parse(arr[4].Split(":")[1].Substring(2, 3).Trim('"'));
            string species = GetValue(arr[5]); 
            string eye_color = GetValue(arr[6]);
            string homeworld = GetValue(arr[7]);
            string birth_year = GetValue(arr[8]);
            string hair_color = GetValue(arr[9]);
            string skin_color = GetValue(arr[10]);

            Person p = new Person(id, mass, name, gender, height, species, eye_color, homeworld, birth_year, hair_color, skin_color);
            people.Add(p);
        }
        catch (Exception e)
        {
            //Console.WriteLine(e.Message);
        }
    }

    //people.ForEach(p => Console.WriteLine(p.ToString()));
    return people;
}

string GetValue(string str)
{
    try
    {
        return str.Split(":")[1];
    }
    catch (Exception e)
    {
        return "";
    }
}
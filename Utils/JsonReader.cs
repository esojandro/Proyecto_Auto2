using Newtonsoft.Json;

namespace Proyecto_Auto.Utils
{
    public static class JsonReader
    {
        public static LoginData ReadLoginData()
        {
            string path = Path.Combine("C:\\Users\\Alejandro\\source\\repos\\Proyecto_Auto\\TestData", "data.json");
            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<LoginData>(json);
        }
    }
}

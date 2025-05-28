using System.IO;
using System.Text.Json;
using SMSManager.Objetos.Modelos;

public static class ConfiguracionService
{
    private static string ruta = "config.json";

    public static void Guardar(ApiConfig config)
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ruta, json);
    }

    public static ApiConfig Cargar()
    {
        if (!File.Exists(ruta))
        {
            return new ApiConfig(); 
        }

        string json = File.ReadAllText(ruta);
        return JsonSerializer.Deserialize<ApiConfig>(json);
    }
}

using DocumentData;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;


//string code = "DPREVAllegato3";
string code = "DCOE";
//string code = "DPREVPrivacy";


string subFolder = "../../../" + code;

// Il nome del file da aprire
string fileName = code + ".txt";

// Costruisce il percorso relativo del file rispetto alla directory dell'eseguibile
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subFolder, fileName);

try
{
    // Legge il contenuto del file
    string fileContent = File.ReadAllText(filePath, Encoding.Default);

    string jsonString;

    var options = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true, // Opzionale, per una formattazione più leggibile
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Disabilita l'escaping dei caratteri
    };


    switch (code)
    {
        case "DCOE":
            TemplateDCOE templateDCOE = (TemplateDCOE)(new XmlSerializer(typeof(TemplateDCOE))).Deserialize(new StreamReader(filePath, Encoding.UTF8));
            var RootObject1 = ObjectConverter.ConvertToRootObject(templateDCOE);
            jsonString = JsonSerializer.Serialize(RootObject1, options);
            break;
        case "DPREVPrivacy":
            TemplateDPREVPrivacy templateDPREVPrivacy = (TemplateDPREVPrivacy)(new XmlSerializer(typeof(TemplateDPREVPrivacy))).Deserialize(new StreamReader(filePath, Encoding.UTF8));
            var RootObject2 = ObjectConverter.ConvertToRootObject(templateDPREVPrivacy);
            jsonString = JsonSerializer.Serialize(RootObject2, options);
            break;
        case "DPREVAllegato3":
            TemplateDPREVAllegato3 templateDPREVAllegato3 = (TemplateDPREVAllegato3)(new XmlSerializer(typeof(TemplateDPREVAllegato3))).Deserialize(new StreamReader(filePath, Encoding.UTF8));
            var RootObject3 = ObjectConverter.ConvertToRootObject(templateDPREVAllegato3);
            jsonString = JsonSerializer.Serialize(RootObject3, options);
            break;
        default:
            throw new Exception("codice template non gestito");
    }

    Console.WriteLine(jsonString);



}
catch (Exception ex)
{
    Console.WriteLine("Errore durante l'apertura del file: " + ex.Message);
}

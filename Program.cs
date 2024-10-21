using StampeDatiDinamici;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;


//var DocumentData = new DocumentDatas
//{
//    DocumentInfo = new DocumentInfo
//    {
//        PublicDocId = "1234567891011112",
//        DocumentName = "Questionario di Coerenza",
//        ShortDocumentName = "Progetto Personalizzato",
//        DigitalSignature = false
//    },
//    BankCopy = false,
//    ClientCopy = true,
//    DocumentInfoInstitute = new DocumentInfoInstitute
//    {
//        BlocchettoCivilisticoBody = "Capitale Sociale euro 1.102.071.064 i.v. - Iscritta al Registro Imprese di Parma, Codice Fiscale n. 02113530345, aderente al Gruppo IVA Crédit Agricole Italia, Partita Iva n. 02886650346. Codice ABI 6230.7. Iscritta all'Albo delle Banche al n. 5435. Aderente al Fondo Interbancario di Tutela dei Depositi e al Fondo Nazionale di Garanzia. Capogruppo del Gruppo Bancario Crédit Agricole Italia iscritto all'Albo dei Gruppi Bancari al n. 6230.7 - Società soggetta all'attività di Direzione e Coordinamento di Crédit Agricole S.A.",
//        BlocchettoCivilisticoHeader = "Crédit Agricole Italia S.p.A. - Sede Legale Via Università, 1 - 43121 Parma - telefono 0521.912111.",
//        DenominazioneBrevissimaIstituto = "Crédit Agricole Italia",
//        DenominazioneBreveIstituto = "Crédit Agricole Italia S.p.A.",
//        DenominazioneGruppo = "Gruppo Bancario Crédit Agricole Italia",
//        DenominazioneIstituto = "Crédit Agricole Italia S.p.A.",
//        EmailServizioReclami = "reclami@credit-agricole.it",
//        URLSitoIstituzionale = "http://www.credit-agricole.it"
//    }
//};

string subFolder = "../../../QCOERENZA";

// Il nome del file da aprire
string fileName = "QCOERENZA1.txt";

// Costruisce il percorso relativo del file rispetto alla directory dell'eseguibile
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subFolder, fileName);

try
{
    // Legge il contenuto del file
    string fileContent = File.ReadAllText(filePath);

    // Deserializza l'XML nel modello di oggetto

    XmlSerializer serializer = new XmlSerializer(typeof(TemplateMaster));
    StringReader reader = new StringReader(fileContent);

    var documentData = (TemplateMaster)serializer.Deserialize(reader);


    var RootObject = ObjectConverter.ConvertToRootObject(documentData);


    var options = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true // Opzionale, per una formattazione più leggibile
    };

    // Serializzazione in JSON
    string jsonString = JsonSerializer.Serialize(RootObject, options);

    // Stampa della stringa JSON
    Console.WriteLine(jsonString);

}
catch (Exception ex)
{
    Console.WriteLine("Errore durante l'apertura del file: " + ex.Message);
}


    
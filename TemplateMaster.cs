using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StampeDatiDinamici
{
    [XmlRoot(ElementName = "TempleateMaster")]
    public class TemplateMaster
    {
        public string documentCode = "";

        [XmlElement(ElementName = "documentInfo")]
        public DocumentInfo DocumentInfo { get; set; }

        [XmlElement(ElementName = "bankCopy")]
        public bool BankCopy { get; set; }

        [XmlElement(ElementName = "clientCopy")]
        public bool ClientCopy { get; set; }

        [XmlElement(ElementName = "documentInfoInstitute")]
        public DocumentInfoInstitute DocumentInfoInstitute { get; set; }

        [XmlElement(ElementName = "bankCode")]
        public string BankCode { get; set; }

        [XmlElement(ElementName = "signatureDate")]
        public DateTime SignatureDate { get; set; }

        [XmlElement(ElementName = "signaturePlace")]
        public string SignaturePlace { get; set; }

        [XmlElement(ElementName = "branch")]
        public Branch Branch { get; set; }

        [XmlElement(ElementName = "banker")]
        public Banker Banker { get; set; }

        [XmlElement(ElementName = "SRiferimentoTemplate")]
        public string SRiferimentoTemplate { get; set; }
    

        [XmlElement(ElementName = "Contraente")]
        public Contraente Contraente { get; set; }

        [XmlElement(ElementName = "LegaleRappresentante")]
        public LegaleRappresentante LegaleRappresentante { get; set; }

    }

    public class DocumentInfo
    {
        [XmlElement(ElementName = "publicDocId")]
        public string PublicDocId { get; set; }

        [XmlElement(ElementName = "documentName")]
        public string DocumentName { get; set; }

        [XmlElement(ElementName = "shortDocumentName")]
        public string ShortDocumentName { get; set; }

        [XmlElement(ElementName = "digitalSignature")]
        public bool DigitalSignature { get; set; }
    }

    public class DocumentInfoInstitute
    {
        [XmlElement(ElementName = "blocchettoCivilisticoBody")]
        public string BlocchettoCivilisticoBody { get; set; }

        [XmlElement(ElementName = "blocchettoCivilisticoHeader")]
        public string BlocchettoCivilisticoHeader { get; set; }

        [XmlElement(ElementName = "denominazioneBrevissimaIstituto")]
        public string DenominazioneBrevissimaIstituto { get; set; }

        [XmlElement(ElementName = "denominazioneBreveIstituto")]
        public string DenominazioneBreveIstituto { get; set; }

        [XmlElement(ElementName = "denominazioneGruppo")]
        public string DenominazioneGruppo { get; set; }

        [XmlElement(ElementName = "denominazioneIstituto")]
        public string DenominazioneIstituto { get; set; }

        [XmlElement(ElementName = "emailServizioReclami")]
        public string EmailServizioReclami { get; set; }

        [XmlElement(ElementName = "URLSitoIstituzionale")]
        public string URLSitoIstituzionale { get; set; }
    }

    public class Branch
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
    }

    public class Banker
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
    }

    public class Contraente
    {
        [XmlElement(ElementName = "ENaturaGiuridica")]
        public string ENaturaGiuridica { get; set; }

        [XmlElement(ElementName = "CNDG")]
        public string CNDG { get; set; }

        [XmlElement(ElementName = "SIntestazione")]
        public string SIntestazione { get; set; }

        [XmlElement(ElementName = "SCFIS")]
        public string SCFIS { get; set; }

        [XmlElement(ElementName = "SCPIVA")]
        public string SCPIVA { get; set; }

        [XmlElement(ElementName = "DIscrCCIAA")]
        public DateTime DIscrCCIAA { get; set; }

        [XmlElement(ElementName = "DNascita")]
        public string DNascita { get; set; }

        [XmlElement(ElementName = "SIndirizzo")]
        public string SIndirizzo { get; set; }

        [XmlElement(ElementName = "SCitta")]
        public string SCitta { get; set; }

        [XmlElement(ElementName = "SCAP")]
        public string SCAP { get; set; }

        [XmlElement(ElementName = "SProvincia")]
        public string SProvincia { get; set; }
    }

    public class LegaleRappresentante
    {
        [XmlElement(ElementName = "ENaturaGiuridica")]
        public string ENaturaGiuridica { get; set; }

        [XmlElement(ElementName = "CNDG")]
        public string CNDG { get; set; }

        [XmlElement(ElementName = "SIntestazione")]
        public string SIntestazione { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DocumentData
{
    [XmlRoot(ElementName = "customer")]
    public class TemplateMaster
    {

        [XmlElement(ElementName = "documentInfo")]
        public DocumentInfo documentInfo { get; set; }

        [XmlElement(ElementName = "bankCopy")]
        public string bankCopy { get; set; }

        [XmlElement(ElementName = "clientCopy")]
        public string clientCopy { get; set; }

        [XmlElement(ElementName = "documentInfoInstitute")]
        public DocumentInfoInstitute documentInfoInstitute { get; set; }

        [XmlElement(ElementName = "signatureDate")]
        public string signatureDate { get; set; }

        [XmlElement(ElementName = "signaturePlace")]
        public string signaturePlace { get; set; }

        [XmlElement(ElementName = "branch")]
        public Branch branch { get; set; }

        [XmlElement(ElementName = "banker")]
        public Banker banker { get; set; }

        [XmlElement(ElementName = "bankCode")]
        public string bankCode { get; set; }


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
        public string publicDocId { get; set; }

        [XmlElement(ElementName = "documentName")]
        public string documentName { get; set; }

        [XmlElement(ElementName = "shortDocumentName")]
        public string shortDocumentName { get; set; }

        [XmlElement(ElementName = "digitalSignature")]
        public string digitalSignature { get; set; }
    }

    public class DocumentInfoInstitute
    {
        [XmlElement(ElementName = "blocchettoCivilisticoBody")]
        public string blocchettoCivilisticoBody { get; set; }

        [XmlElement(ElementName = "blocchettoCivilisticoHeader")]
        public string blocchettoCivilisticoHeader { get; set; }

        [XmlElement(ElementName = "denominazioneBrevissimaIstituto")]
        public string denominazioneBrevissimaIstituto { get; set; }

        [XmlElement(ElementName = "denominazioneBreveIstituto")]
        public string denominazioneBreveIstituto { get; set; }

        [XmlElement(ElementName = "denominazioneGruppo")]
        public string denominazioneGruppo { get; set; }

        [XmlElement(ElementName = "denominazioneIstituto")]
        public string denominazioneIstituto { get; set; }

        [XmlElement(ElementName = "emailServizioReclami")]
        public string emailServizioReclami { get; set; }

        [XmlElement(ElementName = "URLSitoIstituzionale")]
        public string URLSitoIstituzionale { get; set; }
    }

    public class Branch
    {
        [XmlElement(ElementName = "name")]
        public string name { get; set; }

        [XmlElement(ElementName = "code")]
        public string code { get; set; }
    }

    public class Banker
    {
        [XmlElement(ElementName = "name")]
        public string name { get; set; }

        [XmlElement(ElementName = "code")]
        public string code { get; set; }
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
        public string DIscrCCIAA { get; set; }

        [XmlElement(ElementName = "SLuogoNascita")]
        public string SLuogoNascita { get; set; }

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

        [XmlElement(ElementName = "SEmail")]
        public string SEmail { get; set; }

        [XmlElement(ElementName = "ETipoDocumento")]
        public string ETipoDocumento { get; set; }

        [XmlElement(ElementName = "SNumeroDocumento")]
        public string SNumeroDocumento { get; set; }

    }

    public class LegaleRappresentante
    {
        [XmlElement(ElementName = "ENaturaGiuridica")]
        public string ENaturaGiuridica { get; set; }

        [XmlElement(ElementName = "CNDG")]
        public string CNDG { get; set; }

        [XmlElement(ElementName = "SIntestazione")]
        public string SIntestazione { get; set; }

        [XmlElement(ElementName = "SCFIS")]
        public string SCFIS { get; set; }

        [XmlElement(ElementName = "SLuogoNascita")]
        public string SLuogoNascita { get; set; }

        [XmlElement(ElementName = "DNascita")]
        public string DNascita { get; set; }


        [XmlElement(ElementName = "SIndirizzo")]
        public string SIndirizzo { get; set; }

        [XmlElement(ElementName = "SCitta")]
        public string SCitta { get; set; }

        [XmlElement(ElementName = "SCAP")]
        public string SCAP { get; set; }

    }


}

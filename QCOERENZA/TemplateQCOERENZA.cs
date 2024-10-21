using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StampeDatiDinamici
{

    [XmlRoot(ElementName = "customer")]
    public class TemplateQCOERENZA : TemplateMaster
    {

        [XmlElement(ElementName = "STitolo")]
        public string STitolo { get; set; }

        [XmlElement(ElementName = "STitolo2")]
        public string STitolo2 { get; set; }

        [XmlElement(ElementName = "SIntro")]
        public string SIntro { get; set; }

        [XmlElement(ElementName = "SIntro2")]
        public string SIntro2 { get; set; }

        [XmlElement(ElementName = "QuestionarioEsito")]
        public QuestionarioEsito QuestionarioEsito { get; set; }

        [XmlElement(ElementName = "Questionario")]
        public Questionario Questionario { get; set; }
    }

    

    public class QuestionarioEsito
    {
        [XmlElement(ElementName = "IQuestionario")]
        public string IQuestionario { get; set; }

        [XmlElement(ElementName = "DCompilazione")]
        public DateTime DCompilazione { get; set; }

        [XmlElement(ElementName = "EEsitoAde")]
        public string EEsitoAde { get; set; }

        [XmlElement(ElementName = "CRiferimentoEsterno")]
        public string CRiferimentoEsterno { get; set; }

        [XmlElement(ElementName = "CRaggrProdCollocatore")]
        public string CRaggrProdCollocatore { get; set; }

        [XmlElement(ElementName = "SNomeCompagnia")]
        public string SNomeCompagnia { get; set; }
    }

    public class Questionario
    {
        [XmlElement(ElementName = "NDurataFinanziamentoMesi")]
        public int NDurataFinanziamentoMesi { get; set; }

        [XmlElement(ElementName = "DomandaRisposta")]
        public List<DomandaRisposta> DomandeRisposte { get; set; }
    }

    public class DomandaRisposta
    {
        [XmlElement(ElementName = "Domanda")]
        public string Domanda { get; set; }

        [XmlElement(ElementName = "NumColonneRisposte")]
        public int NumColonneRisposte { get; set; }

        [XmlElement(ElementName = "NumRigheRisposte")]
        public int NumRigheRisposte { get; set; }

        [XmlElement(ElementName = "Risposta")]
        public List<Risposta> Risposte { get; set; }
    }

    public class Risposta
    {
        [XmlElement(ElementName = "Flag")]
        public bool Flag { get; set; }

        [XmlElement(ElementName = "STesto")]
        public string STesto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Data.SqlClient;

namespace CargaDatosExpertonet
{
    class VerificaSolicitud : SoapRequestBase
    {
        csCnn cnn = new csCnn(csCnn.fnAmbienteTrabajo());
        string vidSolicitud;

        public VerificaSolicitud(string url, string action)
           : base(url, action)
        {
        }

        #region Crea el XML para enviar
        public string Generate(X509Certificate2 certificate, string rfcSolicitante, string idSolicitud)
        {
            vidSolicitud = idSolicitud;
            string canonicalTimestamp = "<des:VerificaSolicitudDescarga xmlns:des=\"http://DescargaMasivaTerceros.sat.gob.mx\">"
                + "<des:solicitud IdSolicitud=\"" + idSolicitud + "\" RfcSolicitante=\"" + rfcSolicitante + ">"
                + "</des:solicitud>"
                + "</des:VerificaSolicitudDescarga>";

            string digest = CreateDigest(canonicalTimestamp);

            string canonicalSignedInfo = @"<SignedInfo xmlns=""http://www.w3.org/2000/09/xmldsig#"">" +
                                            @"<CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""></CanonicalizationMethod>" +
                                            @"<SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1""></SignatureMethod>" +
                                            @"<Reference URI=""#_0"">" +
                                               "<Transforms>" +
                                                  @"<Transform Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""></Transform>" +
                                               "</Transforms>" +
                                               @"<DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1""></DigestMethod>" +
                                               "<DigestValue>" + digest + "</DigestValue>" +
                                            "</Reference>" +
                                         "</SignedInfo>";
            string signature = Sign(canonicalSignedInfo, certificate);
            string soap_request = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" xmlns:des=""http://DescargaMasivaTerceros.sat.gob.mx"" xmlns:xd=""http://www.w3.org/2000/09/xmldsig#"">" +
                        @"<s:Header/>" +
                        @"<s:Body>" +
                            @"<des:VerificaSolicitudDescarga>" +
                                @"<des:solicitud " +
                                @"IdSolicitud=""" + idSolicitud +
                                @""" RfcSolicitante=""" + rfcSolicitante +
                                @""">" +
                                                    @"<Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">" +
                                                    @"<SignedInfo>" +
                                                    @"<CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>" +
                                                    @"<SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1""/>" +
                                                    @"<Reference URI=""#_0"">" +
                                                        @"<Transforms>" +
                                                        @"<Transform Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>" +
                                                        @"</Transforms>" +
                                                        @"<DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1""/>" +
                                                        @"<DigestValue>" + digest + @"</DigestValue>" +
                                                    @"</Reference>" +
                                                    @"</SignedInfo>" +
                                                    @"<SignatureValue>" + signature + "</SignatureValue>" +
                                                    @"<KeyInfo>" +
                                                        @"<X509Data>" +
                                                            @"<X509IssuerSerial>" +
                                                                @"<X509IssuerName>" + certificate.Issuer +
                                                                @"</X509IssuerName>" +
                                                                @"<X509SerialNumber>" + certificate.SerialNumber +
                                                                @"</X509SerialNumber>" +
                                                            @"</X509IssuerSerial>" +
                                                            @"<X509Certificate>" + Convert.ToBase64String(certificate.RawData) + "</X509Certificate>" +
                                                        @"</X509Data>" +
                                                    @"</KeyInfo>" +
                                                    @"</Signature>" +
                                                    @"</des:solicitud>" +
                                                @"</des:VerificaSolicitudDescarga>" +
                                            @"</s:Body>" +
                                            @"</s:Envelope>";
            xml = soap_request;
            return soap_request;
        }
        #endregion
        public override string GetResult(XmlDocument xmlDoc)
        {

            // Estado = 0 // Token Invalido 
            // Estado = 1 // Aceptada 
            // Estado = 2 // En Proceso 
            // Estado = 3 // Terminada 
            // Estado = 4 // Error 
            // Estado = 5 // Rechazada 
            // Estado = 6 // Vencida

            string IdsPaquetes = string.Empty;

            int estado = Convert.ToInt16(xmlDoc.GetElementsByTagName("VerificaSolicitudDescargaResult")[0].Attributes["EstadoSolicitud"].Value);

            //String Mensaje = xmlDoc.GetElementsByTagName("VerificaSolicitudDescargaResult")[0].Attributes["Mensaje"].Value;
            //int NumeroCFDIs = Convert.ToInt32(xmlDoc.GetElementsByTagName("VerificaSolicitudDescargaResult")[0].Attributes["NumeroCFDIs"].Value);
            //int CodigoEstadoSolicitud = Convert.ToInt32(xmlDoc.GetElementsByTagName("VerificaSolicitudDescargaResult")[0].Attributes["CodigoEstadoSolicitud"].Value);
            //int CodEstatus = Convert.ToInt32(xmlDoc.GetElementsByTagName("VerificaSolicitudDescargaResult")[0].Attributes["CodEstatus"].Value);

            // Aqui falta incluir mas logica para poder identificar los estados 0,1,2,4,5,6
            // Tambien incluir el numero de cfdis que vienen en el paquete 

            SqlCommand cmdReader;
            SqlDataReader reader;
            string slqInsert;


            //if (estado == 3)
            //{
            // Aqui falta mas logica para poder obtener todos los IdsPaquetes del xml solo hace referencia al 1er nodo 
            // Algo asi como 
            //    for (int i = 0; i < xmlDoc.GetElementsByTagName("IdsPaquetes").Count; i++)
            //       s = xmlDoc.GetElementsByTagName("IdsPaquetes")[0].InnerXml + "|" + ;
            //
            //    s = s + NumeroCFDIs.ToString() + "|" 
            //  
            if(estado == 3)
            {
                IdsPaquetes = xmlDoc.GetElementsByTagName("IdsPaquetes")[0].InnerXml;

                slqInsert = @"update solicitud set IdPaquete = '" + IdsPaquetes.ToString() + "' where Solicitud_Id = '" + vidSolicitud + "'";
                cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
                cnn.fnConectarSQLServer();
                cmdReader.ExecuteNonQuery();
                cmdReader.Dispose();

            }


            slqInsert = @"update solicitud set EstadoSolicitud_Id = "+ estado.ToString() + " where Solicitud_Id = '"+ vidSolicitud + "'";
            cmdReader = new SqlCommand(slqInsert, cnn.conexionSQLServer);
            cnn.fnConectarSQLServer();
            cmdReader.ExecuteNonQuery();
            cmdReader.Dispose();




            // y del lado donde se resive el resultado agregar mas logica para hacer un split de los datos
            //}
            return IdsPaquetes.ToString();
        }


    }
}

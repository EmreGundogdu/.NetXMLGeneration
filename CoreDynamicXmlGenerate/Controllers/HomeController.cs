using CoreDynamicXmlGenerate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;

namespace CoreDynamicXmlGenerate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            GenerateXML();
            return View();
        }   
        private void GenerateXML()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode docNode = xmlDocument.CreateXmlDeclaration("1.0","UTF-8",null);

            xmlDocument.AppendChild(docNode);
            XmlElement studentData = xmlDocument.CreateElement("StudentData");
            (studentData).SetAttribute("xmlns:xsi","http:www.abc.com");
            (studentData).SetAttribute("schemaLocation","http:www.abc.com/XMLSchema-instance","http://www.abc.com/ aaa.xsd");
            (studentData).SetAttribute("xmlns", "http:www.abc.com");

            xmlDocument.AppendChild(studentData);

            XmlNode headerNode = xmlDocument.CreateElement("Header");
            studentData.AppendChild(headerNode);

            XmlNode contentDateNode = xmlDocument.CreateElement("Content");
            contentDateNode.AppendChild(xmlDocument.CreateTextNode("2022-08-18"));
            headerNode.AppendChild(contentDateNode);

            XmlNode studentRecordsNode = xmlDocument.CreateElement("StudentRecords");
            xmlDocument.DocumentElement.AppendChild(studentRecordsNode);

            XmlNode studentRecordNode = xmlDocument.CreateElement("StudentRecord");
            studentRecordsNode.AppendChild(studentRecordNode);

            //Name
            XmlNode studentNameNode = xmlDocument.CreateElement("StudentName");
            studentNameNode.AppendChild(xmlDocument.CreateTextNode("EGndgd"));
            studentRecordNode.AppendChild(studentNameNode);

            //Group
            XmlNode studentGroupNode = xmlDocument.CreateElement("StudentGroup");
            studentGroupNode.AppendChild(xmlDocument.CreateTextNode("Technology"));
            studentRecordNode.AppendChild(studentGroupNode);

            //Address
            XmlNode addressNode = xmlDocument.CreateElement("Address");
            studentRecordNode.AppendChild(addressNode);


            XmlNode addressLineNode = xmlDocument.CreateElement("AddressLine");
            addressLineNode.AppendChild(xmlDocument.CreateTextNode("ABC Building, 21211"));
            addressNode.AppendChild(addressLineNode);


            XmlNode countryNode = xmlDocument.CreateElement("Country");
            countryNode.AppendChild(xmlDocument.CreateTextNode("TR"));
            addressNode.AppendChild(countryNode);


            //StudentSubs
            XmlNode studentSubs = xmlDocument.CreateElement("StudentSubs");
            studentRecordNode.AppendChild(studentSubs);


            //StudentSub
            XmlNode studentSub = xmlDocument.CreateElement("StudentSub");
            studentSubs.AppendChild(studentSub);


            XmlNode startDateNode = xmlDocument.CreateElement("StartDate");
            startDateNode.AppendChild(xmlDocument.CreateTextNode("2022-08-18"));
            studentSubs.AppendChild(startDateNode);



            XmlNode endDateNode = xmlDocument.CreateElement("EndDate");
            endDateNode.AppendChild(xmlDocument.CreateTextNode("2024-08-18"));
            studentSubs.AppendChild(endDateNode);




            var basePath = Path.Combine(Environment.CurrentDirectory, @"XMLFiles\");
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            var newFileName = string.Format("{0}{1}", Guid.NewGuid().ToString("N"),".xml");
            xmlDocument.Save(basePath + newFileName);
        }
    }
}
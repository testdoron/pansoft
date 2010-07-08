using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// ����ѡ���һЩʵ�÷���
    /// </summary>
    public static class OptionHelper
    {
        /// <summary>
        /// ȱʡ��XMLѡ���ļ�����Ŀ¼�б�
        /// </summary>
        public static readonly string[] OptionFileDefaultSearchPath = {
			"./", "./../", "./../../", "./../../../",
			"./../Option/", "./../../Option/", "./../../../Option/",
			Environment.CurrentDirectory + "/",
			AppDomain.CurrentDomain.SetupInformation.ApplicationBase
		};

        /// <summary>
        /// ��֤ѡ���ļ�·��������
        /// </summary>
        /// <param name="fileName">ѡ���ļ���</param>
        /// <param name="searchPath">����Ŀ¼�б�</param>
        /// <returns>����ѡ���ļ�·��</returns>
        public static string SearchOptionFile(string fileName, string[] searchPath)
        {
            if (File.Exists(fileName))
            {
                return fileName;
            }
            if (searchPath == null || searchPath.Length <= 0)
            {
                searchPath = OptionFileDefaultSearchPath;
            }
            foreach (string filePath in searchPath)
            {
                string fullName = Path.GetFullPath(filePath + fileName);
                if (File.Exists(fullName))
                {
                    return fullName;
                }
            }
            return null;
        }

        /// <summary>
        /// ������ͨ���ָ�����ļ�����
        /// </summary>
        /// <param name="filePattern">�ļ�ͨ���</param>
        /// <param name="searchPath">����Ŀ¼�б�</param>
        /// <returns>�ҵ����ļ��б�</returns>
        public static string[] SearchOptionFileWithPattern(string filePattern, string[] searchPath)
        {
            if (searchPath == null || searchPath.Length <= 0)
            {
                searchPath = OptionFileDefaultSearchPath;
            }
            List<string> foundFils = new List<string>();
            foreach (string filePath in searchPath)
            {
                string fullPath = Path.GetFullPath(filePath);
                if (Directory.Exists(fullPath))
                {
                    string[] files = Directory.GetFiles(fullPath, filePattern, SearchOption.TopDirectoryOnly);
                    foundFils.AddRange(files);
                }
            }
            return foundFils.ToArray();
        }

        /// <summary>
        /// ��Xml�ַ��������� <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlString">Xml�ַ���</param>
        /// <returns><see cref="IOption"/></returns>
        public static IOption CreateFromXmlString(string xmlString)
        {
            XmlNode xmlNode = LoadXmlNodeFromString(xmlString, "/");
            if (xmlNode is XmlDocument)
            {
                xmlNode = ((XmlDocument)xmlNode).DocumentElement;
            }
            return XmlOption.Create(null, xmlNode, true, null, null);
        }

        /// <summary>
        /// ��Xml�ļ������� <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlFileName">Xml�ļ�</param>
        /// <returns><see cref="IOption"/></returns>
        public static IOption CreateFromXmlFile(string xmlFileName)
        {
            return XmlOption.Create(xmlFileName);
        }

        /// <summary>
        /// �� <see cref="XmlNode"/> ���� <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlNode"><see cref="XmlNode"/></param>
        /// <returns><see cref="IOption"/></returns>
        public static IOption CreateFromXmlNode(XmlNode xmlNode)
        {
            return XmlOption.Create(null, xmlNode, true, null, null);
        }

        /// <summary>
        /// ����Դ��Uri�������� <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlSource">Uri�ַ���</param>
        /// <param name="sourceInType">�������Ƕ��Դ���ڵĳ���</param>
        /// <returns><see cref="IOption"/></returns>
        public static IOption CreateFromXmlSource(string xmlSource, Type sourceInType)
        {
            IOption setting = null;
            if (xmlSource.StartsWith("res://", true, null))
            {
                string sourceName = xmlSource.Substring(6);
                Assembly assembly = sourceInType.Assembly;
                Stream stream = assembly.GetManifestResourceStream(sourceName);
                if (stream == null)
                {
                    throw new OptionException("δ�ҵ���Դ" + xmlSource);
                }
                StreamReader sr = new StreamReader(stream);
                string xmlString = sr.ReadToEnd();
                setting = CreateFromXmlString(xmlString);
            }
            else if (xmlSource.StartsWith("http://", true, null))
            {
                throw new OptionException("δʵ��http://");
            }
            else
            {
                setting = CreateFromXmlFile(xmlSource);
            }
            return setting;
        }

        /// <summary>
        /// ��ȡXML�ļ�������
        /// </summary>
        /// <param name="fileName">XML�ļ���</param>
        /// <param name="sectionName">��Ӧ��XPath</param>
        /// <param name="rawType">�Ƿ񲻽����κ�ת��������</param>
        /// <returns>XmlNode</returns>
        public static XmlNode LoadXmlNodeFromFile(string fileName, string sectionName, bool rawType)
        {
            XmlDocument doc = new XmlDocument();
            LoadXmlFile(doc, fileName);
            XmlNode xmlNode = doc.SelectSingleNode(sectionName);
            if (xmlNode != null)
            {
                xmlNode = xmlNode.CloneNode(true);
            }
            if (!rawType && xmlNode is XmlDocument)
            {
                xmlNode = ((XmlDocument)xmlNode).DocumentElement;
            }
            return xmlNode;
        }

        /// <summary>
        /// ����XML�ַ�������
        /// </summary>
        /// <param name="xmlString">XML�ַ���</param>
        /// <param name="sectionName">��Ӧ��XPath</param>
        /// <returns>XmlNode</returns>
        public static XmlNode LoadXmlNodeFromString(string xmlString, string sectionName)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            XmlNode xmlNode = doc.SelectSingleNode(sectionName);
            if (xmlNode != null)
            {
                return xmlNode.CloneNode(true);
            }
            return xmlNode;
        }

        /// <summary>
        /// ����XML�ļ�����
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="fileName">�ļ���</param>
        private static void LoadXmlFile(XmlDocument doc, string fileName)
        {
            doc.Load(fileName);
        }
    }
}
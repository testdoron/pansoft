using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// 关于选项的一些实用方法
    /// </summary>
    public static class OptionHelper
    {
        /// <summary>
        /// 缺省的XML选项文件查找目录列表
        /// </summary>
        public static readonly string[] OptionFileDefaultSearchPath = {
			"./", "./../", "./../../", "./../../../",
			"./../Option/", "./../../Option/", "./../../../Option/",
			Environment.CurrentDirectory + "/",
			AppDomain.CurrentDomain.SetupInformation.ApplicationBase
		};

        /// <summary>
        /// 验证选项文件路径并返回
        /// </summary>
        /// <param name="fileName">选项文件名</param>
        /// <param name="searchPath">搜索目录列表</param>
        /// <returns>返回选项文件路径</returns>
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
        /// 查找由通配符指定的文件集合
        /// </summary>
        /// <param name="filePattern">文件通配符</param>
        /// <param name="searchPath">搜索目录列表</param>
        /// <returns>找到的文件列表</returns>
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
        /// 从Xml字符串中生成 <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlString">Xml字符串</param>
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
        /// 从Xml文件中生成 <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlFileName">Xml文件</param>
        /// <returns><see cref="IOption"/></returns>
        public static IOption CreateFromXmlFile(string xmlFileName)
        {
            return XmlOption.Create(xmlFileName);
        }

        /// <summary>
        /// 从 <see cref="XmlNode"/> 生成 <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlNode"><see cref="XmlNode"/></param>
        /// <returns><see cref="IOption"/></returns>
        public static IOption CreateFromXmlNode(XmlNode xmlNode)
        {
            return XmlOption.Create(null, xmlNode, true, null, null);
        }

        /// <summary>
        /// 从资源（Uri）中生成 <see cref="IOption"/>
        /// </summary>
        /// <param name="xmlSource">Uri字符串</param>
        /// <param name="sourceInType">如果是内嵌资源所在的程序集</param>
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
                    throw new OptionException("未找到资源" + xmlSource);
                }
                StreamReader sr = new StreamReader(stream);
                string xmlString = sr.ReadToEnd();
                setting = CreateFromXmlString(xmlString);
            }
            else if (xmlSource.StartsWith("http://", true, null))
            {
                throw new OptionException("未实现http://");
            }
            else
            {
                setting = CreateFromXmlFile(xmlSource);
            }
            return setting;
        }

        /// <summary>
        /// 获取XML文件的内容
        /// </summary>
        /// <param name="fileName">XML文件名</param>
        /// <param name="sectionName">对应的XPath</param>
        /// <param name="rawType">是否不进行任何转换而返回</param>
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
        /// 分析XML字符串内容
        /// </summary>
        /// <param name="xmlString">XML字符串</param>
        /// <param name="sectionName">对应的XPath</param>
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
        /// 载入XML文件内容
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="fileName">文件名</param>
        private static void LoadXmlFile(XmlDocument doc, string fileName)
        {
            doc.Load(fileName);
        }
    }
}
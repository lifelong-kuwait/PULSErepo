using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using TMS.Web;

namespace TMS
{
    public class Utility
    {
        #region"Attachments"

        public static bool MoveAttachment(string strSource, string strTarget, bool reusable)
        {
            try
            {
                //SPSecurity.RunWithElevatedPrivileges(delegate()
                //{
                FileAttributes attributes = File.GetAttributes(strSource);

                if (attributes == FileAttributes.ReadOnly)
                {
                    attributes = RemoveAttribute(attributes,
                                                 FileAttributes.ReadOnly);
                    File.SetAttributes(strSource, attributes);
                }

                //move attachment to its own directory
                File.Copy(strSource, strTarget);

                if (!reusable)
                {
                    //delete the temp file now
                    File.Delete(strSource);
                }
                //});
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        public static string CreateDirectory(String dirName)
        {
            string path = string.Empty;

            DirectoryInfo info = null;
            if (!Directory.Exists(dirName))
            {
                info = Directory.CreateDirectory(dirName);
                path = info.FullName;
            }
            else
            {
                path = dirName;
            }
            info = null;

            return path;
        }

        #endregion"Attachments"
        #region"DropDowns"

        public static List<DDlList> FillDropDownRecentYears(int objNoOfYears)
        {
            try
            {
                List<DDlList> _list = new List<DDlList>();

                int yearStart = DateTime.Now.Year;
                for (int count = 0; count <= objNoOfYears; count++)
                { int value = yearStart - count; _list.Add(new DDlList { Text = value.ToString(), Value = value }); }
                return _list;
            }
            catch (Exception)
            { return null; }
        }

        #endregion
    }
}
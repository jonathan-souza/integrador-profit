using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Security.AccessControl;

namespace Selia.Integrador.Utils
{
    public class Ftp
    {
        public static void Upload(string valor,string servidor,string fileName, string usuario, string senha, string diretorio, IEncoding type)
        {
            if (!string.IsNullOrEmpty(diretorio))
            {
                //object SpecialFolder = Activator.CreateInstance(Type.GetType("System.Environment+SpecialFolder"));
                //SpecialFolder.GetType().GetMember("Personal").GetValue(0);

                if (diretorio.Contains(":"))
                {
                    diretorio = diretorio + "\\" + fileName;//System.IO.Path.GetFileName(servidor);
                }
                else
                {
                    diretorio = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + diretorio;
                }

                string path = System.IO.Path.GetFullPath(diretorio);
                if (!System.IO.Directory.Exists(path))
                {
                    System.Security.AccessControl.DirectorySecurity sec = new System.Security.AccessControl.DirectorySecurity();
                    // Using this instead of the "Everyone" string means we work on non-English systems.
                    SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                    sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                    System.IO.Directory.CreateDirectory(path, sec);
                }
                type.SaveLocal(diretorio, fileName, valor);
                //System.IO.File.WriteAllText(diretorio+"\\"+System.IO.Path.GetFileName(servidor), valor);
            }

            if (!string.IsNullOrEmpty(servidor))
            {
                //FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(servidor));
                //request.Method = WebRequestMethods.Ftp.UploadFile;
                //request.Credentials = new NetworkCredential(usuario, senha);
                //Stream reqStream = null;

                //reqStream = request.GetRequestStream();
                //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(valor);
                //reqStream.Write(buffer, 0, buffer.Length);

                //reqStream.Close();
                type.SaveServer(servidor + "/" + fileName, usuario, senha, valor);
            }
        }              
       
        public static Dictionary<string, List<string>> ObterArquivos(string servidor, string usuario, string senha)
        {
            WebRequest webrequest = WebRequest.Create(servidor + "/Backup");
            webrequest.Method = WebRequestMethods.Ftp.MakeDirectory;
            webrequest.Credentials = new NetworkCredential(usuario, senha);

            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(servidor);
            request.UseBinary = true;
            request.Credentials = new NetworkCredential(usuario, senha);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.UseBinary = true;

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder sb = new StringBuilder();
            string[] Arquivos = reader.ReadToEnd().Split(new string[1] { "\r\n" }, StringSplitOptions.None);
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            foreach (string Arquivo in Arquivos)
            {
                if (!string.IsNullOrEmpty(Arquivo) && !string.IsNullOrEmpty(System.IO.Path.GetExtension(servidor + "/" + Arquivo)))
                {
                    string ArquivoLocal = System.IO.Path.GetFileName(Arquivo);
                    FtpWebRequest request2 = (FtpWebRequest)FtpWebRequest.Create(new Uri(servidor + "/" + ArquivoLocal));
                    request2.UseBinary = true;
                    request2.Credentials = new NetworkCredential(usuario, senha);
                    request2.Method = WebRequestMethods.Ftp.DownloadFile;
                    request2.UseBinary = true;
                    WebResponse response2 = request2.GetResponse();
                    StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                    List<string> Arquivos2 = reader2.ReadToEnd().Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
                    dic.Add(ArquivoLocal, Arquivos2);
                }
            }

            return dic;
        }
        public static void MoveBackup(string De, string Para, string Usuario, string Senha)
        {
            try
            {
                FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(new Uri(De));
                ftpReq.Credentials = new NetworkCredential(Usuario, Senha);
                ftpReq.Method = WebRequestMethods.Ftp.Rename;
                ftpReq.RenameTo = Para;
                ftpReq.UseBinary = true;
                FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();
            }
            catch (WebException e)
            {
                string status = ((FtpWebResponse)e.Response).StatusDescription;
            }
        }
    }

    public interface IEncoding
    {
        void SaveLocal(string diretorio, string fileName, string valor);
        void SaveServer(string servidor, string usuario, string senha, string valor);
    }

    public class UTF8: IEncoding
    {
        public void SaveLocal(string diretorio, string fileName, string valor)
        {
            System.IO.File.WriteAllText(diretorio + "\\" + fileName, valor);
        }

        public void SaveServer(string servidor, string usuario, string senha, string valor)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(servidor));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(usuario, senha);
            Stream reqStream = null;

            reqStream = request.GetRequestStream();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(valor);
            reqStream.Write(buffer, 0, buffer.Length);

            reqStream.Close();
        }
    }

    public class UTF8BOM: IEncoding
    {
        public void SaveLocal(string diretorio, string fileName, string valor)
        {
            using (TextWriter writer = new StreamWriter(diretorio + "\\" + fileName, false, new UTF8Encoding(true)))
            {
                writer.Write(valor);
                writer.Close();
            }
        }

        public void SaveServer(string servidor, string usuario, string senha, string valor)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(servidor));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(usuario, senha);
            Stream reqStream = null;

            reqStream = request.GetRequestStream();
            using (TextWriter writer = new StreamWriter(reqStream, new UTF8Encoding(true)))
            {
                writer.Write(valor);
                writer.Close();
            }
            reqStream.Close();
        }
    }
}

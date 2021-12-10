using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using Microsoft.Security.Application;
using System.Net;
using Newtonsoft.Json;
using iTextSharp.text.pdf;
using System.Xml;
using System.Security.AccessControl;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            string filename = Request.QueryString["filename"].ToString();
            System.IO.File.Delete(filename);

            // ValidateCaptcha("abc");


            //if (!Directory.Exists(@"C:\inetpub\wwwroot\VLRApp\VLRData\ImagesLog\DummyImages\\"))
            //{
            //    System.Security.AccessControl.DirectorySecurity directorySecurity = new System.Security.AccessControl.DirectorySecurity();

            //    Directory.CreateDirectory(DestinationFilePath, new DirectoryInfo(DestinationFilePath).GetAccessControl());
            //}



            //HttpUtility.UrlEncode("C:\inetpub\wwwroot\VLRApp\VLRData\ImagesLog\DummyImages\\"");
            //string Path = @"~/Content/VeracodeFlaws.pdf";
            //string returnedPath = HttpUtility.HtmlEncode(Path);

            //string DestinationFilePath = @"C:\Users\hamid.rasheed\source\repos\ConsoleApp1\WebApplication2\Content\content2";
            ////LogDebug(returnedPath);

            //if (!Directory.Exists(DestinationFilePath))
            //{
            //    DirectorySecurity securityRules = new DirectorySecurity();
            //    securityRules.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl,
            //                                                            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            //                                                            PropagationFlags.NoPropagateInherit,
            //                                                            AccessControlType.Allow));
            //    Directory.CreateDirectory(DestinationFilePath, securityRules);

            //}



            //FileSecurity fileSecurity = new FileSecurity();
            //fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.CreateFiles,
            //                                                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            //                                                        PropagationFlags.NoPropagateInherit,
            //                                                        AccessControlType.Allow));
            //string outputPdfPath = @"C:\Users\hamid.rasheed\source\repos\ConsoleApp1\WebApplication2\Content\xyz.txt";
            //FileStream fileStream = new FileStream(outputPdfPath, FileMode.Create);
            //fileStream.SetAccessControl(fileSecurity);



            //var pDoc = new XmlDocument();
            //pDoc.Load(@"c:\abc.xml");

        

            ////pDoc.SelectSingleNode("<note>").Attributes[pAttributeName].Value;
            //string attribute = pDoc.SelectSingleNode("note").Attributes["success"].Value;



            //string subPath = "abc.pdf";
            //string localVlrDataPath = System.Configuration.ConfigurationManager.AppSettings["LocalVlrDataPath"] ?? string.Empty;

            //string finalPath = localVlrDataPath + "\\" + subPath;

            //string fullDesDirPath = Path.GetFullPath(localVlrDataPath + Path.DirectorySeparatorChar);

            //string fileName = Path.GetFileName(finalPath);
            //if (finalPath.StartsWith(fullDesDirPath, StringComparison.Ordinal))
            //{

            //}


            //string destinationFile = @"C:\Users\hamid.rasheed\source\repos\ConsoleApp1\WebApplication2\Content\abc.pdf";
            //destinationFile = Sanitizer.GetSafeHtmlFragment(destinationFile);
            //string extension = ".pdf";

            //if (Path.GetExtension(destinationFile) == extension)
            //{

            //}


            //string dest = Sanitizer.GetSafeHtmlFragment(@"C:\Users\hamid.rasheed\source\repos\ConsoleApp1\WebApplication2\Content\");

            //string outputPath = @"C:\Users\hamid.rasheed\source\repos\ConsoleApp1\WebApplication2\Content\abc.txt";

            //if (!System.IO.File.Exists(outputPath))
            //{
            //    using (var file = System.IO.File.Create(Sanitizer.GetSafeHtmlFragment(outputPath)))
            //    {
            //        System.IO.File.SetAttributes(outputPath, FileAttributes.Normal);
            //    }
            //}

            //System.Security.Cryptography.RNGCryptoServiceProvider provider = new System.Security.Cryptography.RNGCryptoServiceProvider();
            //int randomInteger = 0;
            //do
            //{
            //    byte[] byteArray = new byte[sizeof(short)];
            //    provider.GetBytes(byteArray);
            //    randomInteger = BitConverter.ToUInt16(byteArray, 0);
            //} while (randomInteger < 0 || randomInteger > 10000000);


            //LogDebug(randomInteger.ToString());
            return View();
        }


        [ValidateInput(true)]
        public ActionResult ValidateCaptcha(string recaptcharesponse)
        {
            string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["ReCaptchaPrivateKey"];

            string santized_recaptcharesponse = Sanitizer.GetSafeHtmlFragment(recaptcharesponse);

            var client = new WebClient();
            string url = Sanitizer.GetSafeHtmlFragment(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", Sanitizer.GetSafeHtmlFragment(secret), Sanitizer.GetSafeHtmlFragment(recaptcharesponse)));

            var image_host_regex = new System.Text.RegularExpressions.Regex("^[a-z]{1,10}$");
            if (!image_host_regex.Match(url).Success)
            {
                throw new ArgumentException("Source URL is invalid.");
            }

            Uri uri = new Uri(url, UriKind.Absolute);
            client.UseDefaultCredentials = true;
            var jsonResult = client.DownloadString(uri);
            string res = jsonResult.ToString();
            return View();
        }

        public string GetLoanDocumentImage()
        {
            return Sanitizer.GetSafeHtmlFragment(Url.Content("~/Content/VeracodeFlaws.pdf"));
        }
        public void gridName()
        {
            var random = RandomNumberGenerator.Create("System.Security.Cryptography.RandomNumberGenerator");
            var bytes = new byte[sizeof(short)];
            random.GetNonZeroBytes(bytes);
            string gridName = Math.Abs(BitConverter.ToInt16(bytes, 0)).ToString();
            LogDebug(gridName);
        }
        public void Mod()
        {
            int num = 17;
            int num2 = 5;
            int res = num / num2;

        }

        public void CryptoServiceProvider(int min, int max)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();


            //for (int i = 0; i < 100; i++)
            //{
            int randomInteger = 0;
            do
            {
                byte[] byteArray = new byte[sizeof(short)];
                provider.GetBytes(byteArray);

                //convert 4 bytes to an integer
                randomInteger = BitConverter.ToUInt16(byteArray, 0);

            } while (randomInteger < min || randomInteger > max);

            LogDebug(randomInteger);



            //string randomInteger = Convert.ToBase64String(byteArray);
            //int randomInteger = byteArray[0];

            //if (randomInteger % 2 == 1)
            //{
            //    LogDebug("Random Number: " + randomInteger + "  MOD: " + randomInteger / (randomInteger / 2));
            //}


            //int value = byteArray[0];
            //var rem = value + byteArray[1] % 99;

            //if (rem < 1)
            //    rem += 1;

            //LogDebug(rem);
            //}

            //var byteArray2 = new byte[8];
            //provider.GetBytes(byteArray2);

            ////convert 8 bytes to a double
            //var randomDouble = BitConverter.ToDouble(byteArray2, 0);
        }

        public void AppCode()
        {
            var random = RandomNumberGenerator.Create("System.Security.Cryptography.RandomNumberGenerator");
            var bytes = new byte[sizeof(short)];
            random.GetBytes(bytes);
            var num = BitConverter.ToUInt16(bytes, 0);
            LogDebug(num);
        }
        public void BytesGen()
        {
            var randomGenerator = RandomNumberGenerator.Create();
            byte[] data = new byte[1];
            randomGenerator.GetBytes(data);
            LogDebug(BitConverter.ToUInt16(data, 0));
        }
        public void DataEncode()
        {
            string error = @"<![CDATA[System.Data.SqlClient.SqlException (0x80131904): A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server) ---> System.ComponentModel.Win32Exception (0x80004005): The network path was not found
   at System.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, SqlCredential credential, Object providerInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString userConnectionOptions, SessionData reconnectSessionData, DbConnectionPool pool, String accessToken, Boolean applyTransientFaultHandling, SqlAuthenticationProviderManager sqlAuthProviderManager)
   at System.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, Object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions)
   at System.Data.ProviderBase.DbConnectionFactory.CreatePooledConnection(DbConnectionPool pool, DbConnection owningObject, DbConnectionOptions options, DbConnectionPoolKey poolKey, DbConnectionOptions userOptions)
   at System.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at System.Data.ProviderBase.DbConnectionPool.UserCreateRequest(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, UInt32 waitForMultipleObjectsTimeout, Boolean allowCreate, Boolean onlyOneCheckConnection, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionFactory.TryGetConnection(DbConnection owningConnection, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal oldConnection, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionInternal.TryOpenConnectionInternal(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   at System.Data.SqlClient.SqlConnection.TryOpenInner(TaskCompletionSource`1 retry)
   at System.Data.SqlClient.SqlConnection.TryOpen(TaskCompletionSource`1 retry)
   at System.Data.SqlClient.SqlConnection.Open()
   at System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   at System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   at System.Data.Common.DbDataAdapter.Fill(DataSet dataSet)
   at Microsoft.Practices.EnterpriseLibrary.Data.Database.DoLoadDataSet(DBCommandWrapper command, DataSet dataSet, String[] tableNames)
   at Microsoft.Practices.EnterpriseLibrary.Data.Database.LoadDataSet(DBCommandWrapper command, DataSet dataSet, String[] tableNames)
   at Microsoft.Practices.EnterpriseLibrary.Data.Database.LoadDataSet(DBCommandWrapper command, DataSet dataSet, String tableName)
   at Visionet.Visiflow.DAL.WorkflowTemplateDAO.GetTemplate() in D:\Projects\PNQ\Source Code Dev\Visionet.VLR\VLR_Backend\Visionet.Visiflow.DAL\WorkflowTemplateDAO.cs:line 112
   at Visionet.Visiflow.BLL.WorkflowService.Init() in D:\Projects\PNQ\Source Code Dev\Visionet.VLR\VLR_Backend\Visionet.Visiflow.BLL\WorkflowService.cs:line 53
   at Visionet.Facade.WFManager.Init() in D:\Projects\PNQ\Source Code Dev\Visionet.VLR\VLR_Backend\Visionet.Facade\VF2\WFManager.vb:line 17
   at Visionet.VLR.Backend.Facade.VLRApplicationStartEvents.Application_Start() in D:\Projects\PNQ\Source Code Dev\Visionet.VLR\Visionet.VLR.Backend.Facade\VLRApplicationStartEvents.vb:line 36
   at Visionet.VLR.DomainRepository.ScreenConfiguration.VLRStartApplicationEvent() in D:\Projects\PNQ\Source Code Dev\Visionet.VLR\Visionet.VLR.DomainRepository.ScreenConfigurations\ScreenConfiguration.cs:line 434
ClientConnectionId:00000000-0000-0000-0000-000000000000
Error Number:53,State:0,Class:20]]>";

            string safeContent = Microsoft.Security.Application.Sanitizer.GetSafeHtmlFragment(error);
            //string safeContent = Microsoft.Security.Application.Encoder.XmlEncode(error);
            //string safeContent = Microsoft.SharePoint.Utilities.SPHttpUtility.HtmlEncode(error);

            //string safeContent = error;
            string fullPath = @"D:\Temp\test.txt";

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(safeContent);
            }

            LogDebug(safeContent);
        }

        public void test1()
        {
            object message = @"<![CDATA[TOKEN Details are ==&gt; {&quot;access_token&quot;:&quot;XZhOFLYi93ee9825EljxMdH7aVxXZJge79xlQTAvQvXYwdmjtCIIYYV8ahRw07tJAemngcfMcgv8FFgmMJfRb14YcFCt94Ku-DkJFV7srsOV37Q6Pc8s7ZycwV2O5X4lzu3csRXg2ZbK313C_lFTTJbmf-a6h3t9hjfFJJhS3tBULFD1kghAmEGcitSesT3qG7HhJihzWnJYrG39DMlRM0z40jfV7mkiYPybbIsX7E6u5pJ30C0C6u5wv-fLLRQw&quot;,&quot;token_type&quot;:&quot;bearer&quot;,&quot;expires_in&quot;:3599,&quot;refresh_token&quot;:&quot;53c358e658a04c2ebc4fe08fd15e56f1&quot;,&quot;as:client_id&quot;:&quot;VLR App&quot;,&quot;.issued&quot;:&quot;Fri, 17 Sep 2021 14:49:41 GMT&quot;,&quot;.expires&quot;:&quot;Fri, 17 Sep 2021 15:49:41 GMT&quot;} &lt;== GetTokenInfo Method of LoginController.cs]]>";

            //Microsoft.Security.Application.Sanitizer.GetSafeHtml(message)
            //string cleanmessage = Microsoft.Security.Application.Sanitizer.GetSafeHtml(message.ToString()); //System.Security.SecurityElement.Escape(message.ToString());
            //string cleanmessage = message.ToString().Replace("\n", "").Replace("\r", "");

            //string url = @"\\ImagesLog\\DummyImages";
            string fullPath = @"D:\Temp\test.txt";
            // Write file using StreamWriter  
            //message = System.Security.SecurityElement.Escape(message.ToString());

            //using (StreamWriter writer = new StreamWriter(fullPath))
            //{
            //    //writer.WriteLine(Microsoft.Security.Application.Encoder.HtmlEncode(message.ToString()));
            //    writer.WriteLine(Encoding.ASCII.GetString(System.Net.WebUtility.HtmlDecode(message.ToString())));
            //}
            //// Read a file  
            //string readText = System.IO.File.ReadAllText(fullPath);
            //Console.WriteLine(readText);

            //LogDebug(readText);
        }

        public void LoadTest()
        {
            int UserId = 1600;
            string loan_deficiency_ids = "1,2,3";
            string Query = "UPDATE  dbo.LAP_Loan_Deficiencies " + Environment.NewLine + " set " + Environment.NewLine;
            for (int i = 0; i < 10; i++)
            {
                Query += i + "Name='" + i + "'";
                Query += "," + Environment.NewLine;
            }

            Query += string.Format("Modified_By='{0}',", UserId.ToString());
            Query += Environment.NewLine;
            Query += "Modified_Date=getdate()";
            Query += Environment.NewLine;
            Query += string.Format("WHERE loan_deficiency_id IN (SELECT * FROM dbo.Split('{0}', ',')) ", loan_deficiency_ids);

            string encodedQuery = System.Security.SecurityElement.Escape(Query);
            string decodedQuery = HttpUtility.HtmlDecode(System.Security.SecurityElement.Escape(Query));
            string simpleQuery = Query;

            LogDebug(encodedQuery);
            LogDebug(decodedQuery);
            LogDebug(Query);
        }

        public void LogDebug(object message)
        {
            string newline = "<br/>";
            System.Web.HttpContext.Current.Response.Write(Environment.NewLine);
            System.Web.HttpContext.Current.Response.Write(newline);
            System.Web.HttpContext.Current.Response.Write(message);
            //System.Web.HttpContext.Current.Response.Flush();
            //System.Web.HttpContext.Current.Response.End();


        }

        public void bytecode()
        {

            string source = "0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38";
            byte[] result = source.Split(',').Select(s => Convert.ToByte(s.Trim(), 16)).ToArray();
            var bytes = new byte[] { };// { source.Split(',').Select(s => Convert.ToByte(s, 16)).ToArray() };

            var theVector = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };
            //RandomNumberGenerator random = RandomNumberGenerator.Create("System.Security.Cryptography.RandomNumberGenerator");
            //Random RD = new Random();


            //var random = RandomNumberGenerator.Create("System.Security.Cryptography.RandomNumberGenerator");
            //var bytes = new byte[sizeof(int)]; // 4 bytes
            //random.GetNonZeroBytes(bytes);
            //var result = new Random(BitConverter.ToInt32(bytes, 0)).Next(0, 1000).ToString();

            System.Web.HttpContext.Current.Response.Write(BitConverter.ToInt32(result, 0).ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();

            //var data = random.ToString();
            //var url = GetLoanDocumentImage();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


    }
}
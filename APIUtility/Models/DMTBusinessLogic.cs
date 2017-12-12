using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace APIUtility.Models
{
    public class DMTBusinessLogic
    {
        public string strData;
        public DataTable dtRecord;

        public void MySQLConnection()
        {

            using (var client = new SshClient("52.74.21.139", "anils", "P&ssw0rd1122")) // establishing ssh connection to server where MySql is hosted
            {
                client.Connect();
                if (client.IsConnected)
                {
                    var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;UID=anils;PASSWORD=$Tran$erv891;DATABASE=transerv_db"))
                    {
                        using (MySqlCommand com = new MySqlCommand("select * from rmt_api_user", con))
                        {
                            com.CommandType = CommandType.Text;
                            DataSet ds = new DataSet();
                            MySqlDataAdapter da = new MySqlDataAdapter(com);
                            da.Fill(ds);
                            foreach (DataRow drow in ds.Tables[0].Rows)
                            {
                                // Console.WriteLine("From MySql: " + drow[1].ToString());
                                strData = strData + "-----" + drow[1].ToString();
                            }
                            HttpContext.Current.Response.Write("API User Details Data - " + strData);
                        }
                    }
                    client.Disconnect();
                }
                else
                {
                    Console.WriteLine("Client cannot be reached...");
                }
            }
        }
        //public DataTable getMerchantDetailsLocal()
        //{
        //    //try
        //    //{
        //    //    objAgentDetails_Local = new List<tbl_RemittanceAgentDetails>;
        //    //    HostedCheckout_UDIO.Models.DMTNewAPIModels obj = new DMTNewAPIModels();
        //    //    HostedCheckout_UDIO.EF.
        //    //    dtRecord = new DataTable();
        //    //    return dtRecord;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //    //finally
        //    //{
        //    //    dtRecord.Dispose();
        //    //}
        //}



        public DataSet getAgentDetail()
        {
            DataSet ds = new DataSet();
            try
            {
                using (var client = new SshClient("52.74.21.139", "anils", "P&ssw0rd1122")) // establishing ssh connection to server where MySql is hosted
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                        client.AddForwardedPort(portForwarded);
                        portForwarded.Start();
                        using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;UID=anils;PASSWORD=$Tran$erv891;DATABASE=transerv_db"))
                        {
                            using (MySqlCommand com = new MySqlCommand("select * from rmt_api_user", con))
                            {
                                com.CommandType = CommandType.Text;

                                MySqlDataAdapter da = new MySqlDataAdapter(com);
                                da.Fill(ds);
                            }
                        }
                        client.Disconnect();

                    }
                    //else
                    //{
                    //    Console.WriteLine("Client cannot be reached...");
                    //}
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }
    }
}
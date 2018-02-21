using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTCZ_API_Test
{
    public class Blockdata // Variables that will be filled by our respective API calls
    {

        //getBlock
        public string Hash { get; set; }
        public string Size { get; set; } //
        public string Height { get; set; }
        public string Version { get; set; } //
        public string Merkleroot { get; set; }
        public string[] Tx { get; set; }
        public string Nonce { get; set; }
        public string Solution { get; set; }
        public string Bits { get; set; }
        public string Difficulty { get; set; } //
        public string Chainwork { get; set; }
        public string Confirmations { get; set; } //
        public string PreviousBlockHash { get; set; }
        public string NextBlockHash { get; set; }
        public string Reward { get; set; }
        public string IsMainChain { get; set; }
        //public string[] PoolInfo { get; set; } // Present but unused variable

        //getBlockIndex
        public string BlockHash { get; set; } //

        //getTransactions
        public string Txid { get; set; }
        public string LockTime { get; set; }
        /* Nested data - Work in progress
        public string[] Vin { get; set; }
        public string Coinbase { get; set; }
        public string Sequence { get; set; }
        public string N { get; set; }
        public string Vout { get; set; }
        public string Value { get; set; }
        public string Hex { get; set; }
        public string Asm { get; set; }
        public string Addresses { get; set; }
        public string Type { get; set; }
        public string SpentTxId { get; set; }
        public string SpentIndex { get; set; }
        public string SpentHeight { get; set; }
        */
        public string BlockHeight { get; set; }
        public string BlockTime { get; set; }
        public string IsCoinBase { get; set; }
        public string ValueOut { get; set; }


        //getWalletInfo
        public string AddrStr { get; set; }
        public string Balance { get; set; }
        public string BalanceSat { get; set; }
        public string TotalReceived { get; set; }
        public string TotalReceivedSat { get; set; }
        public string TotalSent { get; set; }
        public string TotalSentSat { get; set; }
        public string UnconfirmedBalance { get; set; }
        public string UnconfirmedBalanceSat { get; set; }
        public string UnconfirmedTxApperances { get; set; }
        public string TxApperances { get; set; }
        public string[] Transactions { get; set; }
        public decimal Timestamp { get; set; }


        // Used in various calls
        public string Time { get; set; } //
    }

    public class Info
    {
        //getInfo
        public string Version { get; set; }
        public string ProtocolVersion { get; set; }
        public string Blocks { get; set; }
        public string TimeOffset { get; set; }
        public string Connections { get; set; }
        public string Proxy { get; set; }
        public string Difficulty { get; set; }
        public string TestNet { get; set; }
        public string Relayfee { get; set; }
        public string Errors { get; set; }
        public string Network { get; set; }
    }

    public class RootObjects
    {
        Info info { get; set; }
    }

    public class UserDefinedParams
        {
            //User Parameters
            public static string address = "t1Y4QACu5S6udREAEjNZgEFWLT6TASncfcL";
            //public static string blockhash = "0007844681f84249ad7829f9673ea4b6d26a139c741c5847926aff944337d908";
            public static string blockhash = "0007844681f84249ad7829f9673ea4b6d26a139c741c5847926aff944337d908";
            public static string blockindex = "1";
            public static string txid = "0a70d135d95a190435be8cc41ea02cfce61a9c9e39cd8e7515a50d52e49c57d7";


            //User Parameters

        }

        class Program
        {
            static HttpClient client = new HttpClient();

            static async Task getBlock(string blockhash)
            {
                Blockdata blockdata = null; // clear out the variable objects before populating them.
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/block/" + blockhash);

                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    blockdata = await response.Content.ReadAsAsync<Blockdata>();

                    Console.WriteLine("Hash is:" + blockdata.Hash);
                    Console.WriteLine("Size is:" + blockdata.Size);
                    Console.WriteLine("Height is:" + blockdata.Height);
                    Console.WriteLine("Version is:" + blockdata.Version);
                    Console.WriteLine("Merkleroot is:" + blockdata.Merkleroot);
                    Console.WriteLine("Tx is:" + blockdata.Tx[0]);
                    Console.WriteLine("Nonce is:" + blockdata.Nonce);
                    Console.WriteLine("Solution is:" + blockdata.Solution);
                    Console.WriteLine("Bits is:" + blockdata.Bits);

                    Console.WriteLine("Difficulty is:" + blockdata.Difficulty);
                    Console.WriteLine("Chainwork is:" + blockdata.Chainwork);
                    Console.WriteLine("Confirmations is:" + blockdata.Confirmations);
                    Console.WriteLine("PreviousBlockHash is:" + blockdata.PreviousBlockHash);
                    Console.WriteLine("NextBlockHash is:" + blockdata.NextBlockHash);
                    Console.WriteLine("Reward is:" + blockdata.Reward);
                    Console.WriteLine("IsMainChain is:" + blockdata.IsMainChain);
                    //Console.WriteLine("PoolInfo is:" + blockdata.PoolInfo);

                }
            }

            static async Task getBlockIndex(string blockindex)
            {
                Blockdata blockdata = null; // clear out the variable objects before populating them.
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/block-index/" + blockindex);

                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    blockdata = await response.Content.ReadAsAsync<Blockdata>();
                    Console.WriteLine("Hash is:" + blockdata.BlockHash);

                }
            }

            static async Task getTransaction(string txid)
            {
                Blockdata blockdata = null; // clear out the variable objects before populating them.
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/tx/" + txid);



                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    blockdata = await response.Content.ReadAsAsync<Blockdata>();
                    Console.WriteLine("Txid is:" + blockdata.Txid);
                    Console.WriteLine("Version is:" + blockdata.Version);
                    Console.WriteLine("LockTime is:" + blockdata.LockTime);
                    /* Nested data - Work in progress
                    Console.WriteLine("Vin is:" + blockdata.Vin[0]);
                    Console.WriteLine("Coinbase is:" + blockdata.Coinbase);
                    Console.WriteLine("Sequence is:" + blockdata.Sequence);
                    Console.WriteLine("N is:" + blockdata.N);
                    Console.WriteLine("Vout is:" + blockdata.Vout);
                    Console.WriteLine("Value is:" + blockdata.Value);
                    Console.WriteLine("Hex is:" + blockdata.Hex);
                    Console.WriteLine("Asm is:" + blockdata.Asm);
                    Console.WriteLine("Addresses is:" + blockdata.Addresses);
                    Console.WriteLine("Type is:" + blockdata.Type);
                    Console.WriteLine("SpentTxId is:" + blockdata.SpentTxId);
                    Console.WriteLine("SpentIndex is:" + blockdata.SpentIndex);
                    Console.WriteLine("SpentHeight is:" + blockdata.SpentHeight);
                    */
                    Console.WriteLine("BlockHash" + blockdata.BlockHash);
                    Console.WriteLine("BlockHeight is:" + blockdata.BlockHeight);
                    Console.WriteLine("Confirmations is:" + blockdata.Confirmations);
                    Console.WriteLine("Time is:" + blockdata.Time);
                    Console.WriteLine("BlockTime is:" + blockdata.BlockTime);
                    Console.WriteLine("IsCoinBase is:" + blockdata.IsCoinBase);
                    Console.WriteLine("ValueOut is:" + blockdata.ValueOut);
                    Console.WriteLine("Size is:" + blockdata.Size);
                }
            }

            static async Task getAddress(string address)
            {
                Blockdata blockdata = null; // clear out the variable objects before populating them.
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/addr/" + address);

                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    blockdata = await response.Content.ReadAsAsync<Blockdata>();

                    Console.WriteLine("Balance is:" + blockdata.Balance);
                    Console.WriteLine("Address is:" + blockdata.AddrStr);

                    Console.WriteLine("BalanceSat is:" + blockdata.BalanceSat);
                    Console.WriteLine("TotalReceived is:" + blockdata.TotalReceived);
                    Console.WriteLine("TotalReceivedSat is:" + blockdata.TotalReceivedSat);
                    Console.WriteLine("TotalSent is:" + blockdata.TotalSent);
                    Console.WriteLine("TotalSentSat is:" + blockdata.TotalSentSat);
                    Console.WriteLine("UnconfirmedBalance is:" + blockdata.UnconfirmedBalance);
                    Console.WriteLine("UnconfirmedBalanceSat is:" + blockdata.UnconfirmedBalanceSat);
                    Console.WriteLine("UnconfirmedTxAppearances is:" + blockdata.UnconfirmedTxApperances);
                    Console.WriteLine("TxAppearances is:" + blockdata.TxApperances);


                    int instance = 0;
                    foreach (string n in blockdata.Transactions)
                    {
                        instance++;
                        Console.WriteLine("Txid is:" + blockdata.Transactions[instance - 1]);
                    }
                }



            }


            static async Task getInfo() //Using Newtonsoft JSON for deserialization of nested data.
            {
                
                string infostring;
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/status/");

                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                infostring = await response.Content.ReadAsStringAsync();
                var jsonObj = JsonConvert.DeserializeObject<JObject>(infostring).First.First;


                //Console.WriteLine(jsonObj);

                Console.WriteLine("Version is :" + jsonObj["info.version"]);
                Console.WriteLine("Protocol Version is: " + jsonObj["protocolversion"]);
                Console.WriteLine("Blocks is: " + jsonObj["blocks"]);
                Console.WriteLine("TimeOffset is: " + jsonObj["timeoffset"]);
                Console.WriteLine("Connections is: " + jsonObj["connections"]);
                Console.WriteLine("Proxy is: " + jsonObj["proxy"]);
                Console.WriteLine("Difficulty is: " + jsonObj["difficulty"]);
                Console.WriteLine("TestNet is: " + jsonObj["testnet"]);
                Console.WriteLine("Relayfee is: " + jsonObj["relayfee"]);
                Console.WriteLine("Errors is: " + jsonObj["errors"]);
                Console.WriteLine("Network is: " + jsonObj["network"]);

            }

            }


            static void Main(string[] args)
            {

                    RunAsync().GetAwaiter().GetResult();
                
            }

            static async Task RunAsync()
            {
            int selection;
                // Define location and port of our Insight Server, then clear and add headers for JSON interaction
                client.BaseAddress = new Uri("http://192.168.0.93:3001");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            try
            {

                bool loop = true;

                while (loop == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please choose from the following options");
                    Console.WriteLine("1. Get block data using blockhash.");
                    Console.WriteLine("2. Get blockhash by providing block number.");
                    Console.WriteLine("3. Get Transaction details using TXID.");
                    Console.WriteLine("4. Get all transactions associated with a given address.");
                    Console.WriteLine("5. Get status information for the BitcoinZ network.");
                    Console.WriteLine("6. Quit.");
                    selection = Convert.ToInt32(Console.ReadLine());
                    Convert.ToInt32(selection);

                    switch (selection)
                    {
                        case 1:
                            //Prints the details of a specific blockhash
                            await getBlock(UserDefinedParams.blockhash);
                            break;

                        case 2:
                            //Prints the details of a specific blockhash
                            await getBlockIndex(UserDefinedParams.blockindex);
                            break;

                        case 3:
                            //Prints the Details of a specific transactionID
                            await getTransaction(UserDefinedParams.txid);
                            break;

                        case 4:
                            //Prints the details of a wallet address and printing to the screen
                            await getAddress(UserDefinedParams.address);
                            break;

                        case 5:
                            //Gets network statistics
                            await getInfo();
                            break;

                        case 6:
                            //Gets network statistics
                            System.Environment.Exit(1);
                            break;

                        default:
                            Console.WriteLine("Invalid selection, Please try again.");
                            break;
                    }
                }










            }


                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();

            }
        }
    
}

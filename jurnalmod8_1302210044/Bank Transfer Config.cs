using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jurnalmod8_1302210044

{
    internal class BankTransferConfig
    {
        public string lang { get; set; }
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public string meth1 { get; set; }
        public string meth2 { get; set; }
        public string meth3 { get; set; }
        public string meth4 { get; set; }

        public string en { get; set; }
        public string id { get; set; }
        public BankTransferConfig() { }
        public BankTransferConfig(string lang, int threshold,
            int low_fee, int high_fee, string meth1, string meth2,
            string meth3, string meth4, string en, string id)
        {
            this.lang = lang;
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
            this.meth1 = meth1;
            this.meth2 = meth2;
            this.meth3 = meth3;
            this.meth4 = meth4;
            this.en = en;
            this.id = id;
        }

        public void changeLang_1302210044()
        {
            if (lang == "en")
            {
                lang = "id";
            }
            else
            {
                lang = "en";
            }
        }
    }

    class readJson
    {
        public BankTransferConfig bankTfCon;
        public const string readFile = "D:\\KONSTRUKSI PERANGKAT LUNAK\\jurnalmod8_1302210044\\jurnalmod8_1302210044\\Bank Transfer Config.json" +
            "D:\\KONSTRUKSI PERANGKAT LUNAK\\jurnalmod8_1302210044\\jurnalmod8_1302210044\\Bank Transfer Config.cs"
            ;
        public readJson()
        {
            try
            {
                readConfigFile_1302210044();
            }
            catch (Exception)
            {
                setDefault_1302210044();
                writeNewConfigFile_1302210044();
            }
        }

        private BankTransferConfig readConfigFile_1302210044()
        {
            string configJson = File.ReadAllText(readFile);
            bankTfCon = JsonSerializer.Deserialize<BankTransferConfig>(configJson);
            return bankTfCon;
        }

        private void setDefault_1302210044()
        {
            int threshold = 25000000;
            int low_fee = 6500;
            int high_fee = 15000;
            string meth1 = "1. RTO (real-time)";
            string meth2 = "2. SKN";
            string meth3 = "3. RTGS";
            string meth4 = "4. BI FAST";
            string en = "yes";
            string id = "ya";
            bankTfCon = new BankTransferConfig("id", threshold, low_fee,
                high_fee, meth1, meth2, meth3, meth4, en, id);
        }

        private void writeNewConfigFile_1302210044()
        {
            JsonSerializerOptions opt = new JsonSerializerOptions() { WriteIndented = true };

            string jsonStr = JsonSerializer.Serialize(bankTfCon, opt);
        }
    }
}
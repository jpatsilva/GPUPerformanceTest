using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace QuickstartInteractiveDataDisplay
{
    public class ProcessData
    {
        //string rawPropertyFile   = "./output/raw.txt";
        //string valuePropertyFile = "./output/values.txt";

        int recordCount    = 0;
        int linesPerRecord = 6;

        public List<string> record          = new List<string>();
        public List<DataObject> dataObjects = new List<DataObject>();

        public void ProcessDataObject()
        {
            // Read a text file line by line.
            string[] lines = File.ReadAllLines("./data/288440_results.txt");
            List<string[]> rawStringRecords = new List<string[]>();

            recordCount = lines.Length / linesPerRecord;

            for (int k = 0; k < recordCount; k++)
            {
                string[] rawRecords = new string[6];

                for (int l = 0; l < linesPerRecord; l++)
                {
                    rawRecords[l] = lines[(k * linesPerRecord) + l];
                }
                rawStringRecords.Add(rawRecords);
            }

            foreach (string[] record in rawStringRecords)
            {
                // create a new instance of a data object
                DataObject dataObject = new DataObject();

                // line1 will contain all data items in the dispatch line
                string[] line1 = record[0].Split(',');

                dataObject.dispatchValue = Convert.ToInt32(ProcessProperty(line1[0]));
                dataObject.gpuIDValue = Convert.ToInt32(ProcessProperty(line1[1]));
                dataObject.queueIDValue = Convert.ToInt32(ProcessProperty(line1[2]));
                dataObject.queueIndexValue = Convert.ToInt32(ProcessProperty(line1[3]));
                dataObject.processIDValue = Convert.ToInt32(ProcessProperty(line1[4]));
                dataObject.threadIDValue = Convert.ToInt32(ProcessProperty(line1[5]));
                dataObject.grdValue = Convert.ToInt32(ProcessProperty(line1[6]));
                dataObject.wgrValue = Convert.ToInt32(ProcessProperty(line1[7]));
                dataObject.ldsValue = Convert.ToInt32(ProcessProperty(line1[8]));
                dataObject.scrValue = Convert.ToInt32(ProcessProperty(line1[9]));
                dataObject.archVgprValue = Convert.ToInt32(ProcessProperty(line1[10]));
                dataObject.accumVgprValue = Convert.ToInt32(ProcessProperty(line1[11]));
                dataObject.sgprValue = Convert.ToInt32(ProcessProperty(line1[12]));
                dataObject.waveSizeValue = Convert.ToInt32(ProcessProperty(line1[13]));
                dataObject.sigValue = Convert.ToInt32(ProcessProperty(line1[14]));
                dataObject.objValue = Convert.ToInt64(ProcessProperty(line1[15]));
                dataObject.kernelNameValue = ProcessProperty(line1[16]);
                dataObject.startTimeValue = Convert.ToInt64(ProcessProperty(line1[17]));
                dataObject.endTimeValue = Convert.ToInt64(ProcessProperty(line1[18]));

                dataObject.sqWaitAnyValue = Convert.ToDecimal(ProcessProperty(record[1]));
                dataObject.sqWaveCyclesValue = Convert.ToDecimal(ProcessProperty(record[2]));
                dataObject.sqCyclesValue = Convert.ToDecimal(ProcessProperty(record[3]));
                dataObject.GRBMCountValue = Convert.ToDecimal(ProcessProperty(record[4]));
                dataObject.GRBMGUIActiveValue = Convert.ToDecimal(ProcessProperty(record[5]));

                dataObjects.Add(dataObject);
            }
        }

        public string ProcessProperty(string item)
        {
            int start = 0;
            int end = 0;
            int length = 0;
            string value = "";

            if (item != null)
            {
                start = item.IndexOf("(");
                end = item.IndexOf(")");
                length = end - start - 1;
                value = item.Substring(start + 1, length);
            }

            return value;
        }
    }
}
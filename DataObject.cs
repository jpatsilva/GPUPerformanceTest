using System.Collections.Generic;

namespace QuickstartInteractiveDataDisplay
{
    

    public class DataObject
    {
        //string outFile = "./output/out.txt";
        //string outFile1 = "./output/out1.txt";
        public List<string> dataObjectProperties = new List<string>();
        public List<string> dataObjectValues = new List<string>();

        public int dispatchValue { get; set; }
        public int gpuIDValue { get; set; }
        public int queueIDValue { get; set; }
        public int queueIndexValue { get; set; }
        public int processIDValue { get; set; }
        public int threadIDValue { get; set; }
        public int grdValue { get; set; }
        public int wgrValue { get; set; }
        public int ldsValue { get; set; }
        public int scrValue { get; set; }
        public int archVgprValue { get; set; }
        public int accumVgprValue { get; set; }
        public int sgprValue { get; set; }
        public int waveSizeValue { get; set; }
        public int sigValue { get; set; }
        public long objValue { get; set; }
        public string kernelNameValue { get; set; }
        public long startTimeValue { get; set; }
        public long endTimeValue { get; set; }
        public decimal sqWaitAnyValue { get; set; }
        public decimal sqWaveCyclesValue { get; set; }
        public decimal sqCyclesValue { get; set; }
        public decimal GRBMCountValue { get; set; }
        public decimal GRBMGUIActiveValue { get; set; }

    }
}


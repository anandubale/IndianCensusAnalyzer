using System;
using System.Collections.Generic;
using IndianCensusAnalyzer.DTO;
using IndianCensusAnalyzer.POCO;
using System.Linq;
using Newtonsoft.Json;

namespace IndianCensusAnalyzer
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}

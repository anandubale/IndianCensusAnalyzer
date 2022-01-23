using NUnit.Framework;
using IndianCensusAnalyzer;
using IndianCensusAnalyzer.POCO;
using IndianCensusAnalyzer.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestProject1
{
    public class Tests
    {
        static string indianStateCensusHeaders = "state,population,area,density";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        //CorrectFilePaths
        static string indianStateCensusFilePath = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\IndiaStateCodes.csv";
        //WrongFilePaths
        static string wrongIndianStateCodeFilePath = "";
        static string wrongIndianStateCensusFilePath = "";
        //WrongFiles
        static string wrongHeaderIndianStateCodeFile = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\WrongHeaderIndiaStateCodes.csv";
        static string wrongHeaderIndianStateCensusFile = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\WronTypeIndiaStateCodes.txt";
        static string wrongIndianStateCensusFileType = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\WronTypeIndiaStateCodes.txt";
        //WrongDelimiter
        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\anand\Desktop\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\DelimiterIndiaStateCodes.csv";

        IndianCensusAnalyzer.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianCensusAnalyzer.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //count
        //TC 1.1
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(9, totalRecord.Count);
        }
        //TC 2.1
        [Test]
        public void GivenIndianCodeFilePath_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(10, stateRecord.Count);
        }
        //Wrong File Path
        //Tc 1.2
        [Test]
        public void GivenWrongIndianCensusCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        //TC 2.2
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        //WrongFileType
        //TC 1.3
        [Test]
        public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        //TC 2.3 
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.eType);
        }
        //FileWithWrongDelimeter
        //TC 1.4
        [Test]
        public void GivenWrongIndianCensusDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongDelimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        //TC 2.4
        [Test]
        public void GivenWrongIndianStateCodeDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongDelimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.eType);
        }
        //WrongHeader
        //TC 1.5
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        //TC 2.5
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCodeFile, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.eType);
        }
    }
}
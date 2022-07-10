using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
namespace IndianStatesCensusTesting
{
    public class Tests
    {
        string stateCensusFilePath = @"G:\FellowShip517\Day29_IndianCensusAnalyser\Day_29_CensusAnalyser\CensusAnalyser\CensusAnalyser\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"G:\FellowShip517\Day29_IndianCensusAnalyser\Day_29_CensusAnalyser\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndianPopulation.csv";
        string wrongTypeFilePath = @"G:\FellowShip517\Day29_IndianCensusAnalyser\Day_29_CensusAnalyser\CensusAnalyser\CensusAnalyser\CSVFiles\IndianPopulation.txt";
        string wrongDelimiterFilePath = @"G:\FellowShip517\Day29_IndianCensusAnalyser\Day_29_CensusAnalyser\CensusAnalyser\CensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"G:\FellowShip517\Day29_IndianCensusAnalyser\Day_29_CensusAnalyser\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string stateCodePath = @"G:\FellowShip517\Day29_IndianCensusAnalyser\Day_29_CensusAnalyser\CensusAnalyser\CensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodePath = @"G:\FellowShip517\Day28_IndainCensues\Day28_IndianCensusProblem\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndiaStateCde.csv";
        string wrongTypeStateCodePath= @"G:\FellowShip517\Day28_IndainCensues\Day28_IndianCensusProblem\CensusAnalyser\CensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string delimiterStateCodePath = @"G:\FellowShip517\Day28_IndainCensues\Day28_IndianCensusProblem\CensusAnalyser\CensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongHeaderStateCodePath= @"G:\FellowShip517\Day28_IndainCensues\Day28_IndianCensusProblem\CensusAnalyser\CensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";

        public CSVAdapterFactory csvAdapter = null;
        Dictionary<string, CensusDTO> stateRecords = null;
        Dictionary<string, CensusDTO> totalRecords;
        [SetUp]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
            totalRecords = new Dictionary<string, CensusDTO>();
        }
        /// <summary>
        ///TC 1.1 Given correct path To ensure number of records matches
        /// </summary>

        [Test]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(expected, stateRecords.Count);
        }
        /// <summary>
        ///TC 1.2 Given incorrect file should return custom exception - File not found
        /// </summary>
        [Test]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
        /// <summary>
        ///TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        /// </summary>

        [Test]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
        /// <summary>
        ///TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        /// </summary>

        [Test]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
        /// <summary>
        /////TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data 
        /// </summary>
        
        [Test]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
        /// TC 2.1
        /// Giving the correct path it should return the total count from the census
        [Test]
        public void GivenStateCodeReturnCount()
        {
            totalRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, totalRecords.Count);
        }
        [Test]
        public void GivenStateCodeReturnCount()
        {
            totalRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, totalRecords.Count);
        }
        /// <summary>
        /// /// TC 2.2 Giving incorrect path should return file not found custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectPathCodeCustomException()
        {
            var stateCustomException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateCustomException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 2.3
        /// Giving wrong type of path should return invalid file type custom exception
        [Test]
        public void GivenIncorrectPathTypeCodeReturnException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        /// TC 2.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [Test]
        public void GivenWrongHeaderStateCodeReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        /// TC 2.5
        /// Giving wrong header type should return incorrect header type custom exception
        [Test]
        public void GivenWrongDelimiterCodeReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }

    }
}

//Result TC.1.1
//IndianStatesCensusTesting
//  Tests in group: 1

//  Total Duration: 16.5 min

//Outcomes
//   1 Passed
//------------------------------------//
//TC.1.2
//IndianStatesCensusTesting
//  Tests in group: 2

//  Total Duration: 1.8 min

//Outcomes
//   2 Passed
//------------------------------------//
//TC.1.3
//IndianStatesCensusTesting
//  Tests in group: 3

//  Total Duration: 2.6 min

//Outcomes
//   3 Passed
//------------------------------------//
//TC.1.4
//IndianStatesCensusTesting
//  Tests in group: 4

//  Total Duration: 4.4 min

//Outcomes
//   4 Passed
//------------------------------------//
//TC.1.5
//IndianStatesCensusTesting
//  Tests in group: 5

//  Total Duration: 5.3 min

//Outcomes
//   5 Passed
//------------------------------------//

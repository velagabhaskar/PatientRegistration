using AutoMapper;
using Moq;
using NUnit.Framework;
using PatientInfo.API.Controllers;
using PatientInfo.API.DTO;
using PatientInfo.DAL;
using PatientInfo.DAL.Models;
using PatientInfo.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PatientRegistration.Test
{
    [TestFixture]
    internal class PatientTest
    {
        private Mock<IPatientRepository> _mockPatientRepository;
        private Mock<IMapper> _mockMapper;
        private PatientsController _controller;
        private Mock<DTOPatient> mockDTOPatient;

       private DTOPatient GetDTOPatient()
        {

        
            return new DTOPatient() { PatientID = 3, FirstName = "John", LastName= "Doe", EmailId = "john.doe@example.com",DateofBirth=new DateTime(1990, 1, 1) };
        }
        
        [SetUp]
        public void Setup()
        {
            _mockPatientRepository = new Mock<IPatientRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new PatientsController(_mockPatientRepository.Object, _mockMapper.Object);
        
        }
        [Test]
        public async Task AddPatient_ShouldReturnTrue_WhenRepositoryAddsPatientSuccessfully()
        {
            // Arrange
            var dtoPatient = GetDTOPatient();
            var patient = new PatientInfo.DAL.Models.Patient();
            _mockMapper.Setup(m => m.Map<PatientInfo.DAL.Models.Patient>(dtoPatient)).Returns(patient);
            _mockPatientRepository.Setup(repo => repo.AddPatinet(patient)).ReturnsAsync(true);

            // Act
            var result = await _controller.AddPatinet(dtoPatient);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UpdatePatient_ShouldReturnTrue_WhenRepositoryUpdatesPatientSuccessfully()
        {
            // Arrange
            var dtoPatient = new DTOPatient();
            var patient = new PatientInfo.DAL.Models.Patient();
            _mockMapper.Setup(m => m.Map<PatientInfo.DAL.Models.Patient>(dtoPatient)).Returns(patient);
            _mockPatientRepository.Setup(repo => repo.UpdatePatinet(patient)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdatePatinet(dtoPatient);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeletePatient_ShouldReturnTrue_WhenRepositoryDeletesPatientSuccessfully()
        {
            // Arrange
            int patientId = 1;
            _mockPatientRepository.Setup(repo => repo.DeletePatient(patientId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeletePatient(patientId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetAllPatients_ShouldReturnListOfDTOPatients_WhenRepositoryReturnsPatients()
        {
            // Arrange
            var patients = new List<PatientInfo.DAL.Models.Patient>();
            var dtoPatients = new List<DTOPatient>();
            _mockPatientRepository.Setup(repo => repo.GetAll()).ReturnsAsync(patients);
            _mockMapper.Setup(m => m.Map<IEnumerable<DTOPatient>>(patients)).Returns(dtoPatients);

            // Act
            var result = await _controller.GetAllPatients();

            // Assert
            Assert.AreEqual(dtoPatients, result);
        }

        [Test]
        public async Task GetPatient_ShouldReturnDTOPatient_WhenRepositoryReturnsPatient()
        {
            // Arrange
            int patientId = 1;
            var patient = new PatientInfo.DAL.Models.Patient();
            var dtoPatient = new DTOPatient();
            _mockPatientRepository.Setup(repo => repo.GetPatientbyID(patientId)).ReturnsAsync(patient);
            _mockMapper.Setup(m => m.Map<DTOPatient>(patient)).Returns(dtoPatient);

            // Act
            var result = await _controller.Get(patientId);

            // Assert
            Assert.AreEqual(dtoPatient, result);
        }
    }
}


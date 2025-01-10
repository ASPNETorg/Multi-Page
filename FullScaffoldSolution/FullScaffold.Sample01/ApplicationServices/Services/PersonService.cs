using FullScaffold.Samlple01.Models.Frameworks.Contracts;
using FullScaffold.Sample01.ApplicationServices.Dtos.PersonDtos;
using FullScaffold.Sample01.Models.DomainModels;

namespace FullScaffold.Sample01.ApplicationServices.Services
{
    public class PersonService
    {
         private readonly IPersonRepository _personRepository;
        #region [- Ctor -]
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion
        private static Person DtoConvertor(PostPersonServiceDto dto)
        {
            Models.DomainModels.Person model = new()
            {
                Firstname = dto.FirstName,
                Lastname = dto.LastName
            };
            return model;

        }
        public Task Post(PostPersonServiceDto model)
        {
            var p = _personRepository.Insert(PersonService.DtoConvertor(model));
            return p;
        }
    }
}

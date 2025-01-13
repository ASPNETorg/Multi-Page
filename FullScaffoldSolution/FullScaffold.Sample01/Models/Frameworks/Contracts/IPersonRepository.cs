using FullScaffold.Sample01.Models.DomainModels;

namespace FullScaffold.Samlple01.Models.Frameworks.Contracts
{
    public interface IPersonRepository
    {
        Task<List<Person>> Select();
		Task<Person> Select(Guid? id);
		Task Insert(Person person);
        Task Update(Person person);
        Task Delete(Person person);
       
    }
}
